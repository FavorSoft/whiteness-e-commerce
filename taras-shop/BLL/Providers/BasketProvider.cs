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
    public class BasketProvider : IBasketProvider
    {
        IBasketRepository _repo;
        public BasketProvider()
        {
            _repo = new BasketRepository();
        }
        public void AddItem(DTO.Basket basket)
        {
            _repo.AddItem(new DAL.Basket()
            {
                user_id = basket.UserId
            });
        }

        public List<DTO.Basket> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.Basket> ConvertModeltoDTO(IQueryable<DAL.Basket> repo)
        {
            List<DTO.Basket> res = new List<DTO.Basket>();
            foreach (var i in repo)
            {
                res.Add(new DTO.Basket()
                {
                    Id = i.id,
                    UserId = i.user_id
                });
            }
            return res;
        }

        public DTO.Basket GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new DTO.Basket()
            {
                Id = tmp.id,
                UserId = tmp.user_id
            };
        }
    }
}
