namespace ElisStore.Services.Data
{
    using System.Threading.Tasks;

    using ElisStore.Data.Models;

    public interface ICategoryService : IBaseService
    {
        Task<Category> Create<T>(string name, string description);

        Task Update(int categoryId);

        Task Delete(int categoryId);
    }
}
