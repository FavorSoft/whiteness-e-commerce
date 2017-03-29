using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;

namespace BLL.Providers
{
    public class OrderItemsProvider : IProvider<OrderItemsDto>
    {
        readonly IRepository<Order_items> _repo;
        public OrderItemsProvider(LocalEntities db)
        {
            _repo = new OrderItemsRepository(db);
        }
        public void AddItem(OrderItemsDto orderItems)
        {
            _repo.AddItem(new Order_items()
            {
                amount = orderItems.Amount,
                price = orderItems.Price,
                unit_id = orderItems.UnitId,
                order_id = orderItems.OrderId
            });
        }

        public IEnumerable<OrderItemsDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<OrderItemsDto> ConvertModeltoDTO(IQueryable<Order_items> repo)
        {
            IEnumerable<OrderItemsDto> res = repo.Select(i => new OrderItemsDto()
                {
                    Id = i.id,
                    Amount = i.amount,
                    OrderId = i.order_id,
                    Price = i.price,
                    UnitId = i.unit_id
                });
            return res;
        }

        public OrderItemsDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new OrderItemsDto()
            {
                Amount = tmp.amount,
                Id = tmp.id,
                OrderId = tmp.order_id,
                Price = tmp.price,
                UnitId = tmp.unit_id
            };
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(OrderItemsDto item)
        {
            _repo.EditItem(new Order_items()
            {
                id = item.Id,
                amount = item.Amount,
                order_id = item.OrderId,
                price = item.Price,
                unit_id = item.UnitId
            });
        }
    }
}
