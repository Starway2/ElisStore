namespace ElisStore.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using ElisStore.Data.Common.Repositories;
    using ElisStore.Data.Models;
    using ElisStore.Services.Mapping;
    using ElisStore.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> repository;
        private readonly IHostingEnvironment webHost;

        public ProductsService(IDeletableEntityRepository<Product> repository, IHostingEnvironment webHost)
        {
            this.repository = repository;
            this.webHost = webHost;
        }

        public ICollection<T> GetAll<T>() => this.repository.All().To<T>().ToList();

        public T GetById<T>(int id) => this.repository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

        public T GetByName<T>(string name) => this.repository.All().Where(x => x.Name == name).To<T>().FirstOrDefault();

        public async Task<Product> Create(ProductInputModel model)
        {
            string uniqueImageName = string.Empty;

            if (model.Image == null)
            {
                uniqueImageName = "./images/image-not-found.png";
            }
            else
            {
                uniqueImageName = this.GenerateUniqueName(model.Image, model.CategoryId);
                await this.UploadImage(model.Image, uniqueImageName);
            }

            var product = new Product() { Name = model.Name, CategoryId = model.CategoryId, Description = model.Description, ImageUrl = $"./images/products/{uniqueImageName}", Price = model.Price, Weight = model.Weight };

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

        private string GenerateUniqueName(IFormFile file, int id) => $"{Guid.NewGuid()}_{id}_{file.FileName}";

        private async Task UploadImage(IFormFile file, string fileName)
        {
            string rootPath = this.webHost.WebRootPath;
            string uploadsFolder = Path.Combine(rootPath, "images", "products");
            Directory.CreateDirectory(uploadsFolder);

            string filePath = Path.Combine(uploadsFolder, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }
    }
}
