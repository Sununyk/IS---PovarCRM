using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PovarCRM.Models.Interfaces;
using PovarCRM.Repositories.Abstracts;
using PovarCRM.Repositories.Interfaces;

namespace PovarCRM.Repositories.CommandsLogic
{
    internal class UpdateInRep<T> : ICommand where T : class, ICopyable<T>, ICloneable
    {
        List<T> oldItems = new List<T>();
        List<T> newItems = new List<T>();
        DefaultRepository<T> repository;
        public UpdateInRep(UnitOfWork unit, params T[] items) {
            repository = (DefaultRepository<T>)unit.GetRepository<T>();

            if (items == null) {
                throw new ArgumentNullException();
            }   
            newItems.AddRange(items);

        }

        public void Execute()
        {
            foreach(var t in newItems)
            {
                int[] ids = repository.Find(t);
                if (ids == null)
                    repository.Add(t);
                else {
                    
                    oldItems.Append(repository.GetByID(repository.Find(t)).Clone());
                    repository.Update(t);

                }
            }
        }

        public void Undo()
        {
            foreach(var i in oldItems)
                repository.Update(i);

        }
    }
}
