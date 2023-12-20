using ElectDiscipline_Utility;
using ElectDiscipline_Web.Models;
using ElectDiscipline_Web.Models.Dto;
using ElectDiscipline_Web.Services.IServices;

namespace ElectDiscipline_Web.Services
{
    public class DisciplineNumberService : BaseService, IDisciplineNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string disciplineUrl;

        public DisciplineNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            disciplineUrl = configuration.GetValue<string>("ServiceUrls:DisciplineAPI");

        }

        public Task<T> CreateAsync<T>(DisciplineNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = disciplineUrl + "/api/v1/disciplinesNumberAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = disciplineUrl + "/api/v1/disciplinesNumberAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = disciplineUrl + "/api/v1/disciplinesNumberAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = disciplineUrl + "/api/v1/disciplinesNumberAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(DisciplineNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = disciplineUrl + "/api/v1/disciplinesNumberAPI/" + dto.DisciplineNo,
                Token = token
            });
        }
    }
}
