

using INV.Data.Results;
using INV.Domain.Entity;

namespace INV.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<ResultServices> RegisterNormalUser(User user);
        Task<User> Update(User user);
        Task<bool> Delete(User user);
        Task<User?> Login(string email, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> FindById(int id);    
    }
}
