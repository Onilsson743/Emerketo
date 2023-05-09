﻿using Ecommerceproject.Context;
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
        try
        {
            return await _db.Set<TEntity>().ToListAsync();
        }
        catch (Exception) { return null!; }
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _db.Set<TEntity>().Where(expression).ToListAsync();
        }
        catch (Exception) { return null!; }
    }


    //Gets one object from the database 
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var item = await _db.Set<TEntity>().FirstOrDefaultAsync(expression);
            return item!;
        }        
        catch (Exception) { return null!; }
    }

    //Adds one object to the database 
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            _db.Set<TEntity>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        catch (Exception) { return null!; }

    }

    //Updates an object in the database
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        try
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        catch (Exception) { return null!; }
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


