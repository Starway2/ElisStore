﻿namespace ElisStore.Services.Data
{
    using System;
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

        public ICollection<T> GetById<T>(int categoryId) => this.repository.All().Where(x => x.Id == categoryId).To<T>().ToList();

        public async Task<Category> Create<T>(string name, string description)
        {
            var exist = this.repository.All().Where(x => x.Name == name).FirstOrDefault();

            if (exist != null) return exist;

            var category = new Category() { Name = name, Description = description };

            await this.repository.AddAsync(category);
            await this.repository.SaveChangesAsync();

            return category;
        }

        public async Task Update(Category category)
        {
            this.repository.Update(category);
            await this.repository.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            this.repository.Delete(category);
            await this.repository.SaveChangesAsync();
        }
    }
}