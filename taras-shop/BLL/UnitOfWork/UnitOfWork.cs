﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.IProviders;
using BLL.Providers;
using DAL;
using DTO;

namespace BLL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        #region PARAMETERS
        IProvider<BasketItemsDto> _basketItems;
        IProvider<BasketDto> _basket;
        IProvider<CategoriesDto> _category;
        IProvider<CategoryTypeDto> _categoryType;
        IImagesProvider _images;
        IProvider<NewsImagesDto> _newsImages;
        IProvider<NewsDto> _news;
        IProvider<OrderItemsDto> _orderItems;
        IProvider<OrderDto> _order;
        IProvider<RolesDto> _role;
        IUnitProvider _unit;
        IProvider<UsersDto> _user;
        Entities context;
        #endregion

        #region CTOR
        public UnitOfWork(
            )
        {
            context = new Entities();
        }
        #endregion

        public IProvider<BasketDto> getBasket{
            get
            {
                if (_basket == null)
                {
                    _basket = new BasketProvider(context);
                }
                return _basket;
            }
        }

        public IProvider<BasketItemsDto> getBasketItems
        {
            get
            {
                if (_basketItems == null)
                {
                    _basketItems = new BasketItemsProvider(context);
                }
                return _basketItems;
            }
        }

        public IProvider<CategoriesDto> getCategory
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryProvider(context);
                }
                return _category;
            }
        }

        public IProvider<CategoryTypeDto> getCategoryType
        {
            get
            {
                if (_categoryType == null)
                {
                    _categoryType = new CategoryTypeProvider(context);
                }
                return _categoryType;
            }
        }

        public IImagesProvider getImages
        {
            get
            {
                if (_images == null)
                {
                    _images = new ImagesProvider(context);
                }
                return _images;
            }
        }

        public IProvider<NewsDto> getNews
        {
            get
            {
                if (_news == null)
                {
                    _news = new NewsProvider(context);
                }
                return _news;
            }
        }

        public IProvider<NewsImagesDto> getNewsImages
        {
            get
            {
                if (_newsImages == null)
                {
                    _newsImages = new NewsImagesProvider(context);
                }
                return _newsImages;
            }
        }

        public IProvider<OrderDto> getOrder
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderProvider(context);
                }
                return _order;
            }
        }

        public IProvider<OrderItemsDto> getOrderItems
        {
            get
            {
                if (_orderItems == null)
                {
                    _orderItems = new OrderItemsProvider(context);
                }
                return _orderItems;
            }
        }

        public IProvider<RolesDto> getRole
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleProvider(context);
                }
                return _role;
            }
        }

        public IUnitProvider getUnit
        {
            get
            {
                if (_unit == null)
                {
                    _unit = new UnitProvider(context);
                }
                return _unit;
            }
        }

        public IProvider<UsersDto> getUser
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserProvider(context);
                }
                return _user;
            }
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
