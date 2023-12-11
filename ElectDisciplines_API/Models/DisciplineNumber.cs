using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectDisciplines_API.Models
{
    public class DisciplineNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DisciplineNo { get; set; }

        [ForeignKey("Discipline")]
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
    }
}
