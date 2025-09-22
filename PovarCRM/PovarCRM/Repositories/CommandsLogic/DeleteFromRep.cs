using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models.Interfaces;
using PovarCRM.Repositories.Abstracts;

namespace PovarCRM.Repositories.CommandsLogic
{
    internal class DeleteFromRep<T> : ICommand where T : class, ICopyable<T>, ICloneable
    {
        T[] item;
        DefaultRepository<T> repository;
        public DeleteFromRep(UnitOfWork unit, params T[] item){
            repository = (DefaultRepository<T>)unit.GetRepository<T>();
            this.item = item;
            var u = new UnitOfWork().GetRepository<T>();
        }

        public void Execute()
        {
            repository.Delete(item);
        }

        public void Undo()
        {
            repository.AddRange(item);
        }
    }
}
