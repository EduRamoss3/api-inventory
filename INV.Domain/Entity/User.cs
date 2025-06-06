﻿


using INV.Domain.Enum;

namespace INV.Domain.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }   
        public string Password { get; set; }
        public Roles Role { get; set; }    
        public bool IsActive { get; set; }
    }
}
