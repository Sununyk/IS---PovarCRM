using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models.Views;
using PovarCRM.Models;
using PovarCRM.Migrations;
using PovarCRM.Models.Interfaces;
using QuestPDF.Infrastructure;
using PovarCRM.Repositories.Abstracts;
using System.Runtime.CompilerServices;
using static QuestPDF.Helpers.Colors;

namespace PovarCRM.Repositories
{
    public static class DataExtractor
    {
        static public List<DishRecipeView> GetDishRecipeViews(int dishId)
        {
            using (var unit = new UnitOfWork())
            {
                var recipes = unit.Recipes.GetCollection();
                var units = unit.Units.GetCollection().ToList();
                var dishProducts = unit.DishProducts.GetCollection().ToList();
                var dishes = unit.Dishes.GetCollection().ToList();

                List<DishRecipeView> recipeViewList = new List<DishRecipeView>((
                    from d in dishes
                    where d.Id == dishId
                    join r in recipes on d.Id equals r.DishId
                    join p in dishProducts on r.DishProductId equals p.Id
                    join u in units on p.UnitId equals u.Id
                    select new DishRecipeView
                    {
                        DishProductNaming = p.Naming,
                        CountOfUnits = r.CountOfUnits,
                        UnitNaming = u.Naming,
                    }
                ).OrderBy(x => x.DishProductNaming));
                return recipeViewList;

            }
        }
        static public List<DishRecipeView> GetDishRecipeViews(int dishId, UnitOfWork unit)
        {
            var recipes = unit.Recipes.GetCollection();
            var units = unit.Units.GetCollection().ToList();
            var dishProducts = unit.DishProducts.GetCollection().ToList();
            var dishes = unit.Dishes.GetCollection().ToList();

            List<DishRecipeView> recipeViewList = new List<DishRecipeView>((
                from d in dishes
                where d.Id == dishId
                join r in recipes on d.Id equals r.DishId
                join p in dishProducts on r.DishProductId equals p.Id
                join u in units on p.UnitId equals u.Id
                select new DishRecipeView
                {
                    DishProductNaming = p.Naming,
                    CountOfUnits = r.CountOfUnits,
                    UnitNaming = u.Naming,
                    //Weight = r.CountOfUnits * (float)u.Weight
                }
            ).OrderBy(x => x.DishProductNaming));
            return recipeViewList;

        }
        static public List<DishView> GetDishViews()
        {
            using (var unit = new UnitOfWork())
            {
                var dishes = unit.Dishes.GetCollection();

                List<DishView> dishViews = new List<DishView>(from d in dishes
                                                              select new DishView
                                                              {
                                                                  Id = d.Id,
                                                                  Naming = d.Naming,
                                                                  Cost = d.Cost,
                                                                  Weight = d.Weight,
                                                                  Picked = false,
                                                              })
                                           .OrderBy(x => x.Naming)
                                           .ToList();
                return dishViews;

            }
        }
        static public List<DishView> GetDishViews(UnitOfWork unit)
        {
            var dishes = unit.Dishes.GetCollection();

            List<DishView> dishViews = new List<DishView>(from d in dishes
                                                          join dt in unit.DishTypes.GetCollection() on d.DishTypeId equals dt.Id
                                                          select new DishView
                                                          {
                                                              Id = d.Id,
                                                              Naming = d.Naming,
                                                              Cost = d.Cost,
                                                              Weight = d.Weight,
                                                              Picked = false,
                                                              Count = 0,
                                                              DishTypeId = d.DishTypeId
                                                          })
                                        .OrderBy(x => x.Naming)
                                        .ToList();
            return dishViews;
        }
        static public List<OrderCheckRecipeView> GetRecipeOfOrder(int orderId)
        {
            List<OrderCheckRecipeView> itemList = new List<OrderCheckRecipeView>();

            using (var unit = new UnitOfWork())
            {
                try
                {
                    var orderChecks = unit.OrderChecks.GetCollection().ToList();
                    var items = unit.Items.GetCollection().ToList();
                    var dishes = unit.Dishes.GetCollection().ToList();
                    var recipes = unit.Recipes.GetCollection().ToList();
                    var dishProducts = unit.DishProducts.GetCollection().ToList();
                    var units = unit.Units.GetCollection().ToList();

                    var result = (from oc in orderChecks
                                  join item in items on oc.Id equals item.OrderCheckId
                                  join dish in dishes on item.DishId equals dish.Id
                                  join recipe in recipes on dish.Id equals recipe.DishId
                                  join product in dishProducts on recipe.DishProductId equals product.Id
                                  join u in units on product.UnitId equals u.Id
                                  where oc.Id == orderId
                                  group recipe by new { ProductName = product.Naming, UnitName = u.Naming } into g
                                  select new OrderCheckRecipeView(
                                      g.Key.ProductName,
                                      g.Sum(x => x.CountOfUnits),
                                      g.Key.UnitName
                                  ))
                                  .OrderBy(x => x.Naming)
                                  .ToList();

                    return result;

                }
                catch (Exception ex)
                {
                    return new List<OrderCheckRecipeView>();
                }
            }
        }
        static public List<OrderCheckRecipeView> GetRecipeOfOrder(int orderId, UnitOfWork unit)
        {
            List<OrderCheckRecipeView> itemList = new List<OrderCheckRecipeView>();

            try
            {
                var orderChecks = unit.OrderChecks.GetCollection().ToList();
                var items = unit.Items.GetCollection().ToList();
                var dishes = unit.Dishes.GetCollection().ToList();
                var recipes = unit.Recipes.GetCollection().ToList();
                var dishProducts = unit.DishProducts.GetCollection().ToList();
                var units = unit.Units.GetCollection().ToList();

                var result = (from oc in orderChecks
                              join item in items on oc.Id equals item.OrderCheckId
                              join dish in dishes on item.DishId equals dish.Id
                              join recipe in recipes on dish.Id equals recipe.DishId
                              join product in dishProducts on recipe.DishProductId equals product.Id
                              join u in units on product.UnitId equals u.Id
                              where oc.Id == orderId
                              group recipe by new { ProductName = product.Naming, UnitName = u.Naming } into g
                              select new OrderCheckRecipeView(
                                  g.Key.ProductName,
                                  g.Sum(x => x.CountOfUnits),
                                  g.Key.UnitName
                              ))
                              .OrderBy(x => x.Naming)
                              .ToList();

                return result;

            }
            catch (Exception ex)
            {
                return new List<OrderCheckRecipeView>();

            }
        }
        static public List<ItemView> GetViewItemsOfOrder(int orderId)
        {
            List<ItemView> itemList = new List<ItemView>();

            using (var unit = new UnitOfWork())
            {
                try
                {
                    OrderCheck pickedOrder = unit.OrderChecks.GetByID(orderId);

                    // Материализуем коллекции в память
                    var allItems = unit.Items.GetCollection().ToList();
                    var allDishes = unit.Dishes.GetCollection().ToList();


                    itemList.AddRange((
                        from item in allItems
                        where item.OrderCheckId == orderId
                        join d in allDishes on item.DishId equals d.Id
                        select new ItemView
                        {
                            DishId = item.DishId,
                            DishNaming = d.Naming,
                            DishCount = item.DishCount,
                            ItemCost = d.Cost * item.DishCount,
                            DishWeight = d.Weight,
                        })
                        .OrderBy(x => x.DishNaming)
                    );
                }
                catch (Exception ex)
                {
                    return new List<ItemView>();
                }
            }
            return itemList;
        }
        static public List<ItemView> GetViewItemsOfOrder(int orderId, UnitOfWork unit)
        {
            List<ItemView> itemList = new List<ItemView>();

            try
            {

                OrderCheck pickedOrder = unit.OrderChecks.GetByID(orderId);

                // Материализуем коллекции в память
                var allItems = unit.Items.GetCollection().ToList();
                var allDishes = unit.Dishes.GetCollection().ToList();


                itemList.AddRange((
                    from item in allItems
                    where item.OrderCheckId == orderId
                    join d in allDishes on item.DishId equals d.Id
                    select new ItemView
                    {
                        DishId = item.DishId,
                        DishNaming = d.Naming,
                        DishCount = item.DishCount,
                        ItemCost = d.Cost * item.DishCount,
                        DishWeight = d.Weight,
                    })
                    .OrderBy(x => x.DishNaming)
                );
            }
            catch (Exception ex)
            {
                return new List<ItemView>();
            }
            return itemList;
        }

