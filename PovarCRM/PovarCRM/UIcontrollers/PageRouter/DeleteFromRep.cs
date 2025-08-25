using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.UIcontrollers.PageRouter
{
    internal class DeleteFromRep<T> : ICommand where T : class
    {
        T item;
        public DeleteFromRep(T item){
            this.item = item;
            var u = new UnitOfWork().GetRepository<T>();
        }

        public void Execute()
        {
            using (var u = new UnitOfWork()) { 
                u.GetRepository<T>().Delete(item);
            }
        }

        public void Undo()
        {
            using (var u = new UnitOfWork()) {
                u.GetRepository<T>().Insert(item);
            }
        }
    }
}
