namespace lab3api.Model
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Purchases.Any() && !context.Sales.Any())
            {
                // --- Таблица "Поступление"
                var purchases = new List<Purchase>
                {
                    new Purchase { Article = "A001", Name = "Кроссовки", UnitPrice = 100 },
                    new Purchase { Article = "A002", Name = "Ботинки", UnitPrice = 150 },
                    new Purchase { Article = "A003", Name = "Сандалии", UnitPrice = 80 },
                    new Purchase { Article = "A004", Name = "Туфли", UnitPrice = 120 },
                    new Purchase { Article = "A005", Name = "Сапоги", UnitPrice = 200 },
                    new Purchase { Article = "A006", Name = "Кеды", UnitPrice = 90 },
                    new Purchase { Article = "A007", Name = "Тапочки", UnitPrice = 50 }
                };

                context.Purchases.AddRange(purchases);

                // --- Таблица "Продажа"
                var sales = new List<Sale>
                {
                    new Sale { SaleDate = new DateTime(2025,10,1), Article = "A001", Name = "Кроссовки", Quantity = 2, TotalPrice = 200 },
                    new Sale { SaleDate = new DateTime(2025,10,1), Article = "A002", Name = "Ботинки", Quantity = 1, TotalPrice = 150 },
                    new Sale { SaleDate = new DateTime(2025,10,2), Article = "A001", Name = "Кроссовки", Quantity = 1, TotalPrice = 100 },
                    new Sale { SaleDate = new DateTime(2025,10,2), Article = "A004", Name = "Туфли", Quantity = 3, TotalPrice = 360 },
                    new Sale { SaleDate = new DateTime(2025,10,3), Article = "A006", Name = "Кеды", Quantity = 5, TotalPrice = 450 },
                    new Sale { SaleDate = new DateTime(2025,10,3), Article = "A005", Name = "Сапоги", Quantity = 2, TotalPrice = 400 },
                    new Sale { SaleDate = new DateTime(2025,10,4), Article = "A003", Name = "Сандалии", Quantity = 4, TotalPrice = 320 }
                };

                context.Sales.AddRange(sales);

                context.SaveChanges();
            }
        }
    }
}
