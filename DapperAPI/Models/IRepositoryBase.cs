namespace DapperAPI.Models
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity, int id);
        Task DeleteAsync(int id);
    }
}