
/* create Roles table */
create table Roles
(
    id int not null identity(1,1) ,
    role nvarchar(256) not null
);
/*drop table Roles*/

/* alter Roles table*/
alter table Roles
add constraint pk_role_id
primary key (id)


/* create Users table*/
create table Users
(
    id int not null identity(1,1),
    email nvarchar(256) not null,
    password nvarchar(256) not null,
    [number] nvarchar(64) null,
    name nvarchar(256) not null,
    surname nvarchar(256) not null,
    role_id int not null,
    reg_date Date not null
);
/*drop table Users*/

/* alter Users table*/
alter table Users
add constraint pk_user_id
primary key (id)

alter table Users
add constraint fk_role_id
foreign key (role_id)
references Roles(id)

/* create Categories table*/
create table Categories
(
    id int not null identity(1,1),
    category nvarchar(256) not null,
    category_img nvarchar(2048) not null,
    type nvarchar not null,
    description nvarchar(2048) null
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
    Producer nvarchar(256),
    price int null,
    category_id int not null,
    amount int not null,
    size int not null,
    material nvarchar(64) not null,
    [color] nvarchar(64) not null,
    likes int not null,
    description nvarchar(2048) null
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
    id int not null identity(1,1) ,
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