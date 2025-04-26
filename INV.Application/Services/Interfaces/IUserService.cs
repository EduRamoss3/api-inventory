using INV.Application.DTO;
using INV.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterNormalUser(NormalUserDTO user);
    }
}
