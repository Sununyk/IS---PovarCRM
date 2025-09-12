using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using PovarCRM.Models.Interfaces;
using PovarCRM.Models.Views;
using PovarCRM.Repositories.CommandsLogic;

namespace PovarCRM.UIelements
{
    class BoolBox
    {
        public bool Value { get; set; }
    }

    //Кастомный БиндингЛист с возможностью отключения обновлений
    public class BindingListEx<T> : BindingList<T> where T : class, ICloneable, ICopyable<T>
    {
        public BindingListEx() {}

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

        public delegate void ItemChanged(object sender, T oldItem, T newItem, ChangeNewOnOldItemCommand<T> historyCommand);
        public event ItemChanged ListItemChanged;
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
        //подписчик на DataGridView
        public void OnValueValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ChangedItem = (e.RowIndex, (T)this[e.RowIndex].Clone());      
        }

        public (int oldItemIndex, T? item) ChangedItem { get; private set; }

        private (int oldItemIndex, T? item) changedItem;
        private bool _suspend = false;
    }
    //############## COMMANDS ##############
    //Команда для изменения одного объекта на другой с возможностью отмены
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
