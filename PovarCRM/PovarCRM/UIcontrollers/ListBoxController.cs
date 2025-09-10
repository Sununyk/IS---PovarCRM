using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PovarCRM.Models;
using PovarCRM.Models.Interfaces;
using PovarCRM.Repositories.Interfaces;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;


namespace PovarCRM.UIcontrollers
{

    //Логическая оболочка над графическими элементами Combo and List boxes
    public class ListBoxController<TypeOfSet> : IListBoxController<TypeOfSet>
        where TypeOfSet : class, ISingleIdentityEntity, ICloneable, ICopyable<TypeOfSet>
    {

        public delegate void ItemsChanged(object sender, List<TypeOfSet> e);
        public delegate void ItemChanged(object sender, TypeOfSet e);
        public event ItemChanged? ItemAdded;
        public event ItemsChanged? ItemsAdded;
        public event ItemChanged? ItemDeleted;
        public event ItemsChanged? ItemsDeleted;


        private BindingListEx<TypeOfSet> _listBoxCollection;
        private BindingListEx<TypeOfSet> _comboBoxCollection;
        public ComboBox ComboBoxInputer { get; set; }
        public ListBox ListBoxContainer { get; set; }
        private Button _deleteButton;
        private Button _clearButton;



        public ListBoxController(ComboBox comboBox, ListBox listBox, Button deleteButton, Button clearButton)
        {
            _listBoxCollection = new BindingListEx<TypeOfSet>();
            _comboBoxCollection = new BindingListEx<TypeOfSet>();

            this.ComboBoxInputer = comboBox;
            this.ListBoxContainer = listBox;

            comboBox.DataSource = _comboBoxCollection;
            listBox.DataSource = _listBoxCollection;

            this.ComboBoxInputer.DisplayMember = "Naming";
            this.ListBoxContainer.DisplayMember = "Naming";

            this.ComboBoxInputer.SelectionChangeCommitted += onComboBoxSelectionChangeCommitted;
            this.ComboBoxInputer.KeyDown += onComboBoxKeyDown;

            _deleteButton = deleteButton;
            _clearButton = clearButton;
            //подписываемся на кнопки удаления и очищения
            _deleteButton.Click += this.onDeleteButton;
            _clearButton.Click += this.onClearButton;

            tuneButtonsOptions();
           //?? this.UpdateState();

        }
        public void AddFromComboBoxToListBox(TypeOfSet item)
        {

            _comboBoxCollection.Remove(item);
            _listBoxCollection.Add(item);
            ItemAdded?.Invoke(this, item);

            tuneButtonsOptions();
        }

        public void DeleteFromListBox()
        {
            List<TypeOfSet> items = this.ListBoxContainer.SelectedItems.Cast<TypeOfSet>().ToList();

            _comboBoxCollection.AppendList(items);
            _listBoxCollection.SuspendNotifications();
            foreach (var i in items)
            {
                _listBoxCollection.Remove(i);
            }
            _listBoxCollection.ResumeNotifications();
            if(items.Count < 2 && items.Count > 0)
            {
                TypeOfSet temp = items.First();
                ItemDeleted?.Invoke(this, temp);
                return;
            }

            tuneButtonsOptions();
            ItemsDeleted?.Invoke(this, items);
        }
       

        public void UpdateState()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                this.FillComboBoxCollection(unitOfWork);
            }
        }
        public void ClearComboBox()
        {
            throw new NotImplementedException();
        }
        public void ClearListBox()
        {
            List<TypeOfSet> tempList = _listBoxCollection.Cast<TypeOfSet>().ToList();
            _listBoxCollection.Clear();

            _comboBoxCollection.AppendList(tempList);
            this.ItemsDeleted?.Invoke(this, tempList);

            tuneButtonsOptions();
        }
        //Загрузка данных из репозитория    
        public void FillComboBoxCollection(UnitOfWork unitOfWork)
        {
            _comboBoxCollection.SuspendNotifications();
           
            IRepository<TypeOfSet> repos = (IRepository<TypeOfSet>)unitOfWork.GetRepository<TypeOfSet>();

            if (_comboBoxCollection.IsNullOrEmpty())
            {
                foreach (TypeOfSet item in repos.GetCollection())
                {
                    _comboBoxCollection.Add(item);
                }
            }
            else
            {
                foreach (TypeOfSet item in repos.GetCollection())
                {
                    if (_comboBoxCollection.Any(d => d.Id.Equals(item.Id)) 
                        || _listBoxCollection.Cast<TypeOfSet>().Any(d => d.Id.Equals(item.Id)))
                    {
                        continue;
                    }
                    _comboBoxCollection.Add(item);
                }
            }
            _comboBoxCollection.ResumeNotifications();

        }
        //подписчики ListBoxController подписываются через интерфейс IListBoxMember
        public void AddMember(IListBoxMember<TypeOfSet> listBoxMember)
        {
            this.ItemsDeleted += listBoxMember.ItemsDeletedOfListBox;
            this.ItemDeleted += listBoxMember.ItemDeletedOfListBox;
            this.ItemsAdded += listBoxMember.ItemsAddedToListBox;
            this.ItemAdded += listBoxMember.ItemAddedToListBox;
        }


        

        public void onDeleteButton(object? sender, EventArgs e)
        {
            this.DeleteFromListBox();
            tuneButtonsOptions();
        }

        public void onClearButton(object? sender, EventArgs e)
        {
            this.ClearListBox();
        }
        //Обработчик события добавления из Комбабокс при SelectionChangeCommitted
        public void onComboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.ComboBoxInputer.SelectedItem is TypeOfSet selected)
            {
                // безопасный перенос
                this.ComboBoxInputer.BeginInvoke(new Action(() =>
                {
                    this.AddFromComboBoxToListBox(selected);
                }));
            }
            
        }

        public void onComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ComboBoxInputer.SelectedItem is TypeOfSet selected)
                {
                    // безопасный перенос
                    this.ComboBoxInputer.BeginInvoke(new Action(() =>
                    {
                        this.AddFromComboBoxToListBox(selected);
                    }));
                }
            }
        }

        public void tuneButtonsOptions()
        {
            if(_listBoxCollection.Count > 0)
                _clearButton.Visible = true;
            else
                _clearButton.Visible = false;
        }

        //public void AddAllFromListBoxToComboBox()
        //{
        //    _comboBoxCollection.AppendList(_listBoxCollection.ToList());
        //    _listBoxCollection.Clear();
        //    ItemsDeleted?.Invoke(this, _listBoxCollection.ToList<TypeOfSet>());

        //    //this.ComboBoxInputer.Refresh();
        //    //this.ListBoxContainer.Refresh();
        //}
        //private void onComboBoxIndexChanged(object sender, EventArgs e)
        //{
        //    this.AddFromComboBoxToListBox((TypeOfSet)this.ComboBoxInputer.SelectedItem);
        //}
    }
}

