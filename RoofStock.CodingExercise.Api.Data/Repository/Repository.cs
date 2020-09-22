using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoofStock.CodingExercise.Api.Data.Database;

namespace RoofStock.CodingExercise.Api.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly PropertiesContext _propertyContext;

        public Repository(PropertiesContext propertyContext)
        {
            _propertyContext = propertyContext;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await _propertyContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public IQueryable<TEntity> Get()
        {
            try
            {
                return _propertyContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _propertyContext.AddAsync(entity);
                await _propertyContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _propertyContext.Update(entity);
                await _propertyContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entities must not be null");
            }

            try
            {
                _propertyContext.UpdateRange(entities);
                await _propertyContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entities)} could not be updated");
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {
                var e = _propertyContext.Remove(entity);
                await _propertyContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be removed");
            }
        }
    }
}
