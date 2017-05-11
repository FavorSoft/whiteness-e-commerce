using Autofac;
using BLL.IProviders;
using BLL.Providers;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;
using DTO;
namespace BLL.DI
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Providers
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<UnitOfWork.IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<CategoryProvider>().As<ICategoryProvider>().InstancePerRequest();
            builder.RegisterType<CategoryTypeProvider>().As<IProvider<CategoryTypeDto>>().InstancePerRequest();
            builder.RegisterType<BasketItemsProvider>().As<IProvider<BasketItemsDto>>().InstancePerRequest();
            builder.RegisterType<BasketProvider>().As<IProvider<BasketDto>>().InstancePerRequest();
            builder.RegisterType<ImagesProvider>().As<IProvider<ImagesDto>>().InstancePerRequest();
            builder.RegisterType<NewsImagesProvider>().As<IProvider<NewsImagesDto>>().InstancePerRequest();
            builder.RegisterType<NewsProvider>().As<IProvider<NewsDto>>().InstancePerRequest();
            builder.RegisterType<OrderItemsProvider>().As<IProvider<OrderItemsDto>>().InstancePerRequest();
            builder.RegisterType<OrderProvider>().As<IProvider<OrderDto>>().InstancePerRequest();
            builder.RegisterType<RoleProvider>().As<IRolesProvider>().InstancePerRequest();
            builder.RegisterType<UnitProvider>().As<IProvider<UnitDto>>().InstancePerRequest();
            builder.RegisterType<UserProvider>().As<IUserProvider>().InstancePerRequest();
            #endregion

            #region Repositories
            builder.RegisterType<BasketItemsRepository>().As<IRepository<Basket_items>>().InstancePerRequest();
            builder.RegisterType<BasketRepository>().As<IRepository<Basket>>().InstancePerRequest();
            builder.RegisterType<CategoriesRepository>().As<IRepository<Category>>().InstancePerRequest();
            builder.RegisterType<CategoryTypeRepository>().As<IRepository<Category_type>>().InstancePerRequest();
            builder.RegisterType<ImagesRepository>().As<IRepository<Image>>().InstancePerRequest();
            builder.RegisterType<NewsImageRepository>().As<IRepository<News_image>>().InstancePerRequest();
            builder.RegisterType<NewsRepository>().As<IRepository<News>>().InstancePerRequest();
            builder.RegisterType<OrderItemsRepository>().As<IRepository<Order_items>>().InstancePerRequest();
            builder.RegisterType<OrderRepository>().As<IRepository<Order>>().InstancePerRequest();
            builder.RegisterType<RoleRepository>().As<IRepository<Role>>().InstancePerRequest();
            builder.RegisterType<UnitRepository>().As<IRepository<Unit>>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IRepository<User>>().InstancePerRequest();
            #endregion

            //builder.RegisterType<Facade.Facade>().As<IFacade.IFacade>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
