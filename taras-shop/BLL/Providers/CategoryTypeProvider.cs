using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repository;
using BLL.IProviders;

namespace BLL.Providers
{
    public class CategoryTypeProvider : ICategoryTypeProvider
    {
        readonly ICategoryTypeRepository _repo;
        public CategoryTypeProvider(ICategoryTypeRepository di)
        {
            _repo = di;
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
