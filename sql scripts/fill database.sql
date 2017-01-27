
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
