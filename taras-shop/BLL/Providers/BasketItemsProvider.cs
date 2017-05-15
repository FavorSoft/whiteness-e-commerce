﻿using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.IRepository;
using DALLocalDB.Repository;
using System;

namespace BLL.Providers
{
    public class BasketItemsProvider : IBasketItemsProvider
    {
        readonly IRepository<Basket_items> _repo;
        public BasketItemsProvider(AzureEntities db)
        {   
            _repo = new BasketItemsRepository(db);
        }

        public int AddItem(BasketItemsDto basketItems)
        {
            return _repo.AddItem(new Basket_items()
            {
                size = basketItems.Size,
                amount = basketItems.Amount,
                unit_id = basketItems.UnitId,
                was_added = basketItems.WasAdded,
                basket_id = basketItems.BasketId
            });
        }

        public IEnumerable<BasketItemsDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<BasketItemsDto> ConvertModeltoDTO(IQueryable<Basket_items> repo)
        {
            IEnumerable<BasketItemsDto> res = repo.Select(i => new BasketItemsDto()
                {
                    Id = i.id,
                    Amount = i.amount,
                    UnitId = i.unit_id,
                    BasketId = i.basket_id,
                    WasAdded = i.was_added,
                    Size = i.size
                });
            return res;
        }

        public BasketItemsDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new BasketItemsDto()
            {
                Id = tmp.id,
                Amount = tmp.amount,
                BasketId = tmp.basket_id,
                UnitId = tmp.unit_id,
                WasAdded = tmp.was_added,
                Size = tmp.size
            };
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(BasketItemsDto item)
        {
            _repo.EditItem(new Basket_items()
            {
                amount = item.Amount,
                basket_id = item.BasketId,
                unit_id = item.UnitId,
                was_added = item.WasAdded,
                id = item.Id,
                size = item.Size
            });
        }

        public IEnumerable<BasketItemsDto> GetByBasket(BasketDto basket)
        {
            return _repo.GetEntities().Basket_items.Where(x => x.basket_id == basket.Id).Select(z => new BasketItemsDto()
            {
                Id = z.id,
                Amount = z.amount,
                BasketId = z.basket_id, 
                UnitId = z.unit_id,
                WasAdded = z.was_added,
                Size = z.size
            });
        }
    }
}
