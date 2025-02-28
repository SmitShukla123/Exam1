namespace Exam1.Model
{
    public class Produ
    {
        public int pid { get; set; }
        public string? pname { get; set; }
        public int? cid { get; set; }
        public string? pimage { get; set; }
        public decimal? pcost { get; set; }
        public decimal? istock { get; set; }
        public decimal? astock { get; set; }
        public string? deletedBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public string? createBy { get; set; }
        public DateTime? createAt { get; set; }
        public bool? isdeleted { get; set; }
        public bool? isEnable { get; set; }
    }
}
