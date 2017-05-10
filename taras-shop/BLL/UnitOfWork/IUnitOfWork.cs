﻿using BLL.IProviders;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBasketItemsProvider getBasketItems { get; }
        IBasketProvider getBasket { get; }
        ICategoryProvider getCategory { get; }
        IProvider<CategoryTypeDto> getCategoryType { get; }
        IImagesProvider getImages { get; }
        IProvider<NewsImagesDto> getNewsImages { get; }
        IProvider<NewsDto> getNews { get; }
        IProvider<OrderItemsDto> getOrderItems { get; }
        IProvider<OrderDto> getOrder { get; }
        IRolesProvider getRole { get; }
        ISizesProvider getSizes { get; }
        IUnitInfoProvider getUnitInfo { get; }
        IUnitProvider getUnit { get; }
        IUserProvider getUser { get; }
        DbContextTransaction BeginTransaction();
        int SaveChanges();
        void Dispose();
    }
}
