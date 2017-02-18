using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Repository;
using DAL;
using BLL.IProviders;

namespace BLL.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        readonly ICategoriesRepository _repo;
        public CategoryProvider(ICategoriesRepository di)
        {
            _repo = di;
        }
        public void AddItem(CategoriesDto category)
        {
            _repo.AddItem(new Categories()
            {
                category = category.Category,
                category_img = category.CategoryImg,
                type_id = category.TypeId,
                description = category.Description   
            });
        }

        public IEnumerable<CategoriesDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<CategoriesDto> ConvertModeltoDTO(IQueryable<Categories> repo)
        {
            IEnumerable<CategoriesDto> res = repo.Select(i => new CategoriesDto()
                {
                    Id = i.id,
                    Category = i.category,
                    CategoryImg = i.category_img,
                    Description = i.description,
                    TypeId = i.type_id
                });
            return res;
        }

        public CategoriesDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            CategoriesDto category = new CategoriesDto()
            {
                Category = tmp.category,
                CategoryImg = tmp.category_img,
                Id = tmp.id,
                Description = tmp.description,
                TypeId = tmp.type_id
            };
            return category;
        }
    }
}
