using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.UIcontrollers.UImembers
{
    public interface IListBoxMember<T> where T : class, ISingleIdentityEntity
    {
        void ItemsAddedToListBox(object? obj, IList<T> items);
        void ItemAddedToListBox(object? obj, T item);

        void ItemsDeletedOfListBox(object? obj, IList<T> items);
        void ItemDeletedOfListBox(object? obj, T item); 
    }
}
