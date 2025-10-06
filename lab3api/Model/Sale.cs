namespace lab3api.Model
{
    public class Sale
    {
        public int Id { get; set; } // № п/п
        public DateTime SaleDate { get; set; } // Дата продажи
        public string Article { get; set; } = string.Empty; // Артикул товара
        public string Name { get; set; } = string.Empty; // Наименование
        public int Quantity { get; set; } // Количество проданного
        public decimal TotalPrice { get; set; } // Стоимость продажи
    }
}
