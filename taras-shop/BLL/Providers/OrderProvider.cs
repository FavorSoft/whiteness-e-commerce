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
    public class OrderProvider : IOrderProvider
    {
        IOrderRepository _repo;
        public OrderProvider()
        {
            _repo = new OrderRepository();
        }
        public void AddItem(DTO.Order order)
        {
            _repo.AddItem(new DAL.Order()
            {
                order_date = order.OrderDate,
                user_id = order.UserId
            });
        }

        public IEnumerable<DTO.Order> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.Order> ConvertModeltoDTO(IQueryable<DAL.Order> repo)
        {
            List<DTO.Order> res = new List<DTO.Order>();
            foreach (var i in repo)
            {
                res.Add(new DTO.Order()
                {
                    Id = i.id,
                    UserId = i.user_id,
                    OrderDate = i.order_date
                });
            }
            return res;
        }

        public DTO.Order GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new DTO.Order()
            {
                Id = tmp.id,
                OrderDate = tmp.order_date,
                UserId = tmp.user_id
            };
        }
    }
}
