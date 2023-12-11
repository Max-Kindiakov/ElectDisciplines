using AutoMapper;
using ElectDisciplines_API.Data;
using ElectDisciplines_API.Models;
using ElectDisciplines_API.Models.Dto;
using ElectDisciplines_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ElectDisciplines_API.Controllers
{
    [Route("api/DisciplinesAPI")]
    [ApiController]
    public class DisciplinesAPIController : ControllerBase
    {
        protected APIResponse _responce;
        private readonly IDisciplineRepository _dbDiscipline;
        private readonly IMapper _mapper;

        public DisciplinesAPIController(IDisciplineRepository dbDiscipline, IMapper mapper)
        {
            _dbDiscipline = dbDiscipline;
            _mapper = mapper;
            this._responce = new();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetDisciplines()
        {
            try
            {
                IEnumerable<Discipline> disciplineList = await _dbDiscipline.GetAllAsync();
                _responce.Result = _mapper.Map<List<DisciplineDTO>>(disciplineList);
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

        [HttpGet("{id:int}", Name = "GetDiscipline")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type = typeof(DisciplineDTO))]
        public async Task<ActionResult<APIResponse>> GetDiscipline(int id)
        {
            try
            {
                _responce.StatusCode = HttpStatusCode.BadRequest;
                if (id == 0) { return BadRequest(_responce); }

                var discipline = await _dbDiscipline.GetAsync(u => u.Id == id);

                if (discipline == null) { _responce.StatusCode = HttpStatusCode.NotFound; return NotFound(_responce); }
                _responce.Result = _mapper.Map<DisciplineDTO>(discipline);
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateDiscipline([FromBody] DisciplineCreateDTO createDTO)
        {
            try
            {
                //if(!ModelState.IsValid) { return BadRequest(ModelState); }
                if (await _dbDiscipline.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Така дисциплiна вже iснує!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null) { return BadRequest(createDTO); }
                //if(disciplineDTO.Id > 0) {return StatusCode(StatusCodes.Status500InternalServerError); } //якщо створюємо з айді яке більше нуля, то ми нас правді не створюємо
                Discipline discipline = _mapper.Map<Discipline>(createDTO);


                await _dbDiscipline.CreateAsync(discipline);
                _responce.Result = _mapper.Map<DisciplineDTO>(discipline);
                _responce.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetDiscipline", new { id = discipline.Id }, _responce);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responce;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteDiscipline")]
        public async Task<ActionResult<APIResponse>> DeleteDiscipline(int id)
        {
            try
            {
                if (id == 0) { return BadRequest(); }

                var discipline = await _dbDiscipline.GetAsync(u => u.Id == id);
                if (discipline == null) { return NotFound(); }

                await _dbDiscipline.RemoveAsync(discipline);

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

        [HttpPut("{id:int}", Name = "UpdateDiscipline")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateDiscipline(int id, [FromBody] DisciplineUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id) { return BadRequest(); }

                Discipline model = _mapper.Map<Discipline>(updateDTO);
                await _dbDiscipline.UpdateAsync(model);
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

        [HttpPatch("{id:int}", Name = "UpdatePartialDiscipline")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialDiscipline(int id, JsonPatchDocument<DisciplineUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0) { return BadRequest(); }
            var discipline = await _dbDiscipline.GetAsync(u => u.Id == id, tracked: false);

            DisciplineUpdateDTO disciplineDTO = _mapper.Map<DisciplineUpdateDTO>(discipline);



            if (discipline == null) { return BadRequest(); }
            patchDTO.ApplyTo(disciplineDTO, ModelState);
            Discipline model = _mapper.Map<Discipline>(disciplineDTO);

            await _dbDiscipline.UpdateAsync(model);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return NoContent();
        }


    }
}
