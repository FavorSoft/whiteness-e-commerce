using BLL.IProviders;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProvider<BasketItemsDto> getBasketItems { get; }
        IProvider<BasketDto> getBasket { get; }
        IProvider<CategoriesDto> getCategory { get; }
        IProvider<CategoryTypeDto> getCategoryType { get; }
        IImagesProvider getImages { get; }
        IProvider<NewsImagesDto> getNewsImages { get; }
        IProvider<NewsDto> getNews { get; }
        IProvider<OrderItemsDto> getOrderItems { get; }
        IProvider<OrderDto> getOrder { get; }
        IProvider<RolesDto> getRole { get; }
        IProvider<SizesDto> getSizes { get; }
        IUnitProvider getUnit { get; }
        IProvider<UsersDto> getUser { get; }
        int Commit();
        void Dispose();
    }
}
