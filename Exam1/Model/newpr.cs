namespace Exam1.Model
{
    public class newpr
    {
        public int pid { get; set; }           // Product ID
        public string? pname { get; set; }     // Product Name
        public string? categoryName { get; set; }     // Product Name
        public int? cid { get; set; }          // Category ID
        public string? pimage { get; set; }    // Product Image
        public decimal? pcost { get; set; }    // Product Cost
        public decimal? istock { get; set; }   // Initial Stock
        public decimal? astock { get; set; }   // Available Stock (After Purchases)

        // Fields from UserProduct table
        public decimal? quntity { get; set; }   // Quantity Purchased by User
        public decimal? peCost { get; set; }    // Per Unit Cost of Product
        public decimal? totalCost { get; set; } // Total Cost for Purchased Quantity
        public DateTime? date { get; set; }
    }
}
