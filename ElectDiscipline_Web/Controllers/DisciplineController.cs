using AutoMapper;
using ElectDiscipline_Utility;
using ElectDiscipline_Web.Models;
using ElectDiscipline_Web.Models.Dto;
using ElectDiscipline_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace ElectDiscipline_Web.Controllers
{
    public class DisciplineController : Controller
    {
        private readonly IDisciplineService _disciplineService;
        private readonly IMapper _mapper;
        private string sortOrder;
        private const int PageSize = 5;

        public DisciplineController(IDisciplineService disciplineService, IMapper mapper)
        {
            _disciplineService = disciplineService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexDiscipline(string sortOrder, string searchString, int? page)
        {
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TeacherSortParam"] = sortOrder == "Teacher" ? "teacher_desc" : "Teacher";
            ViewData["RateSortParam"] = sortOrder == "Rate" ? "rate_desc" : "Rate";

            List<DisciplineDTO> list = new();

            var response = await _disciplineService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DisciplineDTO>>(Convert.ToString(response.Result));

                switch (sortOrder)
                {
                    case "name_desc":
                        list = list.OrderByDescending(s => s.Name).ToList();
                        break;
                    case "Teacher":
                        list = list.OrderBy(s => s.Teacher).ToList();
                        break;
                    case "teacher_desc":
                        list = list.OrderByDescending(s => s.Teacher).ToList();
                        break;
                    case "Rate":
                        list = list.OrderBy(s => s.Rate).ToList();
                        break;
                    case "rate_desc":
                        list = list.OrderByDescending(s => s.Rate).ToList();
                        break;
                    default:
                        list = list.OrderBy(s => s.Name).ToList();
                        break;
                }

                if (!String.IsNullOrEmpty(searchString))
                {
                    list = list.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                           || s.Teacher.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }

            // Встановлюємо номер сторінки та розмір сторінки
            int pageNumber = page ?? 1;

            // Створюємо пагінацію
            IPagedList<DisciplineDTO> pagedList = list.ToPagedList(pageNumber, PageSize);

            return View(pagedList);
        }

        // Інші методи контролера ...
    



    [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateDiscipline()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDiscipline(DisciplineCreateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _disciplineService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Предмет успішно створено";
                    return RedirectToAction(nameof(IndexDiscipline));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateDiscipline(int disciplineId)
        {
            var response = await _disciplineService.GetAsync<APIResponse>(disciplineId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {

                DisciplineDTO model = JsonConvert.DeserializeObject<DisciplineDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<DisciplineUpdateDTO>(model));
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDiscipline(DisciplineUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Предмет успішно оновлено";
                var response = await _disciplineService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexDiscipline));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteDiscipline(int disciplineId)
        {
            var response = await _disciplineService.GetAsync<APIResponse>(disciplineId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                DisciplineDTO model = JsonConvert.DeserializeObject<DisciplineDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDiscipline(DisciplineDTO model)
        {

            var response = await _disciplineService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Предмет успішно видалено";
                return RedirectToAction(nameof(IndexDiscipline));
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

    }
}
