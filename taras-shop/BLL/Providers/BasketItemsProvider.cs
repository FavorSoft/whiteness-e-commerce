using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.IRepository;
using DALLocalDB.Repository;

namespace BLL.Providers
{
    public class BasketItemsProvider : IProvider<BasketItemsDto>
    {
        readonly IRepository<Basket_items> _repo;
        public BasketItemsProvider(LocalEntities db)
        {   
            _repo = new BasketItemsRepository(db);
        }
        public void AddItem(BasketItemsDto basketItems)
        {
            _repo.AddItem(new Basket_items()
            {
                unit_info_id = basketItems.UnitInfoId,
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
                    UnitInfoId = i.unit_info_id
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
                UnitInfoId = tmp.unit_info_id
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
                id = item.Id,
                unit_info_id = item.UnitInfoId
            });
        }
    }
}
