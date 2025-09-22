using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PovarCRM.Models.Interfaces;
using PovarCRM.Models.Views;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.UIcontrollers.UImembers;

namespace PovarCRM.UIelements
{
    class BoolBox
    {
        public bool Value { get; set; }
    }

    //Кастомный БиндингЛист с возможностью отключения обновлений
    public class BindingListEx<T> : BindingList<T>, IUpdateObserver where T : class, ICloneable, ICopyable<T>
    {
        public delegate void ItemChanged(object sender, T oldItem, T newItem, ChangeNewOnOldItemCommand<T> historyCommand);
        public delegate void FilterChanged(object sender, ICommand viewCommand, Func<T, bool> filter);
        
        public event CommandEventHandler CommandReadyToExec; 
        public event ItemChanged ListItemChanged;
        public event UpdateState ObserverStateUpdated;

        public BindingListEx() : base() { }
        public BindingListEx(IEnumerable<T> collection) : base(new List<T>(collection))
        {
            allItems = new List<T>(collection);
        }
        public void ApplyFilter(Func<T, bool>? filter)
        {
            if (filter == null)
                filter = (T t) => { return true; };
            else
                this.CurrenFilter = filter;
        }
        public void ResetFilter()
        {
            SuspendNotifications();
            base.ClearItems();

            foreach (var item in allItems)
            {
                if (currentFilter(item))
                    base.Add(item);

            }
            ResumeNotifications();
            this.UpdateState();
        }
        protected override void InsertItem(int index, T item)
        {
            if (!allItems.Any(x => x.Equals(item)))
                allItems.Add(item);

            if (currentFilter == null || currentFilter(item))
                base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            allItems.Remove(item);
            base.RemoveItem(index);
        }
        //protected override object AddNewCore()
        //{
        //    T newItem = (T)Activator.CreateInstance(typeof(T));
        //    InsertItem(0, newItem);
        //    OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, 0));

        //    return newItem;
        //}
        public int GetOldItemIndex()
        {
            return changedItem.oldItemIndex;
        }

        public void SuspendNotifications() => _suspend = true;

        public void ResumeNotifications()
        {
            _suspend = false;
            base.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        public void AppendList(List<T> list)
        {
            SuspendNotifications();
            foreach (T item in list)
            {
                Add(item);
            }
            ResumeNotifications();
        }


        public void OnViewCommandPackToExec(object obj, ICommand command)
        {
            CommandReadyToExec?.Invoke(this, command);
        }
        //при изменении элемента коллекции
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (_suspend)
                return;
            //если изменился элемент, и его индекс совпадает с индексом старого элемента
            if (e.OldIndex == ChangedItem.oldItemIndex && ChangedItem.oldItemIndex > -1 && ChangedItem.item != null)
            {
                ChangedItem = (-1, ChangedItem.item);
                ListItemChanged?.Invoke(this, ChangedItem.item, this[e.NewIndex], new ChangeNewOnOldItemCommand<T>(
                    ChangedItem.item, 
                    this[e.NewIndex],
                    this
                ));

            }
 
            base.OnListChanged(e);
                
        }
        public void OnFilterChange(object obj, ICommand viewCommand, Func<T, bool> filter)
        {
            this.ApplyFilter(filter);
            CommandPackage commandPackage = new CommandPackage();
            commandPackage.AddCommand(viewCommand);
            commandPackage.AddCommand(new FilterChangeCommand<T>(currentFilter, filter, this));
            CommandReadyToExec?.Invoke(this, commandPackage);

        }
        //событийная херня
        public void UpdateState()
        {
            this.ObserverStateUpdated?.Invoke();
        }
        public void onUpdateState()
        {
            UpdateState();
        }
        public void AddUpdateMember(IUpdateMember member)
        {
            this.ObserverStateUpdated += member.onUpdateState;
        }


        //подписчик на DataGridView
        public void OnValueValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ChangedItem = (e.RowIndex, (T)this[e.RowIndex].Clone());      
        }
        //событийная вещь
        public (int oldItemIndex, T? item) ChangedItem { get; private set; }
       
        private (int oldItemIndex, T? item) changedItem;
        private bool _suspend = false;
        //логика фильтрации
        private List<T> allItems = new List<T>();
        //фильтр
        public Func<T, bool>? CurrenFilter { get { return currentFilter; } set { currentFilter = value; } }
        private Func<T, bool>? currentFilter = (T t) => { return true; };
    }



    //############## COMMANDS ##############
    //Команда для изменения одного объекта на другой с возможностью отмены
    public class FilterChangeCommand<T> : ICommand where T : class, ICopyable<T>, ICloneable
    {
        private BindingListEx<T> _list;
        private readonly Func<T, bool>? _oldFilter;
        private readonly Func<T, bool>? _newFilter;
        public FilterChangeCommand(Func<T, bool> oldfilter, Func<T, bool> newfilter, BindingListEx<T> list)
        {
            _oldFilter = oldfilter;
            _newFilter = newfilter;
            _list = list;
        }
        public void Execute()
        {
            _list.CurrenFilter = _newFilter;
            _list.ResetFilter();
        }
        public void Undo()
        {
            _list.CurrenFilter = _oldFilter;
            _list.ResetFilter();
        }
    }
public class ChangeNewOnOldItemCommand<T> : ICommand where T : class, ICloneable, ICopyable<T>
    {
        T? oldState;
        T? newState;
        bool exFlag = true;
        BindingListEx<T> list;
        public ChangeNewOnOldItemCommand(T oldState, T newState, BindingListEx<T> list)
        {
            this.list = list;
            //храним ссылкой только newState или newItem, так как мы его хотим обновлять
            this.oldState = (T?)oldState.Clone();
            this.newState = newState;

        }

        public void Execute()
        {
            //не выполнится если уже была совершена прямая операция

            if (!exFlag)
            {
                list.SuspendNotifications();
                T temp = (T)newState.Clone();
                newState.Copy((T)oldState);
                oldState = temp;
                list.ResumeNotifications();
            }
        }
        public void Undo()
        {
            list.SuspendNotifications();
            T temp = (T)newState.Clone();
            newState.Copy((T)oldState);
            oldState = temp;

            this.exFlag = false;
            list.ResumeNotifications();
        }
    }
}
