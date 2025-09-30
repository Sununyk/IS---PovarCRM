using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models.Views;
using PovarCRM.Models;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;
using static PovarCRM.Repositories.DataExtractor;
using Microsoft.Identity.Client;
using System.ComponentModel;
using PovarCRM.Repositories;

namespace PovarCRM.UIcontrollers
{
    public class DishMenuController : IUpdateObserver
    {
        private int selectedDishId = -1;
        private Dish selectedDish;

        UnitOfWork unit;

        private Dish? newDish;
        private BindingListEx<Dish> dishes;
        private BindingListEx<DishRecipeView> recipes;

        public event UpdateState ObserverStateUpdated;

        public DishMenuController()
        {
            this.unit = new UnitOfWork();

            dishes = new BindingListExUpCore<Dish>();
            recipes = new BindingListEx<DishRecipeView>();

            dishes.ListChanged += OnDishListChange;
            dishes.ItemDeleted += (object obj, Dish item) => { DeleteDish(item); };

        }
        public DishConstructorController BuildDishConstructorConstrollerOnCreat()
        {
            if (newDish == null)
                return null;
            return new DishConstructorController(this.unit, this.newDish.Id);
        }
        public DishConstructorController BuildDishConstructorConstrollerOnUpdate()
        {
            if (selectedDishId >= 0)
                return new DishConstructorController(this.unit, this.selectedDish.Id);
            return null;
        }
        public void DeniedDishCreating()
        {

            if(this.DeleteDish(this.newDish))
                newDish = null;

            UpdateState();
        }
        public bool DeleteDish(Dish dish)
        {
            if (!DataExtractor.ValidateDish(dish, unit))
            {
                return unit.Dishes.Delete(dish.Id);
            }

            return false;
        }
        public bool DeleteDish(int dishId)
        {
            var dish = unit.Dishes.GetByID(dishId);
            if (dish == null)
            {
                this.UpdateState();
                return false;
            }
            if (!DataExtractor.ValidateDish(dish, unit))
            {
                return unit.Dishes.Delete(dish.Id);
            }

            return false;
        }
        //public void DeniedCreatDish()
        //{
        //    DeleteDish(newDish);
        //}
        public void OnDishListChange(object sender, ListChangedEventArgs args)
        {
            if (args.ListChangedType == ListChangedType.ItemAdded)
            {
                newDish = ((BindingListEx<Dish>)sender)[args.NewIndex];
        
                this.newDish = unit.Dishes.Add(newDish);
            }
        }

        public UnitOfWork Unit { get { return unit; } }
        public void OnSelectedDishId(int dishId)
        {
            UpdateRecipes(dishId);
        }
        public void SelectNewDish()
        {
            UpdateRecipes(this.newDish.Id);
        }
        public void UpdateRecipes(int DishId)
        {
            if (DishId <= 0)
                return;


            recipes.Clear();
            recipes.AppendList(GetDishRecipeViews(DishId, unit));

            this.selectedDishId = DishId;
            this.selectedDish = unit.Dishes.GetByID(DishId);
        }
        public void onUpdateState()
        {
            if (selectedDishId < 0)
                return;

            recipes.Clear();
            recipes.AppendList(GetDishRecipeViews(this.selectedDishId, unit));
            
        }

       
        public BindingListEx<DishRecipeView> initDishRecipeView()
        {
            return recipes;
        }
        public BindingListEx<Dish> initDishes()
        { 
            return dishes;
        }
        public List<DishType> initDishTypeList()
        {
            return unit.DishTypes.GetCollection().ToList();
        }

        public UnitOfWork GetUnitOfWork()
        {
            return this.unit;
        }

        public void UpdateState()
        {
            dishes.Clear();
            dishes.AppendList(GetDishes(unit));

            if (selectedDishId < 0)
                return;

            recipes.Clear();
            recipes.AppendList(GetDishRecipeViews(this.selectedDishId, unit));
        }

        public void AddUpdateMember(IUpdateMember member)
        {
            throw new NotImplementedException();
        }
    }
}
