namespace lab3api.Model
{
    public class Sale
    {
        public int Id { get; set; } 
        public DateTime SaleDate { get; set; } 
        public string? Article { get; set; }
        public string? Name { get; set; }  
        public int Quantity { get; set; } 
        public decimal TotalPrice { get; set; } 
    }
}
