using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PovarCRM.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetCollection();
        T GetByID(params int[] objID);
        void AddRange(IEnumerable<T> entities);
        void Add(T entity);
        bool Delete(params T[] objs);
        bool Delete(T obj);
        //bool Delete(int[] ids);
        //void Update(T obj);
        //void Update(params T[] objs);
    }
}
