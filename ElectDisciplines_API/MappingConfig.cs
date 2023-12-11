using AutoMapper;
using ElectDisciplines_API.Models;
using ElectDisciplines_API.Models.Dto;

namespace ElectDisciplines_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<Discipline, DisciplineDTO>();
            CreateMap<DisciplineDTO, Discipline>();

            CreateMap<Discipline, DisciplineCreateDTO>().ReverseMap();
            CreateMap<Discipline, DisciplineUpdateDTO>().ReverseMap();

            CreateMap<DisciplineNumber, DisciplineNumberDTO>().ReverseMap();
            CreateMap<DisciplineNumber, DisciplineNumberCreateDTO>().ReverseMap();
            CreateMap<DisciplineNumber, DisciplineNumberUpdateDTO>().ReverseMap();
        }
    }
}
