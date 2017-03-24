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
    public class UnitProvider : IUnitProvider
    {
        readonly IUnitRepository _repo;
        public UnitProvider(Entities db)
        {
            _repo = new UnitRepository(db);
        }
        public void AddItem(UnitDto unit)
        {
            _repo.AddItem(new Unit()
            {
                category_id = unit.CategoryId,
                color = unit.Color,
                description = unit.Description,
                likes = unit.Likes,
                price = unit.Price,
                old_price = unit.OldPrice,
                material = unit.Material,
                producer = unit.Producer,
                title = unit.Title,
                add_date = unit.AddUnitDate
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
            IQueryable<Unit> list = _repo.GetAll().OrderBy(x => x.likes).Take(amount);
            return ConvertModeltoDTO(list);
        }

        public IEnumerable<UnitDto> GetRecommends()
        {
            IQueryable<Unit> list = _repo.GetAll().OrderBy(x => x.add_date).Take(3);
            return ConvertModeltoDTO(list);
        }

        IEnumerable<UnitDto> ConvertModeltoDTO(IQueryable<Unit> repo)
        {
            IEnumerable<UnitDto> res = repo.Select(i => new UnitDto()
            {
                Id = i.id,
                CategoryId = i.category_id,
                Color = i.color,
                Description = i.description,
                Likes = i.likes,
                Material = i.material,
                Price = i.price,
                OldPrice = i.old_price,
                Producer = i.producer,
                Title = i.title,
                AddUnitDate = i.add_date
            });

            return res;
        }

        public UnitDto GetById(int id)
        {
            var i = _repo.GetById(id);
            return new UnitDto()
            {
                Id = i.id,
                CategoryId = i.category_id,
                Color = i.color,
                Description = i.description,
                Likes = i.likes,
                Material = i.material,
                Price = i.price,
                OldPrice = i.old_price,
                Producer = i.producer,
                Title = i.title,
                AddUnitDate = i.add_date
            };
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(UnitDto item)
        {
            _repo.EditItem(new Unit()
            {
                id = item.Id,
                add_date = item.AddUnitDate,
                category_id = item.CategoryId,
                color = item.Color,
                description = item.Description,
                likes = item.Likes,
                material = item.Material,
                old_price = item.OldPrice,
                price = item.Price,
                producer = item.Producer,
                title = item.Title
            });
        }

        public IEnumerable<UnitDto> GetByFilter(int categoryId, int startPrice, int endPrice, List<int> sizesId, int skipItems, int amount)
        {
            return (
                from units in _repo.GetEntities.Unit
                join s in _repo.GetEntities.UnitInfo on units.id equals s.unit_id
                where units.price >= startPrice &&
                      units.price <= endPrice &&
                      units.category_id == categoryId
                orderby units.add_date descending
                select new
                {
                    Id = units.id,
                    CategoryId = units.category_id,
                    Color = units.color,
                    Description = units.description,
                    Likes = units.likes,
                    Material = units.material,
                    Price = units.price,
                    OldPrice = units.old_price,
                    Producer = units.producer,
                    Title = units.title,
                    AddUnitDate = units.add_date,
                    sizeId = s.size_id,
                    amount = s.amount
                }).Where(x => sizesId.Contains(x.sizeId) && x.amount > 0).Select(x => new UnitDto()
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Color = x.Color,
                    Description = x.Description,
                    Likes = x.Likes,
                    Material = x.Material,
                    Price = x.Price,
                    OldPrice = x.OldPrice,
                    Producer = x.Producer,
                    Title = x.Title,
                    AddUnitDate = x.AddUnitDate
                }).Take(amount);
        }

        public IEnumerable<UnitDto> GetByFilter(int categoryId, int amount)
        {
            return (
                from units in _repo.GetEntities.Unit
                join s in _repo.GetEntities.UnitInfo on units.id equals s.unit_id
                where units.category_id == categoryId
                orderby units.add_date descending
                select new
                {
                    Id = units.id,
                    CategoryId = units.category_id,
                    Color = units.color,
                    Description = units.description,
                    Likes = units.likes,
                    Material = units.material,
                    Price = units.price,
                    OldPrice = units.old_price,
                    Producer = units.producer,
                    Title = units.title,
                    AddUnitDate = units.add_date,
                    sizeId = s.size_id,
                    amount = s.amount
                }).Select(x => new UnitDto()
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Color = x.Color,
                    Description = x.Description,
                    Likes = x.Likes,
                    Material = x.Material,
                    Price = x.Price,
                    OldPrice = x.OldPrice,
                    Producer = x.Producer,
                    Title = x.Title,
                    AddUnitDate = x.AddUnitDate
                }).Take(amount);
        }

        public int GetAmountByFilter(int categoryId, int startPrice, int endPrice)
        {
            return (from units in _repo.GetEntities.Unit
                    where units.price >= startPrice &&
                          units.price <= endPrice &&
                          units.category_id == categoryId
                    select new { units.id }).Count();


        }
    }
}
