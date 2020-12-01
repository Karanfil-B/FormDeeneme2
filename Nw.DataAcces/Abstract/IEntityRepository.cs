using Nw.Entitiess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Nw.Entitiess.Abstract;
using System.Threading.Tasks;

namespace Nw.DataAcces.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter );
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
