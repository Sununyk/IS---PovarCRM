using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Models.Interfaces;
using PovarCRM.Repositories.Abstracts;
using PovarCRM.Repositories.Interfaces;
using PovarCRM.UIcontrollers.UImembers;

namespace PovarCRM.Repositories.CommandsLogic
{
    internal class AddToRep<T> : ICommand where T : class, ICopyable<T>
    {
        T[] items;
        DefaultRepository<T> repository;
        public AddToRep(UnitOfWork unit,params T[] obj)
        {
            repository = (DefaultRepository<T>)unit.GetRepository<T>();
            items = obj;
        }

        public void Execute()
        {
            repository.AddRange(items);
            
        }
        public object GetAddedItemIds()
        {
            // если элементы - ISingleIdentityEntity
            if (typeof(ISingleIdentityEntity).IsAssignableFrom(items.First().GetType()))
            {
                var list = items.Cast<ISingleIdentityEntity>().ToList();
                int[] listId = list.Select(i => i.Id).ToArray();
                return listId;
            }
            // если элементы - IIdentityEntity
            else if (typeof(IIdentityEntity).IsAssignableFrom(items.First().GetType()))
            {
                var listItem = items.Cast<IIdentityEntity>().ToList();

                int rows = listItem.Count;
                int cols = listItem.First().Id.Length; // предполагаем, что Id = массив int[]

                int[,] listId = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        listId[i, j] = listItem[i].Id[j];
                    }
                }

                return listId;
            }
            else
            {
                throw new InvalidOperationException("Тип элементов items не поддерживается");
            }
        }

        public void Undo()
        {
             repository.Delete(items);
        }
    }
}
