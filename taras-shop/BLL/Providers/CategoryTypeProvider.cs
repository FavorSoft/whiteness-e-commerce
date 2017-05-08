using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;
using BLL.IProviders;

namespace BLL.Providers
{
    public class CategoryTypeProvider : IProvider<CategoryTypeDto>
    {
        readonly IRepository<Category_type> _repo;
        public CategoryTypeProvider(LocalEntities db)
        {
            _repo = new CategoryTypeRepository(db);
        }
        public int AddItem(CategoryTypeDto category)
        {
            return _repo.AddItem(new Category_type()
            {
                type = category.Type
            });
        }

        public IEnumerable<CategoryTypeDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<CategoryTypeDto> ConvertModeltoDTO(IQueryable<Category_type> repo)
        {
            IEnumerable<CategoryTypeDto> res = repo.Select(i => new CategoryTypeDto()
                {
                    Id = i.id,
                    Type = i.type
                });
            return res;
        }

        public CategoryTypeDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new CategoryTypeDto()
            {
                Id = tmp.id,
                Type = tmp.type
            };
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(CategoryTypeDto item)
        {
            _repo.EditItem(new Category_type()
            {
                id = item.Id,
                type = item.Type
            });
        }
    }
}
