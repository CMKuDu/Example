namespace WebTest.Domain.IRepository
{
    public interface IGenerateRepositoy<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByStringId(string name);
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);


    }
}
