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
    public class BasketProvider : IProvider<BasketDto>
    {
        readonly IRepository<Basket> _repo;
        public BasketProvider(Entities db)
        {
            _repo = new BasketRepository(db);
        }
        public void AddItem(BasketDto basket)
        {
            _repo.AddItem(new Basket()
            {
                user_id = basket.UserId
            });
        }

        public IEnumerable<BasketDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<BasketDto> ConvertModeltoDTO(IQueryable<DAL.Basket> repo)
        {
            IEnumerable<BasketDto> res = repo.Select(i => new DTO.BasketDto()
                {
                    Id = i.id,
                    UserId = i.user_id
                });
            return res;
        }

        public DTO.BasketDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new DTO.BasketDto()
            {
                Id = tmp.id,
                UserId = tmp.user_id
            };
        }
    }
}
