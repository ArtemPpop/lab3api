namespace lab3api.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public string? Article { get; set; }  
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; } 
    }
}
