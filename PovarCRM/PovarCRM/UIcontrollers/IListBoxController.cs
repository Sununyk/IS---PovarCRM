using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PovarCRM.UIcontrollers
{
    internal interface IListBoxController<T>
    {
        //TitleType - тип коллекции элемента ComboBox
        void AddFromComboBoxToListBox(T item);
        void DeleteFromListBox();
        void ClearComboBox();
        void ClearListBox();
        void UpdateState();
        System.Windows.Forms.ComboBox ComboBoxInputer{get;set;}
        ListBox ListBoxContainer { get; set; }
        void onDeleteButton(object? sender,  EventArgs e);
        void onClearButton(object? sender, EventArgs e);
        void onComboBoxSelectionChangeCommitted(object sender, EventArgs e);
        //Обработка Enter для ComboBox
        void onComboBoxKeyDown(object sender, KeyEventArgs e);
        void tuneButtonsOptions();
        void FillComboBoxCollection(UnitOfWork unitOfWork);

    }
}
