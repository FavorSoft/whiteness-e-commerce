using BLL.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repository;
using DAL.IRepository;

namespace BLL.Providers
{
    public class OrderProvider : IProvider<OrderDto>
    {
        readonly IRepository<Order> _repo;
        public OrderProvider(Entities db)
        {
            _repo = new OrderRepository(db);
        }
        public void AddItem(OrderDto order)
        {
            _repo.AddItem(new Order()
            {
                order_date = order.OrderDate,
                user_id = order.UserId
            });
        }

        public IEnumerable<OrderDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<OrderDto> ConvertModeltoDTO(IQueryable<Order> repo)
        {
            IEnumerable<OrderDto> res = repo.Select(i => new OrderDto()
                {
                    Id = i.id,
                    UserId = i.user_id,
                    OrderDate = i.order_date
                }).ToList();
            return res;
        }

        public OrderDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new OrderDto()
            {
                Id = tmp.id,
                OrderDate = tmp.order_date,
                UserId = tmp.user_id
            };
        }
    }
}
