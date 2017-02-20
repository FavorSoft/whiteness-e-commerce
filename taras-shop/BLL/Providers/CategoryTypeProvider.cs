using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repository;
using DAL.IRepository;
using BLL.IProviders;

namespace BLL.Providers
{
    public class CategoryTypeProvider : IProvider<CategoryTypeDto>
    {
        readonly IRepository<Category_type> _repo;
        public CategoryTypeProvider(Entities db)
        {
            _repo = new CategoryTypeRepository(db);
        }
        public void AddItem(CategoryTypeDto category)
        {
            _repo.AddItem(new Category_type()
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
    }
}
