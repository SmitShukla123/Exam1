using System;
using System.Collections.Generic;

namespace Exam1.Models
{
    public partial class Product
    {
        public Product()
        {
            UserProducts = new HashSet<UserProduct>();
        }

        public int Pid { get; set; }
        public string? Pname { get; set; }
        public int? Cid { get; set; }
        public string? Pimage { get; set; }
        public decimal? Pcost { get; set; }
        public decimal? Istock { get; set; }
        public decimal? Astock { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? Isdeleted { get; set; }
        public bool? IsEnable { get; set; }

        public virtual Category? CidNavigation { get; set; }
        public virtual ICollection<UserProduct> UserProducts { get; set; }
    }
}
