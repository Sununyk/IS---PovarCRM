using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.BusinessLogic.interfaces
{
    internal interface IUpdateBindingListByList<T> where T : class
    {
        public void UpdateBindingList(BindingList<T> binList, List<T> list)
        {
            binList.Clear();
            foreach(T i in list)
            {
                binList.Add(i);
            }
        }
    }
}
