using ElectDisciplines_API.Models.Dto;

namespace ElectDisciplines_API.Data
{
    public static class DisciplineStore
    {
        public static List<DisciplineDTO> disciplineList = new List<DisciplineDTO>
            {
                new DisciplineDTO{Id = 1, Name = "Philosophy", Description = "Text1", Teacher = "Volkov A.S."},
                new DisciplineDTO{Id = 2, Name = "Mathematics", Description = "Text2", Teacher = "Bond J.P."}

            };
    }
}
