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

        UnitOfWork unit;

        private Dish? newDish;
        private BindingListEx<Dish> dishes;
        private BindingListEx<DishRecipeView> recipes;

        public event UpdateState ObserverStateUpdated;

        public DishMenuController()
        {
            this.unit = new UnitOfWork();

            dishes = new BindingListEx<Dish>();
            recipes = new BindingListEx<DishRecipeView>();

            dishes.ListChanged += OnDishListChange;

        }
        public DishConstructorController BuildDishConstructorConstroller()
        {
            return new DishConstructorController(this.unit, this.newDish.Id);
        }

        public void CreatDish(String dishNaming, Double moneyPercentage, int? dishTypeId)
        {
            newDish = (new Dish
            {
                Naming = dishNaming,
                Cost = 0,
                DishTypeId = dishTypeId,
                Weight = 0
            });
            newDish = unit.Dishes.Add(newDish);
            DataExtractor.UpdateExistDishParam(newDish.Id, unit);
            dishes.Add(newDish);
        }
        public void DeleteDish(Dish dish)
        {
            if (!DataExtractor.ValidateDish(dish, unit))
            {
                unit.Recipes.Delete(newDish.Id);
                newDish = null;
            }
        }
        public void DeniedCreatDish()
        {
            DeleteDish(newDish);
        }
        public void OnDishListChange(object sender, ListChangedEventArgs args)
        {
            if (args.ListChangedType == ListChangedType.ItemAdded)
            {
                newDish = ((BindingListEx<Dish>)sender)[args.NewIndex];
        
                this.newDish = unit.Dishes.Add(newDish);
                unit.Save();
            }
        }

        public UnitOfWork Unit { get { return unit; } }
        public void OnSelectedDishId(int dishId)
        {
            UpdateRecipes(dishId);
        }
        public void UpdateRecipes(int DishId)
        {
            if (DishId == this.selectedDishId)
                return;

            recipes.Clear();
            recipes.AppendList(GetDishRecipeViews(DishId, unit));

            this.selectedDishId = DishId;
        }
        public void onUpdateState()
        {
            dishes.Clear();
            dishes.AppendList(GetDishes(unit));

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
            onUpdateState();
        }

        public void AddUpdateMember(IUpdateMember member)
        {
            throw new NotImplementedException();
        }
    }
}
