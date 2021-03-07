namespace ElisStore.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using ElisStore.Data.Models;
    using ElisStore.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public CategoryViewModel()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
