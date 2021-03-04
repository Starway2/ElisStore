namespace ElisStore.Services.Data
{
    using System.Collections.Generic;

    public interface IBaseService
    {
        ICollection<T> GetAll<T>();

        ICollection<T> GetById<T>(int categoryId);
    }
}
