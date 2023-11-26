using System.ComponentModel.DataAnnotations;

namespace ElectDisciplines_API.Models.Dto
{
    public class DisciplineDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }  //опис предмету
        public int Course { get; set; }
        public string Teacher { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
