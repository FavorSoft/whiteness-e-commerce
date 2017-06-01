using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;
using System;
using System.Linq.Expressions;

namespace BLL.Providers
{
    public class UnitProvider : IUnitProvider
    {
        readonly IRepository<Unit> _repo;
        public UnitProvider(AzureEntities db)
        {
            _repo = new UnitRepository(db);
        }
        public int AddItem(UnitDto unit)
        {
            return _repo.AddItem(new Unit()
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
        public IEnumerable<UnitDto> GetByIds(List<int> ids)
        {
            var res = _repo.GetAll().Where(x => ids.Contains(x.id)).Select(i => new UnitDto()
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
            return res.ToList();
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

        public IEnumerable<UnitDto> GetByFilter(List<int> categoryIds, int startPrice, int endPrice, List<int> sizeIds, int skipItems, int amount)
        {
            var first = _repo.GetEntities().Units.Join(_repo.GetEntities().UnitInfoes,
            a => a.id,
            b => b.unit_id,
            (a, b) => new
            {
                Id = a.id,
                CategoryId = a.category_id,
                AddUnitDate = a.add_date,
                Color = a.color,
                Description = a.description,
                Likes = a.likes,
                Material = a.material,
                OldPrice = a.old_price,
                Price = a.price,
                Producer = a.producer,
                Title = a.title,
                SizeId = b.size_id,
                Amount = b.amount
            }).AsQueryable();
            var second = first.Where(x => x.Amount > 0 &&
                x.Price >= startPrice &&
                x.Price <= endPrice && 
                sizeIds.Contains(x.SizeId)).GroupBy(g => g.Id);
            if (categoryIds.Count != 0)
            {
                second = first.Where(x => x.Amount > 0 &&
                x.Price >= startPrice &&
                x.Price <= endPrice &&
                categoryIds.Contains(x.CategoryId) &&
                sizeIds.Contains(x.SizeId)).GroupBy(g => g.Id);
            }
            var third = second.OrderBy(x => x.FirstOrDefault().AddUnitDate).Skip(skipItems);
            var fourth = third.Select(unit => new UnitDto()
            {
                Id = unit.FirstOrDefault().Id,
                CategoryId = unit.FirstOrDefault().CategoryId,
                Color = unit.FirstOrDefault().Color,
                Description = unit.FirstOrDefault().Description,
                Likes = unit.FirstOrDefault().Likes,
                Material = unit.FirstOrDefault().Material,
                Price = unit.FirstOrDefault().Price,
                OldPrice = unit.FirstOrDefault().OldPrice,
                Producer = unit.FirstOrDefault().Producer,
                Title = unit.FirstOrDefault().Title,
                AddUnitDate = unit.FirstOrDefault().AddUnitDate
            });

            var sixth = fourth.Take(amount);
            return sixth.ToList();
        }
        public IEnumerable<UnitDto> GetByFilter(List<int> categoryIds, int startPrice, int endPrice, int skipItems, int amount)
        {
            var first = _repo.GetEntities().Units.Join(_repo.GetEntities().UnitInfoes,
            a => a.id,
            b => b.unit_id,
            (a, b) => new
            {
                Id = a.id,
                CategoryId = a.category_id,
                AddUnitDate = a.add_date,
                Color = a.color,
                Description = a.description,
                Likes = a.likes,
                Material = a.material,
                OldPrice = a.old_price,
                Price = a.price,
                Producer = a.producer,
                Title = a.title,
                SizeId = b.size_id,
                Amount = b.amount
            });
            var second = first.Where(x => x.Amount > 0 &&
                x.Price >= startPrice &&
                x.Price <= endPrice).GroupBy(g => g.Id);
            if (categoryIds.Count != 0)
            {
                second = first.Where(x => x.Amount > 0 &&
                x.Price >= startPrice &&
                x.Price <= endPrice &&
                categoryIds.Contains(x.CategoryId)).GroupBy(g => g.Id);
            }
            var third = second.OrderBy(x => x.FirstOrDefault().AddUnitDate).Skip(skipItems);
            var fourth = third.Select(unit => new UnitDto()
            {
                Id = unit.FirstOrDefault().Id,
                CategoryId = unit.FirstOrDefault().CategoryId,
                Color = unit.FirstOrDefault().Color,
                Description = unit.FirstOrDefault().Description,
                Likes = unit.FirstOrDefault().Likes,
                Material = unit.FirstOrDefault().Material,
                Price = unit.FirstOrDefault().Price,
                OldPrice = unit.FirstOrDefault().OldPrice,
                Producer = unit.FirstOrDefault().Producer,
                Title = unit.FirstOrDefault().Title,
                AddUnitDate = unit.FirstOrDefault().AddUnitDate
            });

            var sixth = fourth.Take(amount);
            return sixth.ToList();
        }


        public int GetAmountUnit(List<int> categoryIds, int startPrice, int endPrice, int skipItems, int amount)
        {
            var first = _repo.GetEntities().Units.Join(_repo.GetEntities().UnitInfoes,
            a => a.id,
            b => b.unit_id,
            (a, b) => new
            {
                Id = a.id,
                CategoryId = a.category_id,
                AddUnitDate = a.add_date,
                Color = a.color,
                Description = a.description,
                Likes = a.likes,
                Material = a.material,
                OldPrice = a.old_price,
                Price = a.price,
                Producer = a.producer,
                Title = a.title,
                SizeId = b.size_id,
                Amount = b.amount
            });
            var second = first.Where(x => x.Amount > 0 &&
                x.Price >= startPrice &&
                x.Price <= endPrice);
            if (categoryIds.Count != 0)
            {
                second = first.Where(x => x.Amount > 0 &&
                x.Price >= startPrice &&
                x.Price <= endPrice &&
                categoryIds.Contains(x.CategoryId));
            }
            var third = second.GroupBy(g => g.Id);
            var fourth = third.Select(unit => new UnitDto()
            {
                Id = unit.FirstOrDefault().Id,
                CategoryId = unit.FirstOrDefault().CategoryId,
                Color = unit.FirstOrDefault().Color,
                Description = unit.FirstOrDefault().Description,
                Likes = unit.FirstOrDefault().Likes,
                Material = unit.FirstOrDefault().Material,
                Price = unit.FirstOrDefault().Price,
                OldPrice = unit.FirstOrDefault().OldPrice,
                Producer = unit.FirstOrDefault().Producer,
                Title = unit.FirstOrDefault().Title,
                AddUnitDate = unit.FirstOrDefault().AddUnitDate
            }).Count();
            return fourth;
        }
        public int GetAmountUnit(List<int> categoryIds, int startPrice, int endPrice, List<int> sizeIds, int skipItems, int amount)
        {
            var first = _repo.GetEntities().Units.Join(_repo.GetEntities().UnitInfoes,
            a => a.id,
            b => b.unit_id,
            (a, b) => new
            {
                Id = a.id,
                CategoryId = a.category_id,
                AddUnitDate = a.add_date,
                Color = a.color,
                Description = a.description,
                Likes = a.likes,
                Material = a.material,
                OldPrice = a.old_price,
                Price = a.price,
                Producer = a.producer,
                Title = a.title,
                SizeId = b.size_id,
                Amount = b.amount
            }).AsQueryable();
            var second = first.Where(x => x.Amount > 0 &&
                x.Price >= startPrice &&
                x.Price <= endPrice &&
                sizeIds.Contains(x.SizeId));
            if (categoryIds.Count != 0)
            {
                second = first.Where(x => x.Amount > 0 &&
                x.Price >= startPrice &&
                x.Price <= endPrice &&
                categoryIds.Contains(x.CategoryId) &&
                sizeIds.Contains(x.SizeId));
            }
            var third = second.GroupBy(g => g.Id);
            var fourth = third.Select(unit => new UnitDto()
            {
                Id = unit.FirstOrDefault().Id,
                CategoryId = unit.FirstOrDefault().CategoryId,
                Color = unit.FirstOrDefault().Color,
                Description = unit.FirstOrDefault().Description,
                Likes = unit.FirstOrDefault().Likes,
                Material = unit.FirstOrDefault().Material,
                Price = unit.FirstOrDefault().Price,
                OldPrice = unit.FirstOrDefault().OldPrice,
                Producer = unit.FirstOrDefault().Producer,
                Title = unit.FirstOrDefault().Title,
                AddUnitDate = unit.FirstOrDefault().AddUnitDate
            }).Count();

            return fourth;

        }
    }
}