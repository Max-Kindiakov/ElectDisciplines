using System.ComponentModel.DataAnnotations;

namespace ElectDisciplines_API.Models.Dto
{
    public class DisciplineCreateDTO
    {
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }  //опис предмету
        public int Course { get; set; }
        public string Teacher { get; set; }
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
