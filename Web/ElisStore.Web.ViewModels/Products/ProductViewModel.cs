namespace ElisStore.Web.ViewModels.Products
{
    using ElisStore.Data.Models;
    using ElisStore.Services.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
