using ElectDisciplines_API.Models.Dto;

namespace ElectDisciplines_API.Repository.IRepository
{
    public interface IUserReposetory
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registerationRequestDTO);
    }
}
