using ElectDiscipline_Utility;
using ElectDiscipline_Web.Models.Dto;
using ElectDiscipline_Web.Models;
using ElectDiscipline_Web.Services.IServices;

namespace ElectDiscipline_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string disciplineUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            disciplineUrl = configuration.GetValue<string>("ServiceUrls:DisciplineAPI");

        }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = disciplineUrl + "/api/v1/UsersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = disciplineUrl + "/api/v1/UsersAuth/register"
            });
        }
    }
}
