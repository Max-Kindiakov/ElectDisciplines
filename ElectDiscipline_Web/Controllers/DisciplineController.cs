using AutoMapper;
using ElectDiscipline_Utility;
using ElectDiscipline_Web.Models;
using ElectDiscipline_Web.Models.Dto;
using ElectDiscipline_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ElectDiscipline_Web.Controllers
{
    public class DisciplineController : Controller
    {
        private readonly IDisciplineService _disciplineService;
        private readonly IMapper _mapper;
        public DisciplineController(IDisciplineService disciplineService, IMapper mapper)
        {
            _disciplineService = disciplineService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexDiscipline()
        {
            List<DisciplineDTO> list = new();

            var response = await _disciplineService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DisciplineDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
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
        public async Task<IActionResult> DeleteVilla(int disciplineId)
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
