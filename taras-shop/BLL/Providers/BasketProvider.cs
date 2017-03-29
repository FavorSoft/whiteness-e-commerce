﻿using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;

namespace BLL.Providers
{
    public class BasketProvider : IProvider<BasketDto>
    {
        readonly IRepository<Basket> _repo;
        public BasketProvider(LocalEntities db)
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

        IEnumerable<BasketDto> ConvertModeltoDTO(IQueryable<Basket> repo)
        {
            IEnumerable<BasketDto> res = repo.Select(i => new BasketDto()
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

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(BasketDto item)
        {
            _repo.EditItem(new Basket()
            {
                id = item.Id,
                user_id = item.UserId
            });
        }
    }
}
