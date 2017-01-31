using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Repositories;
using DAL;
namespace BLL.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        DAL.ICategoriesRepository _repo;
        public CategoryProvider(ICategoriesRepository di)
        {
            _repo = di;
        }
        public void AddItem(DTO.Categories category)
        {
            _repo.AddItem(new DAL.Categories()
            {
                category = category.Category,
                category_img = category.CategoryImg,
                type_id = category.TypeId,
                description = category.Description   
            });
        }

        public IEnumerable<DTO.Categories> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.Categories> ConvertModeltoDTO(IQueryable<DAL.Categories> repo)
        {
            List<DTO.Categories> res = new List<DTO.Categories>();
            foreach(var i in repo)
            {
                res.Add(new DTO.Categories()
                {
                    Id = i.id,
                    Category = i.category,
                    CategoryImg = i.category_img,
                    Description = i.description,
                    TypeId = i.type_id
                });
            }
            return res;
        }

        public DTO.Categories GetById(int id)
        {
            var tmp = _repo.GetById(id);
            DTO.Categories category = new DTO.Categories()
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
