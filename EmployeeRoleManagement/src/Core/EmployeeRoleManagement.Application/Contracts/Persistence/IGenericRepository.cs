using System.Linq.Expressions;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(Guid id);
    Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAll();
    Task<bool> Exists(Guid id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}