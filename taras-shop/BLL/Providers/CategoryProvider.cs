using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Repositories;
namespace BLL.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        DAL.ICategoriesRepository _repo;
        public CategoryProvider()
        {
            _repo = new DAL.Repositories.CategoriesRepository();
        }
        public void AddItem(Categories category)
        {
            _repo.AddItem(new DAL.Categories()
            {
                category = category.Category,
                category_img = category.CategoryImg,
                type_id = category.TypeId,
                description = category.Description   
            });
        }

        public IEnumerable<Categories> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<Categories> ConvertModeltoDTO(IQueryable<DAL.Categories> repo)
        {
            List<Categories> res = new List<Categories>();
            foreach(var i in repo)
            {
                res.Add(new Categories()
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

        public Categories GetById(int id)
        {
            var tmp = _repo.GetById(id);
            DTO.Categories category = new Categories()
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
