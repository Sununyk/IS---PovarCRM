-- 1. Добавляем роль Master
Insert INto Roles (RoleName)
Values ('NoName');

INSERT INTO Roles (RoleName)
VALUES ('Salesman');
INSERT INTO Roles (RoleName)
VALUES ('Gost');

Select * from Roles;
Select * from Users;
INSERT INTO Users(UserName, Email, PasswordHash, RoleId)
VALUES ('NoName', 'hz', 'WExTDcbU3KsqMkykpxst/dZxZAuuri7sdxIRrtLJ/3MTR/waXRUGUwaDaCiJPUVq', 

-- 2. Добавляем пользователей
INSERT INTO Users (UserName, Email, PasswordHash, RoleId)
VALUES ('Sany', 'alex@mail.ru', '3PQK/hCgOFn+R0UTV1NlrI2zosxeXvjoWuHfoC272XMXP2/gz4ghITiA+rC/8NnE', 1),
       ('Jamshut', 'alex@gmail.com', 'hn9BQi/Lg+4Vcj1f5SDxZ7SopYQqEo6H86jtidhOwRxLjXxkG7PPs2gujnxlkH6F', 1);
	   
INSERT INTO Users (UserName, Email, PasswordHash, RoleId)
VALUES ('Djamshut', 'alex@mail.ru', 'hn9BQi/Lg+4Vcj1f5SDxZ7SopYQqEo6H86jtidhOwRxLjXxkG7PPs2gujnxlkH6F', 2);
	   
INSERT INTO Users (UserName, Email, PasswordHash, RoleId)
VALUES ('NoName', '.ru', 'WExTDcbU3KsqMkykpxst/dZxZAuuri7sdxIRrtLJ/3MTR/waXRUGUwaDaCiJPUVq', 3);
	   --passwords : admin, worker
-- 3. Добавляем права для роли Master
INSERT INTO RolePermissions (Id, Permission)
VALUES 
    (3, 'None');
	
INSERT INTO RolePermissions (Id, Permission)
VALUES 
    (1, 'DishProductConstructor'),
    (1, 'ServingOrders'),
    (1, 'MenuConstructor');

UPDATE RolePermissions
Set Permission = 'DishProductsConstructor'
where Permission = 'DishProductConstructor'