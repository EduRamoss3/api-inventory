

using INV.Domain.Entity;

namespace INV.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterNormalUser(User user);
        Task<User> Update(User user);
        Task<bool> Delete(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> FindById(int id);    
    }
}
