using Microsoft.EntityFrameworkCore;
using PovarCRM.Models.Interfaces;
using PovarCRM.Repositories.Interfaces;

namespace PovarCRM.Repositories.Abstracts
{
    public abstract class DefaultRepository<T> : IRepository<T> where T : class, ICopyable<T>
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
        public virtual void AddRange(IEnumerable<T> entities)
        {
            Console.WriteLine(entities);

            if (entities is IEnumerable<ISingleIdentityEntity> listEntity)
            {
                foreach (var entity in listEntity)
                {
                    if (this.GetByID(entity.Id) != null)
                        Update((T)entity);
                    else
                        DbContext.Set<T>().Add((T)entity);
                }
            }
            else if (entities is IEnumerable<IIdentityEntity> list)
            {
                foreach (var entity in list)
                {
                    if (this.GetByID(entity.Id) != null)
                        Update((T)entity);
                    else
                        DbContext.Set<T>().Add((T)entity);
                }
            }
            DbContext.SaveChanges();

        }
        public virtual void Add(T entity)
        {
            if (entity is ISingleIdentityEntity singleEntity)
            {
                var existing = this.GetByID(singleEntity.Id);
                if (existing != null)
                    Update(entity);
                else
                    DbContext.Set<T>().Add(entity);
            }
            else if (entity is IIdentityEntity identityEntity)
            {
                var existing = this.GetByID(identityEntity.Id);
                if (existing != null)
                    Update(entity);
                else
                    DbContext.Set<T>().Add(entity);
            }

            DbContext.SaveChanges();
        }
        public virtual T GetByID(params int[] id)
        {
            if (id == null)
                return null;

            if (!DbContext.Set<T>().Any())
            {
                Console.WriteLine("(\"DB is empty\"); typeof = " + typeof(T).ToString());
                return null;
            }

            T? a;
            if (id.Length == 1)
                a = DbContext.Set<T>().Find(id[0]);
            else
            {
                object[] keyValues = id.Cast<object>().ToArray();
                a = DbContext.Set<T>().Find(keyValues);
            }
            if (a == null)
            {
                return null;
            }
            else
                return a;
        }

        //public virtual T Insert(T obj)
        //{
        //    DbContext.Set<T>().Add(obj);
        //    DbContext.SaveChanges();
        //    return obj;
        //}
        //public virtual void Insert(params T[] objs)
        //{
        //    foreach (T item in objs)
        //        DbContext.Set<T>().Add(item);
        //    DbContext.SaveChanges();
        //    return;
        //}

        public virtual void Update(T obj)
        {
            var z = DbContext.Entry(obj).State;
            T item = GetByID(Find(obj));
            if (item == null)
                return;
            //if(DbContext.Entry(item).State != EntityState.Detached)
            //{
            //    var i = DbContext.Entry(item).State;
            //}
            //else
            //{

            //}

            if (item != null)
                item.Copy(obj);

            //var j = DbContext.Entry(item).State;
            //z = DbContext.Entry(obj).State;
            DbContext.SaveChanges();
        }
        public virtual void Update(params T[] objs)
        {
            foreach (T item in objs)
                Update(item);
            DbContext.SaveChanges();
            return;
        }


        public virtual bool Delete(T obj)
        {
            var item = GetByID(Find(obj));
            if (item != null)
            {
                DbContext.Remove(item);
                return true;
            }
            return false;

        }
        public virtual bool Delete(params T[] objs)
        {
            foreach (T item in objs)
                if (!Delete(item))
                {
                    return false;
                }

            //if (objs.First() is IIdentityEntity)
            //{
            //    IIdentityEntity[] composEntities = (IIdentityEntity[])objs;
            //    foreach (IIdentityEntity item in composEntities)
            //    {
            //        flag = DbContext.Remove(;
            //        if (!flag)
            //            break;
            //    }

            //}
            //else if(objs.First() is ISingleIdentityEntity)
            //{
            //    ISingleIdentityEntity[] composEntities = (ISingleIdentityEntity[])objs;
            //    foreach (ISingleIdentityEntity item in composEntities)
            //    {
            //        flag = this.Delete(item.Id);
            //        if (!flag)
            //            break;
            //    }
            //}
            //else
            //{
            //    throw new Exception();
            //}

            DbContext.SaveChanges();
            return true;
        }
        //public virtual bool Delete(int objID)
        //{
        //    T? obj = GetByID(objID);
        //    if (obj == null) {
        //        DbContext.SaveChanges();
        //        return false;
        //    }else{
        //        DbContext.Set<T>().Remove(obj);
        //        DbContext.SaveChanges();
        //        return true;
        //    }
        //}

        //public bool Delete(int[] ids)
        //{
        //    T? obj = GetByID(ids);
        //    if (obj == null)
        //    {
        //        DbContext.SaveChanges();
        //        return false;
        //    }
        //    else
        //    {
        //        DbContext.Set<T>().Remove(obj);
        //        DbContext.SaveChanges();
        //        return true;
        //    }
        //}
        public virtual int[]? Find(T entity)
        {
            if (entity is ISingleIdentityEntity singleEntity)
            {
                var existing = GetByID(singleEntity.Id);
                if (existing != null)
                    return new int[1] { singleEntity.Id };
                else
                    return null;
            }
            else if (entity is IIdentityEntity identityEntity)
            {
                var existing = GetByID(identityEntity.Id);
                if (existing != null)
                    return identityEntity.Id;
                else
                    return null;
            }
            throw new Exception();
        }

        //public virtual IEnumerable<T> GetCollection()
        //{
        //    return this.DbContext.Set<T>().ToList();
        //}
    }
}
