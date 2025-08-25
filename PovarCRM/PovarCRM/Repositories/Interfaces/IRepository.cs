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
        T GetByID(int objID);
        T Insert(T obj);
        void Insert(params T[] objs);
        bool Delete(int objID);
        bool Delete(params T[] objs);
        bool Delete(T obj);
        bool Delete(Vector<int> ids);
        void Update(T obj);
        void Update(params T[] objs);
    }
}
