using System.Linq.Expressions;
namespace MovieCrud.Entity
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<List<T>> ReadAllAsync();
        Task<List<T>> ReadAllAsync(Expression<Func<T, bool>> filter);
        Task<T> ReadAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
