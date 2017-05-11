using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;

namespace BLL.Providers
{
    public class OrderProvider : IProvider<OrderDto>
    {
        readonly IRepository<Order> _repo;
        public OrderProvider(AzureEntities db)
        {
            _repo = new OrderRepository(db);
        }
        public int AddItem(OrderDto order)
        {
            return _repo.AddItem(new Order()
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

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(OrderDto item)
        {
            _repo.EditItem(new Order()
            {
                id = item.Id,
                order_date = item.OrderDate,
                user_id = item.UserId
            });
        }
    }
}
