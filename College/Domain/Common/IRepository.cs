namespace Domain.Common;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Identifier id);
    Task<bool> ExistsAsync(Identifier id);
    void AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
}
