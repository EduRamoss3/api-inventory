using INV.Application.DTO;
using INV.Data.Results;
using INV.Domain.Entity;

namespace INV.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultServices> RegisterNormalUser(NormalUserDTO user);
        Task<User?> Login(string email, string password);
    }
}
