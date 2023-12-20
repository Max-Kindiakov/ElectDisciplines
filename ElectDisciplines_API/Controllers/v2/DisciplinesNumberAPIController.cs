using AutoMapper;
using ElectDisciplines_API.Data;
using ElectDisciplines_API.Models;
using ElectDisciplines_API.Models.Dto;
using ElectDisciplines_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ElectDisciplines_API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/DisciplinesNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
    public class DisciplinesNumberAPIController : ControllerBase
    {
        protected APIResponse _responce;
        private readonly IDisciplineNumberRepository _dbDisciplineNumber;
        private readonly IDisciplineRepository _dbDiscipline;
        private readonly IMapper _mapper;

        public DisciplinesNumberAPIController(IDisciplineNumberRepository dbDisciplineNumber, IMapper mapper, IDisciplineRepository dbDiscipline)
        {
            _dbDisciplineNumber = dbDisciplineNumber;
            _mapper = mapper;
            _responce = new();
            _dbDiscipline = dbDiscipline;
        }


        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "MaxKindiakov", "coursework" };
        }




    }
}
