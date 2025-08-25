INSERT INTO Unit (Naming) VALUES 
('грамм'),
('килограмм'),
('литр'),
('миллилитр'),
('штука');

INSERT INTO DishType (Naming) VALUES
('Супы'),
('Салаты'),
('Горячее'),
('Десерты'),
('Напитки');

INSERT INTO DishProduct (Naming, Cost, UnitId) VALUES
('Картофель', 30, 1),   -- граммы
('Морковь', 25, 1),
('Курица', 250, 2),     -- килограмм
('Молоко', 60, 3),      -- литр
('Яблоко', 40, 5),      -- штука
('Сахар', 50, 1),
('Мука', 45, 1);

INSERT INTO Dish (Naming, Cost, DishTypeId) VALUES
('Борщ', 150, 1),
('Салат Оливье', 120, 2),
('Котлета с картошкой', 200, 3),
('Яблочный пирог', 180, 4),
('Молочный коктейль', 90, 5);

-- Борщ
INSERT INTO Recipes (DishId, DishProductId, CountOfUnits) VALUES
(1, 1, 200), -- картофель 200 г
(1, 2, 100), -- морковь 100 г
(1, 3, 0.5); -- курица 0.5 кг

-- Оливье
INSERT INTO Recipes (DishId, DishProductId, CountOfUnits) VALUES
(2, 1, 150), -- картофель
(2, 2, 100), -- морковь
(2, 5, 2);   -- яблоки

-- Котлета с картошкой
INSERT INTO Recipes (DishId, DishProductId, CountOfUnits) VALUES
(3, 1, 250), -- картошка
(3, 3, 0.4); -- курица

-- Яблочный пирог
INSERT INTO Recipes (DishId, DishProductId, CountOfUnits) VALUES
(4, 5, 3),   -- яблоки
(4, 7, 300), -- мука
(4, 6, 100); -- сахар

-- Молочный коктейль
INSERT INTO Recipes (DishId, DishProductId, CountOfUnits) VALUES
(5, 4, 0.3), -- молоко 0.3 л
(5, 6, 50);  -- сахар 50 г


INSERT INTO OrderCheck (ClientName, Total, OrderTime) VALUES
('Иванов Иван', 330, GETDATE()),
('Петров Петр', 200, DATEADD(MINUTE, -30, GETDATE())),
('Сидорова Анна', 270, DATEADD(HOUR, -1, GETDATE()));


-- Чек 1: Иванов заказал борщ + молочный коктейль
INSERT INTO Items (OrderCheckId, DishId, DishCount) VALUES
(1, 1, 1),  -- борщ
(1, 5, 2);  -- 2 коктейля

-- Чек 2: Петров заказал котлету
INSERT INTO Items (OrderCheckId, DishId, DishCount) VALUES
(2, 3, 1);

-- Чек 3: Сидорова заказала салат и пирог
INSERT INTO Items (OrderCheckId, DishId, DishCount) VALUES
(3, 2, 1),
(3, 4, 1);

ALTER TABLE OrderCheck
ALTER COLUMN ClientName NVARCHAR(255) NULL;


INSERT INTO OrderCheck (Total, OrderTime) VALUES
(330, GETDATE()-20),
(230, GETDATE()-19),
(112, GETDATE()-18),
(1231, GETDATE()-17),
(131, GETDATE()-16),
(342, GETDATE()-15),
(1234, GETDATE()-14),
(434, GETDATE()-13),
(44, GETDATE()-12),
(2342, GETDATE()-11),
(24, GETDATE()-10),
(234, GETDATE()-9),
(456, GETDATE()-8),
(765, GETDATE()-7),
(4564, GETDATE()-6),
(44, GETDATE()-5),
(464, GETDATE()-4),
(4, GETDATE()-3),
(34, GETDATE()-2),
(333, GETDATE()-1);

select * from OrderCheck;
INSERT INTO Items (OrderCheckId, DishId, DishCount) VALUES
(32, 2, 2),
(31, 3, 1),
(33, 4, 3),
(34, 5, 1),
(30, 1, 1),
(29, 2, 2),
(28, 3, 3),
(27, 4, 1),
(26, 5, 2),
(25, 1, 3),
(15, 2, 1),
(16, 3, 2),
(17, 4, 1),
(18, 5, 3);

UPDATE OrderCheck
SET ClientName = ''
WHERE ClientName IS NULL;


select OrderCheck.Id, OrderCheck.ClientName, Dish.Naming, Items.DishCount from OrderCheck
inner join Items on Items.OrderCheckId = OrderCheck.Id
inner join Dish on Dish.Id = Items.DishId;

insert into Items(OrderCheckId, DishId, DishCount)
values (1, 4, 3);