using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.IProviders;
using DAL;

namespace BLL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        #region PARAMETERS
        readonly IBasketItemsProvider _basketItems;
        readonly IBasketProvider _basket;
        readonly ICategoryProvider _category;
        readonly ICategoryTypeProvider _categoryType;
        readonly IImagesProvider _images;
        readonly INewsImagesProvider _newsImages;
        readonly INewsProvider _news;
        readonly IOrderItemsProvider _orderItems;
        readonly IOrderProvider _order;
        readonly IRoleProvider _role;
        readonly IUnitProvider _unit;
        readonly IUserProvider _user;
        Entities context;
        #endregion

        #region CTOR
        public UnitOfWork(
            IBasketItemsProvider basketItems,
            IBasketProvider basket,
            ICategoryProvider category,
            ICategoryTypeProvider categoryType,
            IImagesProvider images,
            INewsImagesProvider newsImages,
            INewsProvider news,
            IOrderItemsProvider orderItems,
            IOrderProvider order,
            IRoleProvider role,
            IUnitProvider unit,
            IUserProvider user
            )
        {
            context = new Entities();
            // Dependency Injection
            _basketItems = basketItems;
            _basket = basket;
            _category = category;
            _categoryType = categoryType;
            _images = images;
            _newsImages = newsImages;
            _news = news;
            _orderItems = orderItems;
            _order = order;
            _role = role;
            _unit = unit;
            _user = user;   
        }
        #endregion

        public IBasketProvider Basket{
            get
            {
                return _basket;
            }
        }

        public IBasketItemsProvider BasketItems
        {
            get
            {
                return _basketItems;
            }
        }

        public ICategoryProvider Category
        {
            get
            {
                return _category;
            }
        }

        public ICategoryTypeProvider CategoryType
        {
            get
            {
                return _categoryType;
            }
        }

        public IImagesProvider Images
        {
            get
            {
                return _images;
            }
        }

        public INewsProvider News
        {
            get
            {
                return _news;
            }
        }

        public INewsImagesProvider NewsImages
        {
            get
            {
                return _newsImages;
            }
        }

        public IOrderProvider Order
        {
            get
            {
                return _order;
            }
        }

        public IOrderItemsProvider OrderItems
        {
            get
            {
                return _orderItems;
            }
        }

        public IRoleProvider Role
        {
            get
            {
                return _role;
            }
        }

        public IUnitProvider Unit
        {
            get
            {
                return _unit;
            }
        }

        public IUserProvider User
        {
            get
            {
                return _user;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
