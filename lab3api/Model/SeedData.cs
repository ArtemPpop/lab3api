using Microsoft.EntityFrameworkCore;

namespace lab3api.Model
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            using (DataContext db = new DataContext())
            {
                //if (!context.Purchases.Any() && !context.Sales.Any())
                //{

                //    var purchases = new List<Purchase>
                //{
                //    new Purchase { Article = "a1", Name = "Кроссовки", UnitPrice = 100 },
                //    new Purchase { Article = "a2", Name = "Ботинки", UnitPrice = 150 },
                //    new Purchase { Article = "a3", Name = "Сандалии", UnitPrice = 80 },
                //    new Purchase { Article = "a4", Name = "Туфли", UnitPrice = 120 },
                //    new Purchase { Article = "a5", Name = "Сапоги", UnitPrice = 200 },
                //    new Purchase { Article = "a6", Name = "Кеды", UnitPrice = 90 },
                //    new Purchase { Article = "a7", Name = "Тапочки", UnitPrice = 50 }
                //};

                //    context.Purchases.AddRange(purchases);


                //    var sales = new List<Sale>
                //{
                //    new Sale { SaleDate = new DateTime(2025,10,1), Article = "a1", Name = "Кроссовки", Quantity = 2, TotalPrice = 200 },
                //    new Sale { SaleDate = new DateTime(2025,10,1), Article = "a2", Name = "Ботинки", Quantity = 1, TotalPrice = 150 },
                //    new Sale { SaleDate = new DateTime(2025,10,2), Article = "a1", Name = "Кроссовки", Quantity = 1, TotalPrice = 100 },
                //    new Sale { SaleDate = new DateTime(2025,10,2), Article = "a4", Name = "Туфли", Quantity = 3, TotalPrice = 360 },
                //    new Sale { SaleDate = new DateTime(2025,10,3), Article = "a6", Name = "Кеды", Quantity = 5, TotalPrice = 450 },
                //    new Sale { SaleDate = new DateTime(2025,10,3), Article = "a5", Name = "Сапоги", Quantity = 2, TotalPrice = 400 },
                //    new Sale { SaleDate = new DateTime(2025,10,4), Article = "a3", Name = "Сандалии", Quantity = 4, TotalPrice = 320 }
                //};

                //    context.Sales.AddRange(sales);

                //    context.SaveChanges();
                //}
            }
        }
    }
}