        static public List<OrderCheck> GetOrdersSortedByTime()
        {
            using (var unit = new UnitOfWork())
            {
                var list = unit.OrderChecks.GetCollection().ToList();
                list.Sort((x, y) => y.OrderTime.CompareTo(x.OrderTime));
                return list;
            }

        }
        static public List<OrderCheck> GetOrdersSortedByTime(UnitOfWork unit)
        {
            var list = unit.OrderChecks.GetCollection().ToList();
            list.Sort((x, y) => y.OrderTime.CompareTo(x.OrderTime));
            return list;
        }
        //Sorted by Naming
        static public List<DishType> GetDishTypes()
        {
            using (var unit = new UnitOfWork())
            {
                return unit.DishTypes.GetCollection().OrderBy(x => x.Naming).ToList();
            }
        }
        static public List<DishType> GetDishTypes(UnitOfWork unit)
        {
            return unit.DishTypes.GetCollection().OrderBy(x => x.Naming).ToList();
        }
        //UPDATE PARAMETERS #################################################################################################
        static public Dish? UpdateExistDishParam(int DishId, UnitOfWork unit)
        {
            Dish? dish = unit.Dishes.GetByID(DishId);
            if (dish == null)
                return null;

            List<Recipe> recipes = new List<Recipe>();
            recipes = (from i in unit.Recipes.GetCollection()
                      where i.DishId == DishId
                      select new Recipe
                      {
                          DishId = i.DishId,
                          CountOfUnits = i.CountOfUnits,
                          DishProductId = i.DishProductId
                      }).ToList();

            var aggregated = (from i in recipes
                              join j in unit.DishProducts.GetCollection() on i.DishProductId equals j.Id
                              join u in unit.Units.GetCollection() on j.UnitId equals u.Id
                              group new { i, j, u } by u.Naming into g
                              select new
                              {
                                  Weight = g.Sum(x => x.i.CountOfUnits * x.j.Weight),
                                  Total = g.Sum(x => (decimal)x.i.CountOfUnits * x.j.Cost)
                              }).ToList();

            // Суммируем по всем группам
            double totalWeight = aggregated.Sum(x => x.Weight);
            decimal totalCost = aggregated.Sum(x => x.Total) + aggregated.Sum(x => x.Total) * (decimal)dish.Markup;

            dish.Weight = (float)totalWeight;
            dish.Cost = totalCost;

            return dish;
        }

