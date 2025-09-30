using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.UIcontrollers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Reflection.Metadata.Ecma335;
    using PovarCRM.BusinessLogic.OrderFilter;
    using PovarCRM.Models;
    using PovarCRM.UIcontrollers.UImembers;

    public interface IGetBindControllingList<T, P> where T : class
    {
        BindingList<T> GetBinControllingList { get; }
        void RefreshBinControllingListByParams(P parameters);
    }
    public class CheckListViewController: IGetBindControllingList<OrderCheck, CheckListFilterParams>, IListBoxMember<Dish>
    {
        private readonly OrderCheckListController _orderCheckListController;
        private readonly BindingList<OrderCheck> binList;
        private CheckListFilterParams _filterParams;
        public ListBoxController<Dish> _dishPicker;

        public CheckListViewController(OrderCheckListController orderCheckListController)
        {
            _orderCheckListController = orderCheckListController;
            _filterParams = new CheckListFilterParams();

            _orderCheckListController.setParameters(_filterParams);
            binList = _orderCheckListController.GetFilteredlList();



        }

        public BindingList<OrderCheck> GetBinControllingList => binList;

        public event EventHandler? FilterChanged;

        public void InitListBoxController(ListBox listBox, ComboBox comboBox, Button deleteButton, Button clearButton)
        {
            _dishPicker = new ListBoxController<Dish>(comboBox, listBox, deleteButton, clearButton);
            _dishPicker.AddMember(this);
            this.UpdateState();
        }
        public void RefreshBinControllingListByParams(CheckListFilterParams parameters)
        {
            _orderCheckListController.setParameters(parameters);
        }

        private void OnFilterChanged()
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);

            RefreshBinControllingListByParams(_filterParams);

        }
        public void UpdateState()
        {
            _dishPicker.UpdateState();
        }
        public void ItemsAddedToListBox(object? obj, IList<Dish> items)
        {
            _filterParams.RequiredExistingDishesID.AddRange(ConvFromDishToIdList(items));
            OnFilterChanged();
        }

        public void ItemAddedToListBox(object? obj, Dish item)
        {
            if(item == null)
            {
                return;
            }
            _filterParams.RequiredExistingDishesID.Add(item.Id);
            OnFilterChanged();
        }

        public void ItemsDeletedOfListBox(object? obj, IList<Dish> items)
        {
            _filterParams.RequiredExistingDishesID.RemoveAll(x => items.Any<Dish>(y => y.Id == x));
            OnFilterChanged();
        }

        public void ItemDeletedOfListBox(object? obj, Dish item)
        {
            _filterParams.RequiredExistingDishesID.Remove(item.Id);
            OnFilterChanged();
        }

        public CheckListFilterParams FilterParams => _filterParams;

        // Прокси-свойства:
        public DateTime StartDatePoint
        {
            get => _filterParams.StartDatePoint;
            set { _filterParams.StartDatePoint = value; OnFilterChanged(); }
        }

        public DateTime EndDatePoint
        {
            get => _filterParams.EndDatePoint;
            set { _filterParams.EndDatePoint = value; OnFilterChanged(); }
        }

        public string? ClientName
        {
            get => _filterParams.ClientName;
            set { _filterParams.ClientName = value; OnFilterChanged(); }
        }

        public int? CheckId
        {
            get => _filterParams.CheckId;
            set { _filterParams.CheckId = value; OnFilterChanged(); }
        }

        public List<int>? RequiredExistingDishID
        {
            get => _filterParams.RequiredExistingDishesID;
            set { _filterParams.RequiredExistingDishesID = value; OnFilterChanged(); }
        }

        public decimal LowerMoneyConstraint
        {
            get => _filterParams.LowerMoneyConstraint;
            set { _filterParams.LowerMoneyConstraint = value; OnFilterChanged(); }
        }

        public decimal HighestMoneyConstraint
        {
            get => _filterParams.HighestMoneyConstraint;
            set { _filterParams.HighestMoneyConstraint = value; OnFilterChanged(); }
        }

        public int LowerNumDishesConstraint
        {
            get => _filterParams.LowerNumDishesConstraint;
            set { _filterParams.LowerNumDishesConstraint = value; OnFilterChanged(); }
        }

        public int HighestNumDishesConstraint
        {
            get => _filterParams.HighestNumDishesConstraint;
            set { _filterParams.HighestNumDishesConstraint = value; OnFilterChanged(); }
        }

        public int LowerNumItemConstraint
        {
            get => _filterParams.LowerNumItemConstraint;
            set { _filterParams.LowerNumItemConstraint = value; OnFilterChanged(); }
        }

        public int HighestNumItemConstraint
        {
            get => _filterParams.HighestNumItemConstraint;
            set { _filterParams.HighestNumItemConstraint = value; OnFilterChanged(); }
        }

        static List<int> ConvFromDishToIdList(IList<Dish> dishList)
        {
            List<int> list = new List<int>();
            list = (from i in dishList
                    select i.Id
            ).ToList();

            return list;
        }
    }


}
