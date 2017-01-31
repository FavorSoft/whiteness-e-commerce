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
        IBasketItemsRepository _repo;
        public BasketItemsProvider()
        {
            _repo = new BasketItemsRepository();
        }
        public void AddItem(BasketItems basketItems)
        {
            _repo.AddItem(new Basket_items()
            {
                unit_id = basketItems.UnitId,
                amount = basketItems.Amount,
                basket_id = basketItems.BasketId
            });
        }

        public IEnumerable<BasketItems> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }
        List<BasketItems> ConvertModeltoDTO(IQueryable<DAL.Basket_items> repo)
        {
            List<BasketItems> res = new List<BasketItems>();
            foreach (var i in repo)
            {
                res.Add(new BasketItems()
                {
                    Id = i.id,
                    Amount = i.amount,
                    BasketId = i.basket_id,
                    UnitId = i.unit_id
                });
            }
            return res;
        }

        public BasketItems GetById(int id)
        {
            var tmp = _repo.GetById(id);

            return new BasketItems()
            {
                Id = tmp.id,
                Amount = tmp.amount,
                BasketId = tmp.basket_id,
                UnitId = tmp.unit_id
            };
        }
    }
}