        static public OrderCheck? UpdateExistOrderCheckParam(int OrderCheckId, UnitOfWork unit)
        {
            OrderCheck? order = unit.OrderChecks.GetByID(OrderCheckId);
            if (order == null)
                return null;
            if (unit.Items.GetCollection().Count<Item>() < 1)
            {
                order.Total = 0;
                return order;
            }
            
            order.Total = (from i in unit.Items.GetCollection()
                             where i.OrderCheckId == OrderCheckId
                             join d in unit.Dishes.GetCollection() on i.DishId equals d.Id
                             select (i.DishCount * d.Cost))
                            .Sum();


            return order;
        }

        static public List<Dish> GetDishes(UnitOfWork unit)
        {
            return new List<Dish> (unit.Dishes.GetCollection());
        }



        //DataValidating Methods ##########################################################################################
        public static bool ValidateDishRecipe(Recipe recipe,  UnitOfWork unit)
        {
            if (recipe == null)
                return false;
            if(recipe is IIdentityEntity entity)
            {
                foreach(var id in entity.Id)
                {
                    if (id <= 0)
                        return false;
                }
            }

            return true;
        }
        public static bool ValidateEntity(object entity, UnitOfWork unit)
        {
            if(entity is DishProduct dishProduct)
            {
                return ValidateDishProduct(dishProduct, unit);
            }else if(entity is Dish dish)
            {
                return ValidateDish(dish, unit);
            }else if(entity is Recipe recipe)
            {
                return ValidateDishRecipe(recipe, unit);
            }
                return true;
        }
        public static bool ValidateDishProduct(DishProduct dishProduct, UnitOfWork unit)
        {
            if (dishProduct == null)
                return false;

            if (unit.DishProducts.GetCollection().FirstOrDefault(dp => dp.Naming == dishProduct.Naming) != null)
                return false;
            else
                return true;
        }


