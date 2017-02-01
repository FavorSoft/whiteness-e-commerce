using BLL.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repositories;

namespace BLL.Providers
{
    public class BasketItemsProvider : IBasketItemsProvider
    {
        readonly IBasketItemsRepository _repo;
        public BasketItemsProvider(IBasketItemsRepository di)
        {
            _repo = di;
        }
        public void AddItem(BasketItemsDto basketItems)
        {
            _repo.AddItem(new Basket_items()
            {
                unit_id = basketItems.UnitId,
                amount = basketItems.Amount,
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
                    BasketId = i.basket_id,
                    UnitId = i.unit_id
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
                UnitId = tmp.unit_id
            };
        }
    }
}
