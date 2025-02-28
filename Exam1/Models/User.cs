using System;
using System.Collections.Generic;

namespace Exam1.Models
{
    public partial class User
    {
        public User()
        {
            UserProducts = new HashSet<UserProduct>();
        }

        public int Uid { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Cpassword { get; set; }

        public virtual ICollection<UserProduct> UserProducts { get; set; }
    }
}
