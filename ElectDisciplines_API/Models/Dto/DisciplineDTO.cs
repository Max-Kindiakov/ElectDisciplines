using System.ComponentModel.DataAnnotations;

namespace ElectDisciplines_API.Models.Dto
{
    public class DisciplineDTO
    { public int Id {  get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Teacher { get; set; }
    }
}
