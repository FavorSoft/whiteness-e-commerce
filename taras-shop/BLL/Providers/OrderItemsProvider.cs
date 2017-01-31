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
    public class OrderItemsProvider : IOrderItemsProvider
    {
        IOrderItemsRepository _repo;
        public OrderItemsProvider()
        {
            _repo = new OrderItemsRepository();
        }
        public void AddItem(OrderItems orderItems)
        {
            _repo.AddItem(new Order_items()
            {
                amount = orderItems.Amount,
                price = orderItems.Price,
                unit_id = orderItems.UnitId,
                order_id = orderItems.OrderId
            });
        }

        public IEnumerable<OrderItems> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.OrderItems> ConvertModeltoDTO(IQueryable<DAL.Order_items> repo)
        {
            List<DTO.OrderItems> res = new List<DTO.OrderItems>();
            foreach (var i in repo)
            {
                res.Add(new DTO.OrderItems()
                {
                    Id = i.id,
                    Amount = i.amount,
                    OrderId = i.order_id,
                    Price = i.price,
                    UnitId = i.unit_id
                });
            }
            return res;
        }

        public OrderItems GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new OrderItems()
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
