using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.UIcontrollers
{
    //Кастомный БиндингЛист с возможностью отключения обновлений
    public class BindingListEx<T> : BindingList<T>
    {
        private bool _suspend = false;

        public void SuspendNotifications() => _suspend = true;
        public void ResumeNotifications()
        {
            _suspend = false;
            this.ResetBindings();
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (!_suspend)
                base.OnListChanged(e);
        }

        public void AppendList(List<T> list)
        {
            SuspendNotifications();
            foreach (T item in list)
            {
                base.Add(item);
            }
            ResumeNotifications();
        }
    }
}
