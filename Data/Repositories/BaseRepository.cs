using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    //CRUD Operations
    //Create
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not create entity", ex);
        }
    }

    //Read
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression));
        }
        return await _dbSet.AnyAsync(expression);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        return await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    //Update
    public async Task<TEntity> UpdateAsync(TEntity entity) //Full Update
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not update {nameof(TEntity)}", ex);
        }
    }

    public async Task<TEntity> PartialUpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity) //Selective Update
    {
        if (updatedEntity == null)
        {
            throw new ArgumentNullException(nameof(updatedEntity));
        }

        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
            if (entity == null)
            {
                return null!;
            }

            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not update {nameof(TEntity)}", ex);
        }
    }

    //Delete
    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
            if (entity == null)
            {
                return false;
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new($"Could not delete {nameof(TEntity)}", ex);
        }
    }
}