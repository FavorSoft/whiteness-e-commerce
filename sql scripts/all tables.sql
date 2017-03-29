create procedure CreateDatabase
as

/* create Roles table */
create table Roles
(
    id int not null identity(1,1) ,
    [role] nvarchar(256) not null
);
/**/

/* alter Roles table*/
alter table Roles
add constraint pk_role_id
primary key (id)


/* create Users table*/
create table Users
(
    id int not null identity(1,1),
    email nvarchar(256) not null,
    [password] nvarchar(256) not null,
    [number] nvarchar(64) null,
    name nvarchar(256) not null,
    surname nvarchar(256) not null,
    role_id int not null,
    reg_date Date not null,
	is_man bit not null
);
/**/

/* alter Users table*/
alter table Users
add constraint pk_user_id
primary key (id)

alter table Users
add constraint fk_role_id
foreign key (role_id)
references Roles(id)

/* create Category_type table*/
create table Category_type
(
	id int not null identity(1,1),
	[type] nvarchar(256) not null
)

/* alter Category_type table*/
alter table Category_type
add constraint pk_category_type_id
primary key (id)

/* create Categories table*/
create table Categories
(
    id int not null identity(1,1),
    category nvarchar(256) not null,
	[type_id] int not null,
	category_img nvarchar(2048) not null,
    [description] nvarchar(2048) null
);
/**/

/* alter Categories table*/
alter table Categories
add constraint pk_categories_id
primary key (id)

alter table Categories
add constraint fk_category_type_id
foreign key ([type_id])
references Category_type(id)

/* create Unit table*/
create table Unit
(
    id int not null identity(1,1),
    title nvarchar(256) not null,
    producer nvarchar(256),
    price int null,
	old_price int null,
    category_id int not null,
    material nvarchar(64) not null,
    [color] nvarchar(64) not null,
    likes int not null,
	add_date date not null,
    [description] nvarchar(2048) null
);
/**/

/* alter Unit table*/
alter table Unit
add constraint pk_unit_id
primary key (id)

alter table Unit
add constraint fk_category_id
foreign key (category_id)
references Categories(id)

/* create Sizes table*/

create table Sizes
(
	id int not null identity(1,1),
	size nvarchar(2) not null
)

/* alter Sizes table*/
alter table Sizes
add constraint pk_sizes_id
primary key (id)

/* create UnitInfo table*/

create table UnitInfo
(
	id int not null identity(1,1),
	unit_id int not null,
	size_id int not null,
	amount int not null
)

/* alter Sizes table*/
alter table UnitInfo
add constraint pk_unit_info_id
primary key (id)

alter table UnitInfo
add constraint fk_unit_table_id
foreign key (unit_id)
references Unit(id)

alter table UnitInfo
add constraint fk_sizes_table_id
foreign key (size_id)
references Sizes(id)


/* crate Images table*/
create table Images
(
    id int not null identity(1,1),
    image nvarchar(2048) not null,
    owner_id int not null
)
/**/

/* alter Images table*/
alter table Images
add constraint pk_images_id
primary key (id)

alter table Images
add constraint fk_owner_id
foreign key (owner_id)
references Unit(id)

/* create Basket table*/
create table Basket
(
    id int not null identity(1,1),
    user_id int not null
);
/**/

/* alter Basket table*/
alter table Basket
add constraint pk_basket_id
primary key (id)

alter table Basket
add constraint fk_user_id
foreign key (user_id)
references Users(id)


/* create Basket items table*/
create table Basket_items
(
	id int not null identity(1,1),
	basket_id int not null,
	unit_info_id int not null,
	amount int not null
)
/**/

/* alter Images table*/
alter table Basket_items
add constraint pk_basket_items_id
primary key (id)
 
alter table Basket_items
add constraint fk_unit_info_id
foreign key (unit_info_id)
references UnitInfo(id)

alter table Basket_items
add constraint fk_basket_id
foreign key (basket_id)
references Basket(id)

/* create Order table*/
create table [Order]
(
    id int not null identity(1,1),
    user_id int not null,
	order_date datetime not null
);
/*  */

/* alter Order table*/
alter table [Order]
add constraint pk_order_id
primary key (id)

alter table [Order]
add constraint fk_o_user_id
foreign key (user_id)
references Users(id)

/* create [Order_items] table*/
create table [Order_items]
(
    id int not null identity(1,1),
	order_id int not null,
    unit_id int not null,
	amount int not null,
	price int not null
);
/**/

/* alter [Order_items] table*/
alter table [Order_items]
add constraint pk_order_items_id
primary key (id)

alter table [Order_items]
add constraint fk_order_id
foreign key (order_id)
references [Order](id)

