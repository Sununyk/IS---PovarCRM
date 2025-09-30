using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using PovarCRM.Models.Interfaces;
using PovarCRM.Repositories.Interfaces;

namespace PovarCRM.Repositories.Abstracts
{
    public abstract class DefaultRepository<T> : IRepository<T> where T : class, ICopyable<T>, ICloneable
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
            foreach (var entity in entities)
                this.Add(entity);

        }

        public T Add(T obj)
        {
            if (obj is not T ob)
                return null;

            T entity = (T)obj.Clone();

            if (entity is ISingleIdentityEntity singleEntity)
            {
                var existing = this.GetByID(singleEntity.Id);
                if (existing != null)
                    Update(entity);
                else
                {
                    singleEntity.Id = default(int);
                    DbContext.Set<T>().Add(entity);
                    DbContext.SaveChanges();
                }
            }
            else if (entity is IIdentityEntity identityEntity)
            {
                var existing = this.GetByID(identityEntity.Id);
                if (existing != null)
                    Update(entity);
                else
                {
                    
                    DbContext.Set<T>().Add(entity);
                    DbContext.SaveChanges();
                }

            }
            return entity;

        }
        public virtual T? GetByID(params int[] id)
        {
            if (id == null)
                 throw new ArgumentNullException("id");


            var local = DbContext.Set<T>()
                .Local
                .FirstOrDefault(e => e.Equals(id));
            if (local != null)
                return local;



            T? a;
            object[] keyValues = id.Cast<object>().ToArray();
            if (id.Length == 1)
            {
                a = DbContext.Set<T>().Find(keyValues);
                if (a == null)
                    a = DbContext.Set<T>().Local
                    .FirstOrDefault(e => (e as ISingleIdentityEntity)?.Id == id[0]);

            }
            else
            {
               
                a = DbContext.Set<T>().Find(keyValues);
                if (a == null)
                    a = DbContext.Set<T>().Local
                        .FirstOrDefault(e =>
                        {
                            if (e is IIdentityEntity identity)
                            {
                                return identity.Id.SequenceEqual(id); // сравнение ключей по значению
                            }
                            return false;
                        });
            }

            return a;
        }



        public virtual void Update(T obj)
        {
            var z = DbContext.Entry(obj).State;
            T item = GetByID(Find(obj));
            if (item == null)
                return;

            item.Copy(obj);
            //DbContext.Update(clone);
            DbContext.SaveChanges();

        }
        public virtual void Update(params T[] objs)
        {
            foreach (T item in objs)
                Update(item);
            return;
        }

        public virtual bool Delete(params int[] keys)
        {
            var item = GetByID(keys);
            if (item != null)
            {
                DbContext.Remove(item);
                DbContext.SaveChanges();
                return true;
            }
            DbContext.SaveChanges();
            return false;

        }
        public virtual bool Delete(T obj)
        {
            var item = GetByID(Find(obj));
            if (item != null)
            {
                DbContext.Remove(item);
                DbContext.SaveChanges();
                return true;
            }
            DbContext.SaveChanges();
            return false;

        }
        public virtual bool Delete(params T[] objs)
        {
            foreach (T item in objs)
                if (!Delete(item))
                {
                    return false;
                }
            return true;
        }
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

        public void Clear()
        {
            foreach(T item in DbContext.Set<T>())
            {
                this.Delete(item);
            }
        }
    }
}
