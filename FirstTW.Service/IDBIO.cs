using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTW.Service
{
    interface IDBIO<TEntity>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllWithConditional(Expression<Func<TEntity, bool>> expression);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(string id);
        TEntity GetById(string id);
    }
}
