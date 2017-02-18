using BLL.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repository;

namespace BLL.Providers
{
    public class OrderItemsProvider : IOrderItemsProvider
    {
        readonly IOrderItemsRepository _repo;
        public OrderItemsProvider(IOrderItemsRepository di)
        {
            _repo = di;
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
    }
}
