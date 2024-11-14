using System.Linq.Expressions;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly EmployeeRoleManagementDbContext _context;

    public GenericRepository(EmployeeRoleManagementDbContext context)
    {
        _context = context;
    }
    
    public async Task<T?> Get(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<bool> Exists(Guid id)
    {
        var entity =  await Get(id);
        return entity != null;
    }

    public async Task<T> Add(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}