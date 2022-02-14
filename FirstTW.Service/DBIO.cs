using FirstTW.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTW.Service
{
    public abstract class DBIO<TEntity> : IDBIO<TEntity> where TEntity : class
    {
        ORCDbContext context = new ORCDbContext();

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetAllWithConditional(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().Where(expression).AsQueryable();
        }

        public TEntity GetById(string id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Delete(TEntity entity)
        {
            try
            {
                //var entity = GetById(id);
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
