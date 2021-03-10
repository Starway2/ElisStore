namespace ElisStore.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElisStore.Data.Common.Repositories;
    using ElisStore.Data.Models;
    using ElisStore.Services.Mapping;
    using ElisStore.Web.ViewModels.Products;
    using Microsoft.Extensions.Logging;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> repository;

        public ProductsService(IDeletableEntityRepository<Product> repository)
        {
            this.repository = repository;
        }

        public ICollection<T> GetAll<T>() => this.repository.All().To<T>().ToList();

        public T GetById<T>(int id) => this.repository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

        public T GetByName<T>(string name) => this.repository.All().Where(x => x.Name == name).To<T>().FirstOrDefault();

        public async Task<Product> Create<T>(ProductInputModel model)
        {
            var product = new Product() { Name = model.Name, CategoryId = model.CategoryId, Description = model.Description, ImageUrl = model.ImageUrl, Price = model.Price, Weight = model.Weight };

            await this.repository.AddAsync(product);
            await this.repository.SaveChangesAsync();

            return product;
        }

        public async Task Delete(int productId)
        {
            var product = this.repository.All().Where(x => x.Id == productId).FirstOrDefault();

            if (product == null)
            {
                return;
            }

            this.repository.Delete(product);
            await this.repository.SaveChangesAsync();
        }

        public async Task Update(int productId)
        {
            var product = this.repository.All().Where(x => x.Id == productId).FirstOrDefault();
            if (product == null)
            {
                return;
            }

            this.repository.Update(product);
            await this.repository.SaveChangesAsync();
        }
    }
}
