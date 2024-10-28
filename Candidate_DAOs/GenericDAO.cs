using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Candidate_DAOs
{
    public  class GenericDAO<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        public GenericDAO (DbContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public TEntity GetById(string id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        public List<TEntity> GetAll() 
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity) 
        {   
            _dbContext.Set<TEntity>().Add(entity);    
            _dbContext.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(string id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }


    }
}
