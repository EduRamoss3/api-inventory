

using INV.Application.DTO;
using INV.Application.Results;
using INV.Application.Services.Interfaces;
using INV.Data.Repository.Interfaces;
using INV.Data.Results;
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

        public async Task<User?> Login(string email, string password)
        {
            return await _repository.Login(email, password);
        }

        public async Task<ResultServices> RegisterNormalUser(NormalUserDTO user)
        {
           
           var resultRepo = await _repository.RegisterNormalUser(user);
          
           return resultRepo;
        }
    }
}
