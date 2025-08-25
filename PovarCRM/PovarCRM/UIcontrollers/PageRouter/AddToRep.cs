using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Repositories.Abstracts;
using PovarCRM.Repositories.Interfaces;

namespace PovarCRM.UIcontrollers.PageRouter
{
    internal class AddToRep<T> : ICommand where T : class
    {
        T[] items;
        public AddToRep(params T[] obj)
        {
            using (var unit = new UnitOfWork())
            {
                unit.GetRepository<T>();
            }
            items = obj;
        }

        public void Execute()
        {
            using (var unit = new UnitOfWork())
            {
                IRepository<T> repos = unit.GetRepository<T>();
                repos.Insert(items);
            }
        }

        public void Undo()
        {
            using (var unit = new UnitOfWork())
            {
                IRepository<T> repos = unit.GetRepository<T>();
                repos.Delete(items);
            }
        }
    }
}
