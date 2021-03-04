namespace ElisStore.Services.Data
{
    using System.Threading.Tasks;

    using ElisStore.Data.Models;

    public interface ICategoryService : IBaseService
    {
        Task<Category> Create<T>(string name, string description);

        Task Update(Category category);

        Task Delete(Category category);
    }
}