alter table [Order_items]
add constraint fk_o_unit_id
foreign key (unit_id)
references Unit(id)

/* create News table */
create table News
(
	id int not null identity(1,1),
	title nvarchar(1024) not null,
	data_create smalldatetime not null,
	[description] nvarchar(max) not null
)
/**/

/* alter News table */
alter table News
add constraint pk_news_id
primary key (id)


/* create News_image table */
create table News_image
(
	id int not null identity(1,1),
	[image] nvarchar(2048) not null,
	owner_id int not null
)
/**/

/* alter News table */
alter table News_image

add constraint pk_news_image_id
primary key (id)

alter table News_image
add constraint fk_news_image_owner_id
foreign key (owner_id)
references News(id)

create procedure DropDatabase
as
	drop table News_image
	drop table News
	drop table [Order_items]
	drop table [Order]
	drop table Basket_items
	drop table Basket
	drop table Images
	drop table UnitInfo
	drop table Sizes
	drop table Unit
	drop table Categories
	drop table Category_type
	drop table Users
	drop table Roles
	
create procedure FillDatabase
as

/* fill Roles table */
insert into Roles(role)
values
('Admin'),
('Moderator'), 
('User'), 
('Banned')

/* fill Users table*/
insert into Users(email, [password], number, name, surname, role_id, reg_date, is_man)
values
('pinoplastiks@gmail.com', '1111', '0673553394', 'Andrii', 'Kolomys', 1, '2017-01-25', 1),
('dendendengrebenets@gmail.com', '1111', '0673455599', 'Denny', 'Greb', 2, '2017-01-25', 1),
('isurrender@gmail.com', '1111', '0931234423', 'Taras', 'Volinets', 3, '2017-01-27', 0),
('isurrender2@gmail.com', '1111', '0931234423', 'Taras', 'Volinets', 4, '2017-01-27', 0)

/* fill Category_type table*/
insert into Category_type([type])
values
('Woman'),
('Man'),
('Child')

/* fill Sizes table*/
insert into Sizes(size)
values
(N'xs'),
(N's'),
(N'm'),
(N'l'),
(N'xl')

/* fill Categories table*/
insert into Categories(category, [type_id], category_img, [description])
values
(N'Бюстгальтери', 1, 'women_bra.png', N'Тест і тест'),
(N'Комплекти', 1, 'women_kits.png', N'Тест і тест'),
(N'Нічні сорочки', 1, 'women_nighty.png', N'Тест і тест'),
(N'Термобілизна', 1, 'women_underwear.png', N'Тест і тест'),
(N'Труси', 1, 'women_shorts.png', N'Тест і тест'),
(N'Труси', 2, 'man_shorts.png', N'Тест і тест'),
(N'Нічні сорочки', 2, 'man_nighty.png', N'Тест і тест'),
(N'Піжама', 2, 'man_pajamas.png', N'Тест і тест'),
(N'Термобілизна', 2, 'man_underwear.png', N'Тест і тест'),
(N'Труси', 3, 'child_shorts.png', N'Тест і тест'),
(N'Нічні сорочки', 3, 'child_nighty.png', N'Тест і тест'),
(N'Піжами', 3, 'child_pajamas.png', N'Тест і тест')

