using AutoMapper;
using ElectDiscipline_Web.Models.Dto;

namespace ElectDiscipline_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<DisciplineDTO, DisciplineCreateDTO>().ReverseMap();
            CreateMap<DisciplineDTO, DisciplineUpdateDTO>().ReverseMap();

        }
    }
}
