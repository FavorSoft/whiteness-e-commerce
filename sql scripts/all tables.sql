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
    reg_date Date not null
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
    category_id int not null,
    amount int not null,
    size nvarchar(2) not null,
    material nvarchar(64) not null,
    [color] nvarchar(64) not null,
    likes int not null,
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


/* create Basket table*/
create table Basket_items
(
	id int not null identity(1,1),
	basket_id int not null,
	unit_id int not null,
	amount int not null
)
/**/

/* alter Images table*/
alter table Basket_items
add constraint pk_basket_items_id
primary key (id)
 
alter table Basket_items
add constraint fk_unit_id
foreign key (unit_id)
references Unit(id)

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
insert into Users(email, [password], number, name, surname, role_id, reg_date)
values
('pinoplastiks@gmail.com', '1111', '0673553394', 'Andrii', 'Kolomys', 1, '2017-01-25'),
('dendendengrebenets@gmail.com', '1111', '0673455599', 'Denny', 'Greb', 2, '2017-01-25'),
('isurrender@gmail.com', '1111', '0931234423', 'Taras', 'Volinets', 3, '2017-01-27'),
('isurrender2@gmail.com', '1111', '0931234423', 'Taras', 'Volinets', 4, '2017-01-27')

/* fill Category_type table*/
insert into Category_type([type])
values
('Woman'),
('Man'),
('Child')

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
insert into Unit(title, producer, price, category_id, amount, size, material, color, likes, [description])
values
(N'Нова колекція бюстгальтерів', 'USA', 3350, 1, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція бюстгальтерів', 'Russia', 4350, 1, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція бюстгальтерів', 'Ukraine', 8370, 1, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція жіноччих комплектів', 'USA', 3350, 2, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція жіноччих комплектів', 'Russia', 4350, 2, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція жіноччих комплектів', 'Ukraine', 8370, 2, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція жіноччих нічних сорочок', 'USA', 3350, 3, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція жіноччих нічних сорочок', 'Russia', 4350, 3, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція жіноччих нічних сорочок', 'Ukraine', 8370, 3, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція термобілизни', 'USA', 3350, 4, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція жіноччої термобілизни', 'Russia', 4350, 4, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція жіноччої термобілизни', 'Ukraine', 8370, 4, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція трусів', 'USA', 3350, 5, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція трусів', 'Russia', 4350, 5, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція трусів', 'Ukraine', 8370, 5, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція трусів', 'USA', 3350, 6, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція трусів', 'Russia', 4350, 6, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція трусів', 'Ukraine', 8370, 6, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція чоловіччих нічних сорочок', 'USA', 3350, 7, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція чоловіччих нічних сорочок', 'Russia', 4350, 7, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція чоловіччих нічних сорочок', 'Ukraine', 8370, 7, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція піжам', 'USA', 3350, 8, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція піжам', 'Russia', 4350, 8, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція піжам', 'Ukraine', 8370, 8, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),

(N'Нова колекція термобілизни', 'USA', 3350, 9, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція термобілизни', 'Russia', 4350, 9, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція термобілизни', 'Ukraine', 8370, 9, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція трусів', 'USA', 3350, 10, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція трусів', 'Russia', 4350, 10, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція трусів', 'Ukraine', 8370, 10, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція дитячих нічних сорочок', 'USA', 3350, 11, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція дитячих нічних сорочок', 'Russia', 4350, 11, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція дитячих нічних сорочок', 'Ukraine', 8370, 11, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.'),
 
(N'Нова колекція піжам', 'USA', 3350, 12, 10, 'M', N'тканина', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Стара колекція піжам', 'Russia', 4350, 12, 10, 'S', N'волокно', N'білий', 0, N'Дуже цікава модель, родичі рекомендують.'),
(N'Модна колекція піжам', 'Ukraine', 8370, 12, 10, 'XS', N'тканина', N'червоний', 0, N'Дуже цікава модель, родичі рекомендують.')

/* fill Images table*/


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