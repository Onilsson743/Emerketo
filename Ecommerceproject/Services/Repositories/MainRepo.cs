using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerceproject.Services.Repositories;

public abstract class MainRepo<TEntity> where TEntity : class
{
    private readonly DataContext _db;

    public MainRepo(DataContext db)
    {
        _db = db;
    }

    //Gets all object from the database 
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _db.Set<TEntity>().ToListAsync();
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _db.Set<TEntity>().Where(expression).ToListAsync();
    }


    //Gets one object from the database 
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var item = await _db.Set<TEntity>().FirstOrDefaultAsync(expression);
        return item!;
    }

    //Adds one object to the database 
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _db.Set<TEntity>().Add(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    //Updates an object in the database
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _db.Set<TEntity>().Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    //Removes an object from the database
    public virtual async Task<bool> RemoveAsync(TEntity entity)
    {
        try
        {
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        } catch{ };
        return false;


    }
}


