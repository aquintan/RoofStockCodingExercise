using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoofStock.CodingExercise.Api.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAllAsync();

        public IQueryable<TEntity> Get();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(List<TEntity> entities);

        Task<TEntity> DeleteAsync(TEntity entity);
    }
}