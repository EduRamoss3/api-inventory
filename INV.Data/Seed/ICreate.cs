using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.Data.Seed
{
    public interface ICreate
    {
        Task CreateTableProducts();
        Task CreateDb();
        Task CreateTableUsers();
    }
}
