using System.ComponentModel.DataAnnotations;

namespace ElectDisciplines_API.Models.Dto
{
    public class DisciplineUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }  //опис предмету
        [Required]
        public int Course { get; set; }
        public string Teacher { get; set; }
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
