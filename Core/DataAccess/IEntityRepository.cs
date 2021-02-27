using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
                 // Generic Constraint
                // T değişkeni sadece class ipi referans tip olacak ve IEntity veya ondan türetilecek bir nesne olabilir
                // new() newlenebilir olmali
    public interface IEntityRepository <T> where T : class, IEntity, new () 
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //Cikan Ampulden Using komutunu eklemeyi unutmayalim
        T Get(Expression<Func<T, bool>> filter);  //istenen degerleri geri döndüren bir Get operasyonu yazmaliyiz
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}


