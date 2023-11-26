using ElectDisciplines_API.Data;
using ElectDisciplines_API.Models;
using ElectDisciplines_API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ElectDisciplines_API.Controllers
{
    [Route("api/DisciplinesAPI")]
    [ApiController]
    public class DisciplinesAPIController : ControllerBase
    {

        public DisciplinesAPIController()
        {
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<DisciplineDTO>> GetDisciplines()
        {
          
            return Ok(DisciplineStore.disciplineList);
        }

        [HttpGet("{id:int}", Name = "GetDiscipline")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type = typeof(DisciplineDTO))]
        public ActionResult<DisciplineDTO> GetDiscipline(int id)
        {
            if (id == 0) {  return BadRequest(); }

            var discipline = DisciplineStore.disciplineList.FirstOrDefault(u => u.Id == id);

            if (discipline == null) { return NotFound(); }

            return Ok(discipline);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DisciplineDTO> CreateDiscipline([FromBody]DisciplineDTO disciplineDTO)
        {
            //if(!ModelState.IsValid) { return BadRequest(ModelState); }
            if (DisciplineStore.disciplineList.FirstOrDefault(u => u.Name.ToLower() == disciplineDTO.Name.ToLower())!=null) 
            {
                ModelState.AddModelError("CustomError", "Така дисциплiна вже iснує!");
                return BadRequest(ModelState);
            }
            if(disciplineDTO == null) { return BadRequest(disciplineDTO); }
            if(disciplineDTO.Id > 0) {return StatusCode(StatusCodes.Status500InternalServerError); } //якщо створюємо з айді яке більше нуля, то ми нас правді не створюємо

            disciplineDTO.Id = DisciplineStore.disciplineList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            DisciplineStore.disciplineList.Add(disciplineDTO);
        
            return CreatedAtRoute("GetDiscipline",new {id = disciplineDTO.Id} ,disciplineDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteDiscipline")]
        public IActionResult DeleteDiscipline(int id)
        {
            if(id==0) { return BadRequest(); }

            var discipline = DisciplineStore.disciplineList.FirstOrDefault(u => u.Id == id);
            if(discipline == null) { return NotFound(); }
            DisciplineStore.disciplineList.Remove(discipline);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateDiscipline")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateDiscipline(int id, [FromBody]DisciplineDTO disciplineDTO)
        {
            if (disciplineDTO== null || id != disciplineDTO.Id) {  return BadRequest(); }
            var discipline = DisciplineStore.disciplineList.FirstOrDefault(u => u.Id == id);
            discipline.Name = disciplineDTO.Name;
            discipline.Description = disciplineDTO.Description;
            discipline.Teacher = disciplineDTO.Teacher;

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialDiscipline")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialDiscipline(int id, JsonPatchDocument<DisciplineDTO> patchDTO)
        {
            if(patchDTO==null || id == 0) { return BadRequest(); }
            var discipline = DisciplineStore.disciplineList.FirstOrDefault(u => u.Id == id);
            if(discipline == null) {  return BadRequest(); }
            patchDTO.ApplyTo(discipline, ModelState);
            if (!ModelState.IsValid) {  return BadRequest(ModelState); }
            return NoContent() ;
        }


    }
}
