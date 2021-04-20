using Application.Interfaces;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository.v1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ProductContext productContext;

        public Repository(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if(entity==null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            }
            try
            {
                await productContext.AddAsync(entity);
                await productContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be null saved:{ex.Message}");

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
                productContext.Remove(entity);
                await productContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be null deleted:{ex.Message}");

            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return productContext.Set<TEntity>();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"{nameof(GetById)} id must not be empty");

            }
            try
            {
                return await productContext.FindAsync<TEntity>(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
             
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");

            }
            try
            {
                 productContext.Update(entity);
                await productContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be update:{ex.Message}");

            }
        }
    }

}
