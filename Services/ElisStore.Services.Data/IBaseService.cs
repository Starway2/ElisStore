namespace ElisStore.Services.Data
{
    using System.Collections.Generic;

    public interface IBaseService
    {
        ICollection<T> GetAll<T>();

        T GetById<T>(int Id);

        T GetByName<T>(string name);
    }
}
