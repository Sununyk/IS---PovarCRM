select OrderCheck.Id, DishProduct.Naming, SUM(Recipes.CountOfUnits), Unit.Naming from OrderCheck
inner join Items on Items.OrderCheckId = OrderCheck.Id
inner join Dish on Dish.Id = Items.DishId
inner join Recipes on Recipes.DishId = Dish.Id
inner join DishProduct on DishProduct.Id = Recipes.DishProductId
inner join Unit on Unit.Id = DishProduct.UnitId
where OrderCheck.Id = 1
GROUP BY OrderCheck.Id, DishProduct.Naming, Unit.Naming


insert into Items(Items.DishCount, Items.DishId, Items.OrderCheckId)
values (1, 3, 1);