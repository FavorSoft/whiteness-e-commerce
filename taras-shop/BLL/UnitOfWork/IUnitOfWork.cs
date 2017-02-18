using BLL.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBasketItemsProvider BasketItems { get; }
        IBasketProvider Basket { get; }
        ICategoryProvider Category { get; }
        ICategoryTypeProvider CategoryType { get; }
        IImagesProvider Images { get; }
        INewsImagesProvider NewsImages { get; }
        INewsProvider News { get; }
        IOrderItemsProvider OrderItems { get; }
        IOrderProvider Order { get; }
        IRoleProvider Role { get; }
        IUnitProvider Unit { get; }
        IUserProvider User { get; }
        int Commit();
        void Dispose();
    }
}
