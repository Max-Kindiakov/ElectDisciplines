using ElectDiscipline_Web.Models.Dto;

namespace ElectDiscipline_Web.Services.IServices
{
    public interface IDisciplineService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(DisciplineCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(DisciplineUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
