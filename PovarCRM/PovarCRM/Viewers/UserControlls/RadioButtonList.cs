using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PovarCRM.Models;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.Repositories.Interfaces;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;

namespace PovarCRM.Viewers.UserControls
{
    public partial class RadioButtonList : UserControl
    {

        public delegate void SelectedIndexChangedEventHandler(object sender, ICommand checkCommandChange, int rowId);
        public event SelectedIndexChangedEventHandler SelectedRowIdChanged;
        // Событие выбора
        public event EventHandler SelectedIndexChanged;

        public RadioButtonList()
        {
            InitializeComponent();
        }
        public void InitDataSourse(List<object> list)
        {
            foreach (var item in list)
            {
                checkedListBox1.Items.Add(item, false); // false = не отмечен
            }
        }

        // Запрещаем множественный выбор
        private void ListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != e.Index)
                        checkedListBox1.SetItemChecked(i, false);
                }

                SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //если дважды нажать, то по идее должен исчезать фильтр
            
            
            
            if (checkedListBox1.SelectedIndex == currentIndex.Index && currentIndexUnchecked)
            {
                oldIndex = currentIndex;
                currentIndex = (false, checkedListBox1.SelectedIndex);
                rowIndex = -1;
            }
            else
            {
                if (checkedListBox1.SelectedIndex >= 0)
                {
                    this.oldIndex = this.currentIndex;
                    this.currentIndex = (true, checkedListBox1.SelectedIndex);
                    rowIndex = (int)currentIndex.Index;
                }
            }
            SelectedRowIdChanged?.Invoke(
                this,
                new RadioButtonChangeIndexCommand(
                    currentIndex,
                    oldIndex,
                    this.checkedListBox1
                ),
                rowIndex
            );
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //int futureCount = checkedListBox1.CheckedItems.Count;
            
            
            if (e.NewValue == CheckState.Checked)
            {
                //checkedListBox1.SetItemChecked(e.Index, true);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != e.Index)
                        checkedListBox1.SetItemChecked(i, false);
                }

                // SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
                currentIndexUnchecked = false;
            }
            if (e.NewValue == CheckState.Unchecked)
                currentIndexUnchecked = true;

        }

        (bool AddOrRem, int? Index) currentIndex = (true, null);
        (bool AddOrRem, int? Index) oldIndex = (true, null);
        int rowIndex = -1;
        bool currentIndexUnchecked = false;
        //COMMAND

        public class RadioButtonChangeIndexCommand : ICommand
        {
            private CheckedListBox list;
            (bool AddOrRem, int? Index) newIndex;
            (bool AddOrRem, int? Index) oldIndex;
            public RadioButtonChangeIndexCommand((bool AddOrRem, int? Index) newindex, (bool AddOrRem, int? Index) oldindex, CheckedListBox list)
            {
                this.list = list;
                newIndex = newindex;
                oldIndex = oldindex;
            }

            public void Execute()
            {
                if (newIndex.Index == null)
                    return;

                list.SetItemChecked((int)newIndex.Index, newIndex.AddOrRem);
            }

            public void Undo()
            {
                if (newIndex.Index == null)
                    return;
                else if(oldIndex.Index == null)
                    list.SetItemChecked((int)newIndex.Index, false);
                else if (newIndex.AddOrRem && oldIndex.AddOrRem)
                {
                   list.SetItemChecked((int)oldIndex.Index, oldIndex.AddOrRem);
                }
                else if (!newIndex.AddOrRem)
                {
                    list.SetItemChecked((int)newIndex.Index, true);
                }
            }
        }
    }
}
