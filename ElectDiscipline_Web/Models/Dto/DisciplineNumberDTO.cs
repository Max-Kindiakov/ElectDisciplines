using System.ComponentModel.DataAnnotations;

namespace ElectDiscipline_Web.Models.Dto
{
    public class DisciplineNumberDTO
    {
        [Required]
        public int DisciplineNo { get; set; }
        [Required]
        public int DisciplineId { get; set; }
        public string SpecialDetails { get; set; }
        public DisciplineDTO Discipline { get; set; }
        
    }
}
