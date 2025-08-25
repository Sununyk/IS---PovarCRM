using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.BusinessLogic.interfaces;
using PovarCRM.Models;

namespace PovarCRM.BusinessLogic
{
    public interface IFiltBinListByParams<T, P>
    {
        void setParameters(P parameters);
         BindingList<T> GetFilteredlList();

    }
    
    public class OrderCheckListController : IUpdateBindingListByList<OrderCheck>, IFiltBinListByParams<OrderCheck, CheckListFilterParams>
    {
        //private List<OrderCheck> orderCheckList;
        private BindingList<OrderCheck> binCheckList = new BindingList<OrderCheck>();
        private ICheckListCalculator calculator;
        private CheckListFilterParams param = new CheckListFilterParams();
        public OrderCheckListController(ICheckListCalculator calculator)
        {
            this.calculator = calculator;
            setParameters(param);
        }
        public void setParameters(CheckListFilterParams param)
        {
            this.param = param;
            this.CalculateFilterCheck();
        }
        private void CalculateFilterCheck()
        {
            ((IUpdateBindingListByList<OrderCheck>)this).UpdateBindingList(this.binCheckList, calculator.GetFilteredCheckList(this.param));
        }

        public BindingList<OrderCheck> GetFilteredlList()
        {
            return this.binCheckList;
        }
    }
}
