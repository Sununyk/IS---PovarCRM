using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using PovarCRM.Repositories;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;

namespace PovarCRM.UIcontrollers
{
    public class DishConstructorController : UpdateObserver
    {
        //public void OnListChanged(object sender, ListChangedEventArgs args)
        //{
        //    if(args.ListChangedType == ListChangedType.ItemAdded || args.ListChangedType == ListChangedType.ItemChanged)
        //    {
        //        var newRecipeView = ((BindingListEx<DishRecipeView>)sender)[args.NewIndex];
        //        var newRecipe = new Recipe
        //        {
        //            DishId = this.creatingDish.Id,
        //            DishProductId = newRecipeView.DishProductId,
        //            CountOfUnits = newRecipeView.CountOfUnits
        //        };
        //        //Автозаполнение свойств
        //        if(newRecipeView.DishProductNaming != null)
        //        {
        //            var dishProduct = unit.DishProducts.GetCollection().FirstOrDefault(dp => dp.Naming == newRecipeView.DishProductNaming);
        //            if (dishProduct != null)
        //            {
        //                newRecipe.DishProductId = dishProduct.Id;
        //                newRecipe.DishProduct = dishProduct;

        //                newRecipeView.UnitNaming = dishProduct.Unit?.Naming;
        //                newRecipeView.Weight = newRecipe.CountOfUnits * (float)dishProduct.Weight;
        //            }
        //        }

        //        DataExtractor.UpdateExistDishParam(creatingDish.Id, unit);
        //        if (DataExtractor.ValidateDishRecipe(newRecipe, unit))
        //        { 
        //            unit.Recipes.Add(newRecipe);
        //        }
        //        //DataExtractor.Sync<DishRecipeView>.SyncRepositoryes(DataExtractor.GetDishRecipeViews(creatingDish.Id));
        //    }
        //    UpdateState();
        //}
        public void OnListChanged(object sender, ListChangedEventArgs args)
        {
            var list = (BindingListEx<DishRecipeView>)sender;

            if (args.ListChangedType == ListChangedType.ItemAdded || args.ListChangedType == ListChangedType.ItemChanged)
            {
                var newRecipeView = list[args.NewIndex];
                var newRecipe = new Recipe
                {
                    DishId = this.creatingDish.Id,
                    DishProductId = newRecipeView.DishProductId,
                    CountOfUnits = newRecipeView.CountOfUnits
                };

                if (newRecipeView.DishProductNaming != null)
                {
                    var dishProduct = unit.DishProducts.GetCollection().FirstOrDefault(dp => dp.Naming == newRecipeView.DishProductNaming);
                    if (dishProduct != null)
                    {
                        newRecipe.DishProductId = dishProduct.Id;
                        newRecipe.DishProduct = dishProduct;

                        newRecipeView.UnitNaming = dishProduct.Unit?.Naming;
                        newRecipeView.Weight = newRecipe.CountOfUnits * (float)dishProduct.Weight;
                    }
                }

                DataExtractor.UpdateExistDishParam(creatingDish.Id, unit);

                if (DataExtractor.ValidateDishRecipe(newRecipe, unit))
                {
                    unit.Recipes.Add(newRecipe);
                    
                }
            }
            else if (args.ListChangedType == ListChangedType.ItemDeleted)
            {
                // Удаляем Recipe, который соответствует удалённой строке
                // args.NewIndex = -1, поэтому нужно хранить сопоставление или искать по DishProductId
                var deletedRecipe = unit.Recipes.GetCollection()
                    .FirstOrDefault(r => !list.Any(v => v.DishProductId == r.DishProductId && r.DishId == creatingDish.Id));
                if (deletedRecipe != null)
                {
                    unit.Recipes.Delete(deletedRecipe);
                    
                }
            }

            UpdateState();
        }

        public DishConstructorController(UnitOfWork unit, int dishId) {
            this.unit = unit;

            recipeViews = new BindingListEx<DishRecipeView>(DataExtractor.GetDishRecipeViews(dishId, unit));
            units = new BindingListEx<Unit>(unit.Units.GetCollection().ToList());
            dishProducts = new BindingListEx<DishProduct>(unit.DishProducts.GetCollection().ToList());

            recipeViews.ListChanged += OnListChanged;

            creatingDish = unit.Dishes.GetByID(dishId);
        }

        public (BindingListEx<DishRecipeView> recipeViews,
            BindingListEx<Unit> Units,
            BindingListEx<DishProduct> Products,
            Dish newDish
            ) InitData()
        {
            return ( recipeViews, units,dishProducts, creatingDish);
        }
        Dish? creatingDish;
        BindingListEx<DishRecipeView> recipeViews;
        BindingListEx<Unit> units;
        BindingListEx<DishProduct> dishProducts;

        UnitOfWork unit;
    }
}
