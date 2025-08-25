using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PovarCRM.Models;
using PovarCRM.Models.Interfaces;
using PovarCRM.Repositories.Interfaces;

namespace PovarCRM.Repositories.Abstracts
{
    public abstract class DefaultRepository<T> : IRepository<T> where T : class
    {
        internal DbContext DbContext { get; set; }

        public DefaultRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual IEnumerable<T> GetCollection()
        {
            return DbContext.Set<T>();
        }
        public virtual T GetByID(int id)
        {
            var a = DbContext.Set<T>().Find(id);
            if (a == null)
                throw new Exception("DB doesnt exist obj with id:" + id);
            else
                return a;
        }

        public virtual T Insert(T obj)
        {
            DbContext.Set<T>().Add(obj);
            return obj;
        }
        public virtual void Insert(params T[] objs)
        {
            foreach(T item in objs)
                DbContext.Set<T>().Add(item);
            return;
        }

        public virtual void Update(T obj)
        {
            DbContext.Set<T>().Update(obj);
        }
        public virtual void Update(params T[] objs)
        {
            foreach (T item in objs)
                DbContext.Set<T>().Update(item);
            return;
        }


        public virtual bool Delete(T obj)
        {
            if(obj is IComposEntity)
            {
               return this.Delete(((IComposEntity)obj).ids);
            }
            else
            {
                return this.Delete(((IIdentityEntity)obj).Id);
            }
        }
        public virtual bool Delete(params T[] objs)
        {
            bool flag = false;
            if (objs is IComposEntity)
            {
                IComposEntity[] composEntities = (IComposEntity[])objs;
                foreach (IComposEntity item in composEntities)
                {
                    flag = this.Delete(item.ids);
                    if (!flag)
                        break;
                }
                    
            }
            else
            {
                IIdentityEntity[] composEntities = (IIdentityEntity[])objs;
                foreach (IIdentityEntity item in composEntities)
                {
                    flag = this.Delete(item.Id);
                    if (!flag)
                        break;
                }
            }
            return flag;
        }
        public virtual bool Delete(int objID)
        {
            T? obj = DbContext.Set<T>().Find(objID);
            if (obj == null) {
                return false;
            }else{
                DbContext.Set<T>().Remove(obj);
                return true;
            }
        }

        public bool Delete(Vector<int> ids)
        {
            T? obj = DbContext.Set<T>().Find(ids);
            if (obj == null)
            {
                return false;
            }
            else
            {
                DbContext.Set<T>().Remove(obj);
                return true;
            }
        }
    }
}
