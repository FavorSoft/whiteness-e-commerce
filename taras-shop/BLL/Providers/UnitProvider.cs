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
    public class UnitProvider : IUnitProvider
    {
        readonly IUnitRepository _repo;
        public UnitProvider(IUnitRepository di)
        {
            _repo = di;
        }
        public void AddItem(UnitDto unit)
        {
            _repo.AddItem(new Unit()
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

        public IEnumerable<UnitDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        public IEnumerable<UnitDto> GetSomeUnits(int start, int amount)
        {
            IQueryable<Unit> list;
            list = _repo.GetAll().Skip(start).Take(amount);
            return ConvertModeltoDTO(list);
        }

        public IEnumerable<UnitDto> GetPopular(int amount)
        {
            IQueryable<Unit> list;
            list = _repo.GetAll().OrderBy(x => x.likes).Take(amount);
            return ConvertModeltoDTO(list);
        }

        public IEnumerable<UnitDto> GetRecommends()
        {
            IQueryable<Unit> list;
            list = _repo.GetAll().Take(3);
            return ConvertModeltoDTO(list);
        }

        IEnumerable<UnitDto> ConvertModeltoDTO(IQueryable<Unit> repo)
        {
            IEnumerable<UnitDto> res = repo.Select(i=>new UnitDto() {
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
                    Title = i.title });
           
            return res;
        }

        public UnitDto GetById(int id)
        {
            var i = _repo.GetById(id);
            return new UnitDto()
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
