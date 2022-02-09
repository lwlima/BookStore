namespace BookStore.Domain.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> Get(int skip = 0, int take = 25);
        Task<T> GetById(int? id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int? id);
    }
}
