﻿using Microsoft.EntityFrameworkCore;
using MovieCrud.Models;

namespace MovieCrud.Entity
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MovieContext context;

        public Repository(MovieContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> ReadAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> ReadAsync(int id)
        { 
            return await context.Set<T>().FindAsync(id);
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            context.Update(entity);
            await context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}