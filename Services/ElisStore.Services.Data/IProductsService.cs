namespace ElisStore.Services.Data
{
    using System.Threading.Tasks;

    using ElisStore.Data.Models;
    using ElisStore.Web.ViewModels.Products;

    public interface IProductsService : IBaseService
    {
        Task<Product> Create(ProductInputModel model);

        Task Update(int productId);

        Task Delete(int productId);
    }
}