/* fill Unit table*/
insert into Unit(title, producer, price, old_price, category_id, material, color, likes, [add_date], [description])
values
(N'Нова колекція бюстгальтерів', 'USA', 3350, 4500, 1, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція бюстгальтерів', 'Russia', 4350, 5000, 1, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція бюстгальтерів', 'Ukraine', 8370, null, 1, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція жіноччих комплектів', 'USA', 3350, 5620, 2, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція жіноччих комплектів', 'Russia', 4350, 4570, 2, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція жіноччих комплектів', 'Ukraine', 8370, 9000, 2, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція жіноччих нічних сорочок', 'USA', 3350, 3500, 3, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція жіноччих нічних сорочок', 'Russia', 4350, 4500, 3, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція жіноччих нічних сорочок', 'Ukraine', 8370, null, 3, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція термобілизни', 'USA', 3350, null, 4, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція жіноччої термобілизни', 'Russia', 4350, null, 4, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція жіноччої термобілизни', 'Ukraine', 8370, null, 4, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція трусів', 'USA', 3350, 5600, 5, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція трусів', 'Russia', 4350, 5500, 5, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція трусів', 'Ukraine', 8370, 8950, 5, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція трусів', 'USA', 3350, 3680, 6, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція трусів', 'Russia', 4350, null, 6, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція трусів', 'Ukraine', 8370, null, 6, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція чоловіччих нічних сорочок', 'USA', 3350, 3500, 7, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція чоловіччих нічних сорочок', 'Russia', 4350, 4670, 7, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція чоловіччих нічних сорочок', 'Ukraine', 8370, null, 7, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція піжам', 'USA', 3350, 3670, 8, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція піжам', 'Russia', 4350, 4670, 8, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція піжам', 'Ukraine', 8370, null, 8, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),

(N'Нова колекція термобілизни', 'USA', 3350, null, 9, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція термобілизни', 'Russia', 4350, null, 9, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція термобілизни', 'Ukraine', 8370, null, 9, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція трусів', 'USA', 3350, 3560, 10, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція трусів', 'Russia', 4350, 4600, 10, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція трусів', 'Ukraine', 8370, 9000, 10, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція дитячих нічних сорочок', 'USA', 3350, 3600, 11, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція дитячих нічних сорочок', 'Russia', 4350, 4670, 11, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція дитячих нічних сорочок', 'Ukraine', 8370, 8650, 11, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція піжам', 'USA', 3350, 3680, 12, N'тканина', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція піжам', 'Russia', 4350, 4780, 12, N'волокно', N'білий', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція піжам', 'Ukraine', 8370, 9040, 12, N'тканина', N'червоний', 0, sysdatetime(), N'Дуже цікава модель, родичі рекомендують.')

/* fill Sizes table*/
insert into UnitInfo(unit_id, size_id, amount)
values
(1, 1, 3),
(2, 2, 3),
(3, 3, 4),
(4, 4, 4),
(5, 5, 4),
(6, 1, 4),
(7, 2, 4),
(8, 3, 4),
(9, 4, 4),
(10, 5, 3),
(11, 1, 3),
(12, 2, 3),
(13, 3, 7),
(14, 4, 7),
(15, 5, 7),
(16, 1, 7),
(17, 2, 7),
(18, 3, 7),
(19, 4, 3),
(20, 5, 3),
(21, 1, 3),
(22, 2, 3),
(23, 3, 4),
(24, 4, 4),
(25, 5, 4),
(26, 1, 4),
(27, 2, 3),
(28, 3, 3),
(29, 4, 3),
(30, 5, 3),
(31, 1, 3),
(32, 2, 3),
(33, 3, 3),
(34, 4, 3),
(35, 5, 3),
(36, 1, 3)

/* fill Images table*/

insert into Images(image, owner_id)
values
(N'womant.jpg', 1),
(N'womant.jpg', 2),
(N'womant.jpg', 3),
(N'womant.jpg', 4),
(N'womant.jpg', 5),
(N'womant.jpg', 6),
(N'womant.jpg', 7),
(N'womant.jpg', 8),
(N'womant.jpg', 9),
(N'womant.jpg', 10),
(N'womant.jpg', 11),
(N'womant.jpg', 12),
(N'womant.jpg', 13),
(N'womant.jpg', 14),
(N'womant.jpg', 15),
(N'womant.jpg', 16),
(N'womant.jpg', 17),
(N'womant.jpg', 18),
(N'womant.jpg', 19),
(N'womant.jpg', 20),
(N'womant.jpg', 21),
(N'womant.jpg', 22),
(N'womant.jpg', 23),
(N'womant.jpg', 24),
(N'womant.jpg', 25),
(N'womant.jpg', 26),
(N'womant.jpg', 27),
(N'womant.jpg', 28),
(N'womant.jpg', 29),
(N'womant.jpg', 30),
(N'womant.jpg', 31),
(N'womant.jpg', 32),
(N'womant.jpg', 33),
(N'womant.jpg', 34),
(N'womant.jpg', 35),
(N'womant.jpg', 36)

/* fill News table */
insert into News(title, data_create, [description])
values
(N'Вийшли нові колекції, дуже цікаві моделі та ...', '2007-05-08 12:35:29', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
(N'Вийшли нові колекції(2), дуже цікаві моделі та ...', '2007-04-08 11:35:29', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
(N'Вийшли нові колекції(3), дуже цікаві моделі та ...', '2007-05-08 12:31:29', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
(N'Вийшли нові колекції(4), дуже цікаві моделі та ...', '2007-05-01 12:30:29', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.')



create procedure MainProcedure
as 
declare @dbname nvarchar(128)
set @dbname = N'taras-shop'
if (db_id(@dbname) is not null)
	begin
		print 'db exists, so drop DB after then create DB'
		
		exec DropDatabase
		exec CreateDatabase
		exec FillDatabase
	end
else
	begin 
		print 'db not exists, so create DB'
		exec CreateDatabase
		exec FillDatabase
	end

exec MainProcedure