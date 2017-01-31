using Autofac;
using BLL.Providers;
using DAL;
using DAL.Repositories;
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
            builder.RegisterType<CategoryProvider>().As<ICategoryProvider>().InstancePerRequest();
            builder.RegisterType<CategoriesRepository>().As<ICategoriesRepository>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
