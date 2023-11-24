namespace ElectDisciplines_API.Models
{
    public class Discipline
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        //public string Description { get; set; }  //опис предмету

        public DateTime CreatedDate { get; set; }
    }
}
