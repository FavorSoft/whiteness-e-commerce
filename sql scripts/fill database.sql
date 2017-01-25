
/* fill Roles table */
insert into Roles(role)
values
('Admin'),
('Moderator'), 
('User'), 
('Banned')

/* fill Users table*/
insert into Users(email, [password], number, name, surname, role_id, reg_date)
values('pinoplastiks@gmail.com', '1111', '0673553394', 'Andrii', 'Kolomys', 1, '2017-01-25'),
('dendendengrebenets@gmail.com', '1111', '0673455599', 'Denny', 'Greb', 1, '2017-01-25'),
('pinoplastiks@gmail.com', '1111', '0673553394', 'Andrii', 'Kolomys', 1, '2007-05-08'),
('pinoplastiks@gmail.com', '1111', '0673553394', 'Andrii', 'Kolomys', 1, '2007-05-08'),
('pinoplastiks@gmail.com', '1111', '0673553394', 'Andrii', 'Kolomys', 1, '2007-05-08')

/* create Categories table*/
create table Categories
(
    id int not null identity(1,1),
    category nvarchar(256) not null,
    [type] nvarchar not null,
    [description] nvarchar(2048) null
);
/*drop table Categories*/

/* alter Categories table*/
alter table Categories
add constraint pk_categories_id
primary key (id)


/* create Unit table*/
create table Unit
(
    id int not null identity(1,1),
    title nvarchar(256) not null,
    producer nvarchar(256),
    price int null,
    category_id int not null,
    amount int not null,
    size int not null,
    material nvarchar(64) not null,
    [color] nvarchar(64) not null,
    likes int not null,
    [description] nvarchar(2048) null
);
/*drop table Unit*/

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
/*drop table Images*/

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
    user_id int not null,
    unit_id int not null,
    amount int not null
);
/*drop table Basket*/

/* alter Basket table*/
alter table Basket
add constraint pk_basket_id
primary key (id)

alter table Basket
add constraint fk_user_id
foreign key (user_id)
references Users(id)

alter table Basket
add constraint fk_unit_id
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
/*drop table News*/

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
/*drop table News_image*/

/* alter News table */
alter table News_image
add constraint pk_news_image_id
primary key (id)

alter table News_image
add constraint fk_news_image_owner_id
foreign key (owner_id)
references News(id)
