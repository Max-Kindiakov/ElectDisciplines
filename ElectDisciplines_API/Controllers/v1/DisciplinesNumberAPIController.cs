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

namespace ElectDisciplines_API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/DisciplinesNumberAPI")]
    [ApiController]
    [ApiVersion("1.0")]
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

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetDisciplineNumbers()
        {
            try
            {
                IEnumerable<DisciplineNumber> disciplineNumberList = await _dbDisciplineNumber.GetAllAsync(includeProperties: "Discipline");
                _responce.Result = _mapper.Map<List<DisciplineNumberDTO>>(disciplineNumberList);
                _responce.StatusCode = HttpStatusCode.OK;
                return Ok(_responce);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responce;
        }

        [HttpGet("{id:int}", Name = "GetDisciplineNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetDisciplineNumber(int id)
        {
            try
            {
                _responce.StatusCode = HttpStatusCode.BadRequest;
                if (id == 0) { return BadRequest(_responce); }

                var disciplineNumber = await _dbDisciplineNumber.GetAsync(u => u.DisciplineNo == id);

                if (disciplineNumber == null) { _responce.StatusCode = HttpStatusCode.NotFound; return NotFound(_responce); }
                _responce.Result = _mapper.Map<DisciplineNumberDTO>(disciplineNumber);
                _responce.StatusCode = HttpStatusCode.OK;
                return Ok(_responce);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responce;
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateDisciplineNumber([FromBody] DisciplineNumberCreateDTO createDTO)
        {
            try
            {
                //if(!ModelState.IsValid) { return BadRequest(ModelState); }
                if (await _dbDisciplineNumber.GetAsync(u => u.DisciplineNo == createDTO.DisciplineNo) != null)
                {
                    ModelState.AddModelError("CustomError", "Такий номер дисциплiни вже iснує!");
                    return BadRequest(ModelState);
                }
                if (await _dbDiscipline.GetAsync(u => u.Id == createDTO.DisciplineId) == null)
                {
                    ModelState.AddModelError("CustomError", "Айді дисциплiни недійсне!");
                    return BadRequest(ModelState);
                }

                if (createDTO == null) { return BadRequest(createDTO); }
                //if(disciplineDTO.Id > 0) {return StatusCode(StatusCodes.Status500InternalServerError); } //якщо створюємо з айді яке більше нуля, то ми нас правді не створюємо
                DisciplineNumber disciplineNumber = _mapper.Map<DisciplineNumber>(createDTO);


                await _dbDisciplineNumber.CreateAsync(disciplineNumber);
                _responce.Result = _mapper.Map<DisciplineNumberDTO>(disciplineNumber);
                _responce.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetDiscipline", new { id = disciplineNumber.DisciplineNo }, _responce);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responce;
        }
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteDisciplineNumber")]
        public async Task<ActionResult<APIResponse>> DeleteDisciplineNumber(int id)
        {
            try
            {
                if (id == 0) { return BadRequest(); }

                var disciplineNumber = await _dbDisciplineNumber.GetAsync(u => u.DisciplineNo == id);
                if (disciplineNumber == null) { return NotFound(); }

                await _dbDisciplineNumber.RemoveAsync(disciplineNumber);

                _responce.StatusCode = HttpStatusCode.NoContent;
                _responce.IsSuccess = true;
                return Ok(_responce);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responce;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateDisciplineNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateDisciplineNumber(int id, [FromBody] DisciplineNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.DisciplineNo) { return BadRequest(); }
                if (await _dbDiscipline.GetAsync(u => u.Id == updateDTO.DisciplineId) == null)
                {
                    ModelState.AddModelError("CustomError", "Айді дисциплiни недійсне!");
                    return BadRequest(ModelState);
                }

                DisciplineNumber model = _mapper.Map<DisciplineNumber>(updateDTO);
                await _dbDisciplineNumber.UpdateAsync(model);
                _responce.StatusCode = HttpStatusCode.NoContent;
                _responce.IsSuccess = true;
                return Ok(_responce);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responce;
        }

        //[HttpPatch("{id:int}", Name = "UpdatePartialDiscipline")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdatePartialDiscipline(int id, JsonPatchDocument<DisciplineUpdateDTO> patchDTO)
        //{
        //    if (patchDTO == null || id == 0) { return BadRequest(); }
        //    var discipline = await _dbDiscipline.GetAsync(u => u.Id == id, tracked: false);

        //    DisciplineUpdateDTO disciplineDTO = _mapper.Map<DisciplineUpdateDTO>(discipline);



        //    if (discipline == null) { return BadRequest(); }
        //    patchDTO.ApplyTo(disciplineDTO, ModelState);
        //    Discipline model = _mapper.Map<Discipline>(disciplineDTO);

        //    await _dbDiscipline.UpdateAsync(model);
        //    if (!ModelState.IsValid) { return BadRequest(ModelState); }
        //    return NoContent();
        //}


    }
}
