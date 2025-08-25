using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.UIcontrollers.PageRouter
{
    internal class UpdateInRep<T> : ICommand where T : class
    {
        T[] oldItems;
        T[] newItems;
        public UpdateInRep(params T[] items) {
            if (items == null) {
                throw new ArgumentNullException();
            }
            var u = new UnitOfWork().GetRepository<T>();
            this.newItems = items;

        }

        public void Execute()
        {
            using (var u = new UnitOfWork())
            {
                u.GetRepository<T>().Update(newItems);
            }
        }

        public void Undo()
        {
            using (var u = new UnitOfWork())
            {
                u.GetRepository<T>().Update(oldItems);
            }
        }
    }
}
