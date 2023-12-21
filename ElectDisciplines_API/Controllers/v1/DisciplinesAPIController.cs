using AutoMapper;
using Azure;
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
using System.Text.Json;

namespace ElectDisciplines_API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/DisciplineAPI")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DisciplinesAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IDisciplineRepository _dbDiscipline;
        private readonly IMapper _mapper;
        public DisciplinesAPIController(IDisciplineRepository dbDiscipline, IMapper mapper)
        {
            _dbDiscipline = dbDiscipline;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetDisciplines([FromQuery(Name = "filterRate")] int? rate,
            [FromQuery] string? search, int pageSize = 0, int pageNumber = 1)
        {
            try
            {

                IEnumerable<Discipline> disciplineList;

                if (rate > 0)
                {
                    disciplineList = await _dbDiscipline.GetAllAsync(u => u.Rate == rate, pageSize: pageSize,
                        pageNumber: pageNumber);
                }
                else
                {
                    disciplineList = await _dbDiscipline.GetAllAsync(pageSize: pageSize,
                        pageNumber: pageNumber);
                }
                if (!string.IsNullOrEmpty(search))
                {
                    disciplineList = disciplineList.Where(u => u.Name.ToLower().Contains(search));
                }
                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
                _response.Result = _mapper.Map<List<DisciplineDTO>>(disciplineList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpGet("{id:int}", Name = "GetDiscipline")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetDiscipline(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var discipline = await _dbDiscipline.GetAsync(u => u.Id == id);
                if (discipline == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<DisciplineDTO>(discipline);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateDiscipline([FromBody] DisciplineCreateDTO createDTO)
        {
            try
            {
                
                if (await _dbDiscipline.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Discipline already Exists!");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                
                Discipline discipline = _mapper.Map<Discipline>(createDTO);

             
                await _dbDiscipline.CreateAsync(discipline);
                _response.Result = _mapper.Map<DisciplineDTO>(discipline);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetDiscipline", new { id = discipline.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteDiscipline")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<APIResponse>> DeleteDiscipline(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var discipline = await _dbDiscipline.GetAsync(u => u.Id == id);
                if (discipline == null)
                {
                    return NotFound();
                }
                await _dbDiscipline.RemoveAsync(discipline);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateDiscipline")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateDiscipline(int id, [FromBody] DisciplineUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Discipline model = _mapper.Map<Discipline>(updateDTO);

                await _dbDiscipline.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialDiscipline")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialDiscipline(int id, JsonPatchDocument<DisciplineUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var discipline = await _dbDiscipline.GetAsync(u => u.Id == id, tracked: false);

           DisciplineUpdateDTO disciplineDTO = _mapper.Map<DisciplineUpdateDTO>(discipline);


            if (discipline == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(disciplineDTO, ModelState);
            Discipline model = _mapper.Map<Discipline>(disciplineDTO);

            await _dbDiscipline.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }


    }
}