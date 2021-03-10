namespace ElisStore.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElisStore.Data.Common.Repositories;
    using ElisStore.Data.Models;
    using ElisStore.Services.Mapping;

    public class CategoryService : ICategoryService
    {
        private IDeletableEntityRepository<Category> repository;

        public CategoryService(IDeletableEntityRepository<Category> repository)
        {
            this.repository = repository;
        }

        public ICollection<T> GetAll<T>() => this.repository.All().To<T>().ToList();

        public T GetById<T>(int id) => this.repository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

        public async Task<Category> Create<T>(string name, string description)
        {
            var category = new Category() { Name = name, Description = description };

            await this.repository.AddAsync(category);
            await this.repository.SaveChangesAsync();

            return category;
        }

        public async Task Update(int categoryId)
        {
            var category = this.repository.All().Where(x => x.Id == categoryId).FirstOrDefault();
            this.repository.Update(category);
            await this.repository.SaveChangesAsync();
        }

        public async Task Delete(int categoryId)
        {
            var category = this.repository.All().Where(x => x.Id == categoryId).FirstOrDefault();
            this.repository.Delete(category);
            await this.repository.SaveChangesAsync();
        }

        public T GetByName<T>(string name) => this.repository.All().Where(x => x.Name == name).To<T>().FirstOrDefault();
    }
}