        public static bool ValidateDish(Dish dish, UnitOfWork unit)
        {
            if (dish == null)
                return false;

            if (dish is ISingleIdentityEntity newDish)
            {
                foreach (Dish item in unit.Dishes.GetCollection())
                {
                    if (item is ISingleIdentityEntity repDish)
                    {
                        if (newDish.Equals(repDish))
                            return false;
                    }
                }
            }            

            return true;
        }

        public static List<DishProductView> GetDishViewProduct(UnitOfWork unit)
        {
            return ((
                from dp in unit.DishProducts.GetCollection()
                join u in unit.Units.GetCollection() on dp.UnitId equals u.Id
                select new DishProductView { Cost = dp.Cost, UnitId = u.Id, UnitName = u.Naming, Id = dp.Id, Weight = dp.Weight, Naming = dp.Naming }
            ).ToList());

        }

        public class Sync<T> where T : class, ICloneable, ICopyable<T>
        {
            public static List<T> SyncRepositoryes(List<T> tempData)
            {
                using (var unit = new UnitOfWork())
                {
                    DefaultRepository<T> rep = (DefaultRepository<T>)unit.GetRepository<T>();

                    if (rep == null) throw new ArgumentNullException(nameof(rep));
                    if (tempData == null) throw new ArgumentNullException(nameof(tempData));

                    // Текущие элементы из репозитория
                    var items = rep.GetCollection().ToList();

                    // Добавление новых элементов
                    for (int i = 0; i < tempData.Count(); i++)
                    {
                        if (unit.GetRepository<T>().Find(tempData[i]) == null && DataExtractor.ValidateEntity(tempData[i], unit))
                        {
                            //сразу обновляем
                            tempData[i].Copy(rep.Add(tempData[i]));
                        }
                        else if (unit.GetRepository<T>().Find(tempData[i]) != null)
                        {
                            // Обновляем существующий элемент
                            rep.Update(tempData[i]);
                        }
                    }
                }
                using (var unit = new UnitOfWork())
                {
                    DefaultRepository<T> rep = (DefaultRepository<T>)unit.GetRepository<T>();
                    var toRemove = rep.GetCollection().ToList()
                        .Where(existing =>
                        {
                            if (existing is IIdentityEntity identExisting)
                            {
                                return !tempData.Any(temp => temp is IIdentityEntity identTemp && (identTemp.Id == identExisting.Id || identTemp.Id == default));
                            }
                            else if (existing is ISingleIdentityEntity singleExisting)
                            {
                                return !tempData.Any(temp => temp is ISingleIdentityEntity singleTemp && (singleTemp.Id == singleExisting.Id || singleTemp.Id == 0));
                            }
                            return false;
                        })
                        .ToList();

                    // Удаляем
                    foreach (var item in toRemove)
                    {
                        rep.Delete(item);
                    }

                    // Удаление элементов, которых нет в tempData

                    // Возвращаем актуальный список
                    return rep.GetCollection().ToList();
                }
                    
                
            }
        }




    }
}
