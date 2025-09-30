using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models.Interfaces;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.UIcontrollers.UImembers;

namespace PovarCRM.UIelements
{
    public class BindingListExUpCore<T> : BindingListEx<T> where T : class, ICloneable, ICopyable<T>
    {
        public BindingListExUpCore(IEnumerable<T> collection) : base(collection)
        {
        }
        public BindingListExUpCore() : base()
        {
        }
        protected override object AddNewCore()
        {
            T newItem = (T)Activator.CreateInstance(typeof(T));
            InsertItem(0, newItem);
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, 0));

            return newItem;
        }

    }
}
