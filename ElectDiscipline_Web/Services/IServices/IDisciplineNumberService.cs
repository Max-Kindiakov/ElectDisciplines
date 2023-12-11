using ElectDiscipline_Web.Models.Dto;

namespace ElectDiscipline_Web.Services.IServices
{
    public interface IDisciplineNumberService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(DisciplineNumberCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(DisciplineNumberUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
