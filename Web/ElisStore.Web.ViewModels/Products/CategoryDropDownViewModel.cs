namespace ElisStore.Web.ViewModels.Products
{
    using ElisStore.Data.Models;
    using ElisStore.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
