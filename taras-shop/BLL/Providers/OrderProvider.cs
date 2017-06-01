using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;
using System;
using DTO.Exceptions;

namespace BLL.Providers
{
    public class OrderProvider : IOrderProvider
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
                UserId = i.user_id.Value,
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
                UserId = tmp.user_id.Value
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

        public OrderDto GetByOwner(int id)
        {
            var res = _repo.GetEntities().Orders.Where(x => x.user_id == id).FirstOrDefault();
            if (res != null)
            {
                return new OrderDto()
                {
                    Id = res.id,
                    OrderDate = res.order_date,
                    UserId = res.user_id.Value
                };
            }
            else
            {
                throw new ItemNotFoundException();
            }
        }
    }
}
