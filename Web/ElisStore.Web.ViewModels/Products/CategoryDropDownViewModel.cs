namespace ElisStore.Web.ViewModels.Products
{
    using ElisStore.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<ElisStore.Data.Models.Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
