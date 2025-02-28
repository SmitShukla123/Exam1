using System;
using System.Collections.Generic;

namespace Exam1.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Cid { get; set; }
        public string? Cname { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? Isdeleted { get; set; }
        public bool? IsEnable { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
