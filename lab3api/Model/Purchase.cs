namespace lab3api.Model
{
    public class Purchase
    {
        public int Id { get; set; } // № п/п
        public string Article { get; set; } = string.Empty; // Артикул (ключ)
        public string Name { get; set; } = string.Empty; // Наименование
        public decimal UnitPrice { get; set; } // Стоимость единицы товара
    }
}
