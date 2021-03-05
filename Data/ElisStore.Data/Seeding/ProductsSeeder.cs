namespace ElisStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElisStore.Data.Models;

    public class ProductsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Products.Any())
            {
                return;
            }

            await dbContext.AddAsync(new Product() { Name = "Кащкавал 'Сакарела'", CategoryId = 1, Description = "Много хубав и твърд кашкавал.", Price = 7.99, Weight = 2.5 });
            await dbContext.AddAsync(new Product() { Name = "Кащкавал 'Дянково'", CategoryId = 1, Description = "Много хубав, твърд кашкавал.", Price = 9.99, Weight = 2.5 });
            await dbContext.AddAsync(new Product() { Name = "Пицарино", CategoryId = 1, Description = "Много хубав продукт, имитиращ кашкавал. Перфектен за пици.", Price = 6.40, Weight = 3 });
            await dbContext.AddAsync(new Product() { Name = "Топаз Мел Класик", CategoryId = 2, Description = "Брашно тип 500 на ТОПАЗ МЕЛ е страхотно брашно.", Price = 22, Weight = 25 });
            await dbContext.AddAsync(new Product() { Name = "Топаз Мел Баница класик", CategoryId = 2, Description = "Брашното БАНИЦА КЛАСИК на ТОПАЗ МЕЛ е страхотно брашно.", Price = 23, Weight = 25 });
            await dbContext.AddAsync(new Product() { Name = "Топаз Мел Козунак", CategoryId = 2, Description = "Брашното КОЗУНАК на ТОПАЗ МЕЛ е страхотно брашно.", Price = 24, Weight = 25 });
            await dbContext.AddAsync(new Product() { Name = "Деликатес 'Лудогорие'", CategoryId = 4, Description = "Евтино сирене на буци. Страхотно за банички.", Price = 16, Weight = 8 });
            await dbContext.AddAsync(new Product() { Name = "Деликатес 'Дянково'", CategoryId = 4, Description = "Деликатес Дянково буци има хубава зелена кофа на която дръжките се чупят лесно.", Price = 17.60, Weight = 8 });
            await dbContext.AddAsync(new Product() { Name = "Имитиращ продукт Булгарисима трошено", CategoryId = 3, Description = "Кофти сирене, ама е криза... Няма как да не си вземеш! Перфектно за банички, тъй като е готово натрошено без саламура.", Price = 7.40, Weight = 10 });
            await dbContext.AddAsync(new Product() { Name = "Кренвирши", CategoryId = 5, Description = "Не са много вкусни, но ако си гладен... хохохо", Price = 1.40, Weight = 1.5 });
            await dbContext.AddAsync(new Product() { Name = "Шунка кубче", CategoryId = 5, Description = "Страхотен вкус на ниска цена.", Price = 1.80, Weight = 2.5 });
            await dbContext.AddAsync(new Product() { Name = "Шунка слайс", CategoryId = 5, Description = "Евтина и вкусна. Перфектна за закуски.", Price = 2, Weight = 1 });
        }
    }
}
