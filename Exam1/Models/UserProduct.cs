using System;
using System.Collections.Generic;

namespace Exam1.Models
{
    public partial class UserProduct
    {
        public int Upid { get; set; }
        public int? Pid { get; set; }
        public int? Uid { get; set; }
        public decimal? Quntity { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? Date { get; set; }
        public decimal? PeCost { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? Isdeleted { get; set; }
        public bool? IsEnable { get; set; }

        public virtual Product? PidNavigation { get; set; }
        public virtual User? UidNavigation { get; set; }
    }
}
