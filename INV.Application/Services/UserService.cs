

using INV.Application.DTO;
using INV.Application.Services.Interfaces;
using INV.Data.Repository.Interfaces;
using INV.Domain.Entity;

namespace INV.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> RegisterNormalUser(NormalUserDTO user)
        {
           var result = await _repository.RegisterNormalUser(user);
           return result;
        }
    }
}
