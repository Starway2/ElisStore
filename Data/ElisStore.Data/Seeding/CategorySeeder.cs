namespace ElisStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElisStore.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category() { Name = "Кашкавали" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Брашна" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Сирена" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Деликатеси" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Салами" });

        }
    }
}
