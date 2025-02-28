namespace Exam1.Model
{
    public class UserPurch
    {
        public int? upid { get; set; }
        public int? pid { get; set; }
        public int? uid { get; set; }
        public decimal? quntity { get; set; }
        public decimal? totalCost { get; set; }
        public DateTime? date { get; set; }
        public decimal? peCost { get; set; }
        public string? deletedBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public string? createBy { get; set; }
        public DateTime? createAt { get; set; }
        public bool? isdeleted { get; set; }
        public bool? isEnable { get; set; }
    }
}
