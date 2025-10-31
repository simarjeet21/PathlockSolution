using PLCHome.Api.DTOs;

namespace PLCHome.Api.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(AuthRegisterDto dto);
        Task<AuthResponseDto> LoginAsync(AuthLoginDto dto);
    }
}
