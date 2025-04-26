using INV.Domain.Entity;
using INV.Domain.Enum;

namespace INV.Application.DTO
{
    public record NormalUserDTO(string Name, string Email, string Password)
    {
        public static implicit operator User(NormalUserDTO request)
        {
            return new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Role = Roles.Normal,
            };
        }
    }
  

}
