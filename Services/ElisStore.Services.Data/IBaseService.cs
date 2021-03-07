namespace ElisStore.Services.Data
{
    using System.Collections.Generic;

    public interface IBaseService
    {
        ICollection<T> GetAll<T>();

        T GetById<T>(int id);

        T GetByName<T>(string name);
    }
}
