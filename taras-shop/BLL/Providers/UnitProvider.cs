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
    public class UnitProvider : IUnitProvider
    {
        IUnitRepository _repo;
        public UnitProvider()
        {
            _repo = new UnitRepository();
        }
        public void AddItem(DTO.Unit unit)
        {
            _repo.AddItem(new DAL.Unit()
            {
                amount = unit.Amount,
                category_id = unit.CategoryId,
                color = unit.Color,
                description = unit.Description,
                likes = unit.Likes,
                price = unit.Price,
                material = unit.Material,
                producer = unit.Producer,
                title = unit.Title,
                size = unit.Size
            });
        }

        public IEnumerable<DTO.Unit> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        public IEnumerable<DTO.Unit> GetSomeUnits(int start, int amount)
        {
            IQueryable<DAL.Unit> list;
            list = _repo.GetAll().Skip(start).Take(amount);
            return ConvertModeltoDTO(list);
        }

        public IEnumerable<DTO.Unit> GetPopular(int amount)
        {
            IQueryable<DAL.Unit> list;
            list = _repo.GetAll().OrderBy(x => x.likes).Take(amount);
            return ConvertModeltoDTO(list);
        }

        public IEnumerable<DTO.Unit> GetRecommends()
        {
            IQueryable<DAL.Unit> list;
            list = _repo.GetAll().Take(3);
            return ConvertModeltoDTO(list);
        }

        List<DTO.Unit> ConvertModeltoDTO(IQueryable<DAL.Unit> repo)
        {
            List<DTO.Unit> res = new List<DTO.Unit>();
            foreach (var i in repo)
            {
                res.Add(new DTO.Unit()
                {
                    Id = i.id,
                    Amount = i.amount,
                    Size = i.size,
                    CategoryId = i.category_id,
                    Color = i.color,
                    Description = i.description,
                    Likes = i.likes,
                    Material = i.material, 
                    Price = i.price,
                    Producer = i.producer,
                    Title = i.title
                });
            }
            return res;
        }

        public DTO.Unit GetById(int id)
        {
            var i = _repo.GetById(id);
            return new DTO.Unit()
            {
                Id = i.id,
                Amount = i.amount,
                Size = i.size,
                CategoryId = i.category_id,
                Color = i.color,
                Description = i.description,
                Likes = i.likes,
                Material = i.material,
                Price = i.price,
                Producer = i.producer,
                Title = i.title
            };
        }

        
    }
}
