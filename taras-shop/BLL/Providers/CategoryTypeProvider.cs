using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repositories;
using BLL.IProviders;

namespace BLL.Providers
{
    public class CategoryTypeProvider : ICategoryTypeProvider
    {
        ICategoryTypeRepository _repo;
        public CategoryTypeProvider()
        {
            _repo = new CategoryTypeRepository();
        }
        public void AddItem(DTO.CategoryType category)
        {
            _repo.AddItem(new Category_type()
            {
                type = category.Type
            });
        }

        public IEnumerable<DTO.CategoryType> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<CategoryType> ConvertModeltoDTO(IQueryable<DAL.Category_type> repo)
        {
            List<CategoryType> res = new List<CategoryType>();
            foreach (var i in repo)
            {
                res.Add(new CategoryType()
                {
                    Id = i.id,
                    Type = i.type
                });
            }
            return res;
        }

        public DTO.CategoryType GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new CategoryType()
            {
                Id = tmp.id,
                Type = tmp.type
            };
        }
    }
}
