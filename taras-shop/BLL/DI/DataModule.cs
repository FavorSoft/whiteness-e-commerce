using Autofac;
using BLL.IProviders;
using BLL.Providers;
using DAL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DI
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Providers
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<UnitOfWork.IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<CategoryProvider>().As<ICategoryProvider>().InstancePerRequest();
            builder.RegisterType<CategoryTypeProvider>().As<ICategoryTypeProvider>().InstancePerRequest();
            builder.RegisterType<BasketItemsProvider>().As<IBasketItemsProvider>().InstancePerRequest();
            builder.RegisterType<BasketProvider>().As<IBasketProvider>().InstancePerRequest();
            builder.RegisterType<ImagesProvider>().As<IImagesProvider>().InstancePerRequest();
            builder.RegisterType<NewsImagesProvider>().As<INewsImagesProvider>().InstancePerRequest();
            builder.RegisterType<NewsProvider>().As<INewsProvider>().InstancePerRequest();
            builder.RegisterType<OrderItemsProvider>().As<IOrderItemsProvider>().InstancePerRequest();
            builder.RegisterType<OrderProvider>().As<IOrderProvider>().InstancePerRequest();
            builder.RegisterType<RoleProvider>().As<IRoleProvider>().InstancePerRequest();
            builder.RegisterType<UnitProvider>().As<IUnitProvider>().InstancePerRequest();
            builder.RegisterType<UserProvider>().As<IUserProvider>().InstancePerRequest();
            #endregion

            #region Repositories
            builder.RegisterType<BasketItemsRepository>().As<IBasketItemsRepository>().InstancePerRequest();
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().InstancePerRequest();
            builder.RegisterType<CategoriesRepository>().As<ICategoriesRepository>().InstancePerRequest();
            builder.RegisterType<CategoryTypeRepository>().As<ICategoryTypeRepository>().InstancePerRequest();
            builder.RegisterType<ImagesRepository>().As<IImagesRepository>().InstancePerRequest();
            builder.RegisterType<NewsImageRepository>().As<INewsImageRepository>().InstancePerRequest();
            builder.RegisterType<NewsRepository>().As<INewsRepository>().InstancePerRequest();
            builder.RegisterType<OrderItemsRepository>().As<IOrderItemsRepository>().InstancePerRequest();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();
            builder.RegisterType<UnitRepository>().As<IUnitRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            #endregion

            base.Load(builder);
        }
    }
}
