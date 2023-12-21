using AutoMapper;
using ElectDiscipline_Utility;
using ElectDiscipline_Web.Models;
using ElectDiscipline_Web.Models.Dto;
using ElectDiscipline_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ElectDiscipline_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDisciplineService _disciplineService;
        private readonly IMapper _mapper;
        public HomeController(IDisciplineService disciplineService, IMapper mapper)
        {
            _disciplineService = disciplineService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<DisciplineDTO> list = new();

            var response = await _disciplineService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DisciplineDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

    }
}