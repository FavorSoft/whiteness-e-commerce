﻿drop table News_image
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
