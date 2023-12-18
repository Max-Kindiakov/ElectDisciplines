using AutoMapper;
using ElectDiscipline_Utility;
using ElectDiscipline_Web.Models;
using ElectDiscipline_Web.Models.Dto;
using ElectDiscipline_Web.Models.VM;
using ElectDiscipline_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ElectDiscipline_Web.Controllers
{
    public class DisciplineNumberController : Controller
    {
        private readonly IDisciplineNumberService _disciplineNumberService;
        private readonly IDisciplineService _disciplineService;
        private readonly IMapper _mapper;
        public DisciplineNumberController(IDisciplineNumberService disciplineNumberService, IMapper mapper, IDisciplineService disciplineService)
        {
            _disciplineNumberService = disciplineNumberService;
            _mapper = mapper;
            _disciplineService = disciplineService;
        }

        public async Task<IActionResult> IndexDisciplineNumber()
        {
            List<DisciplineNumberDTO> list = new();

            var response = await _disciplineNumberService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DisciplineNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateDisciplineNumber()
        {
            DicsiplineNumberCreateVM disciplineNumberVM = new();
            var response = await _disciplineService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                disciplineNumberVM.DisciplineList = JsonConvert.DeserializeObject<List<DisciplineDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(disciplineNumberVM);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDisciplineNumber(DicsiplineNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _disciplineNumberService.CreateAsync<APIResponse>(model.DisciplineNumber, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexDisciplineNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _disciplineService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.DisciplineList = JsonConvert.DeserializeObject<List<DisciplineDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateDisciplineNumber(int disciplineNo)
        {
            DisciplineNumberUpdateVM disciplineNumberVM = new();
            var response = await _disciplineNumberService.GetAsync<APIResponse>(disciplineNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                DisciplineNumberDTO model = JsonConvert.DeserializeObject<DisciplineNumberDTO>(Convert.ToString(response.Result));
                disciplineNumberVM.DisciplineNumber = _mapper.Map<DisciplineNumberUpdateDTO>(model);
            }

            response = await _disciplineService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                disciplineNumberVM.DisciplineList = JsonConvert.DeserializeObject<List<DisciplineDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                return View(disciplineNumberVM);
            }


            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDisciplineNumber(DisciplineNumberUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _disciplineNumberService.UpdateAsync<APIResponse>(model.DisciplineNumber, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexDisciplineNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _disciplineService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.DisciplineList = JsonConvert.DeserializeObject<List<DisciplineDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteDisciplineNumber(int disciplineNo)
        {
            DisciplineNumberDeleteVM disciplineNumberVM = new();
            var response = await _disciplineNumberService.GetAsync<APIResponse>(disciplineNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                DisciplineNumberDTO model = JsonConvert.DeserializeObject<DisciplineNumberDTO>(Convert.ToString(response.Result));
                disciplineNumberVM.DisciplineNumber = model;
            }

            response = await _disciplineService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                disciplineNumberVM.DisciplineList = JsonConvert.DeserializeObject<List<DisciplineDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                return View(disciplineNumberVM);
            }


            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDisciplineNumber(DisciplineNumberDeleteVM model)
        {

            var response = await _disciplineNumberService.DeleteAsync<APIResponse>(model.DisciplineNumber.DisciplineNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexDisciplineNumber));
            }

            return View(model);
        }



    }
}
