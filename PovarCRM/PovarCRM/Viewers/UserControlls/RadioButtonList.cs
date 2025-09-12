using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PovarCRM.Repositories.Interfaces;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;

namespace PovarCRM.Viewers.UserControls
{
    public partial class RadioButtonList : UserControl//, IUpdateObserver
    {
        public RadioButtonList()
        {
            InitializeComponent();

            //this.ObserverStateUpdated += this.onUpdateState;


        }

        public event UpdateState ObserverStateUpdated;

        public void InitDataSourse(List<object> list)
        {
            foreach (var item in list)
            {
                checkedListBox1.Items.Add(item, false); // false = не отмечен
            }
        }
        public delegate void SelectedIndexChangedEventHandler(object sender, int rowId);
        public event SelectedIndexChangedEventHandler SelectedRowIdChanged;
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(checkedListBox1.SelectedIndex >= 0)
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);

            int futureCount = checkedListBox1.CheckedItems.Count;
            if(futureCount == 0)
                SelectedRowIdChanged?.Invoke(this, -1);
            else
                SelectedRowIdChanged?.Invoke(this, checkedListBox1.SelectedIndex);


        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
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

        //public void onUpdateState()
        //{
            
        //}

        //public void AddUpdateMember(IUpdateMember member)
        //{
        //    this.ObserverStateUpdated += member.onUpdateState;
        //}

        //public void UpdateState()
        //{
        //   this.ObserverStateUpdated?.Invoke();
        //}
    }
}
