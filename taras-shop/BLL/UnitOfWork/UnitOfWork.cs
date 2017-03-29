using System.Data.Entity;
using BLL.IProviders;
using BLL.Providers;
using DALLocalDB;
using DTO;

namespace BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region PARAMETERS
        IProvider<BasketItemsDto> _basketItems;
        IProvider<BasketDto> _basket;
        ICategoryProvider _category;
        IProvider<CategoryTypeDto> _categoryType;
        IImagesProvider _images;
        IProvider<NewsImagesDto> _newsImages;
        IProvider<NewsDto> _news;
        IProvider<OrderItemsDto> _orderItems;
        IProvider<OrderDto> _order;
        IRolesProvider _role;
        ISizesProvider _sizes;
        IUnitProvider _unit;
        IUserProvider _user;
        IUnitInfoProvider _unitInfo;
        LocalEntities context;
        #endregion

        #region CTOR
        public UnitOfWork(
            )
        {
            context = new LocalEntities();
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

        public ISizesProvider getSizes
        {
            get
            {
                if (_sizes == null)
                {
                    _sizes = new SizesProvider(context);
                }
                return _sizes;
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

        public ICategoryProvider getCategory
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

        public IRolesProvider getRole
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

        public IUserProvider getUser
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

        public IUnitInfoProvider getUnitInfo
        {
            get
            {
                if (_unitInfo == null)
                {
                    _unitInfo = new UnitInfoProvider(context);
                }
                return _unitInfo;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public DbContextTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
