using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Repository;
using DAL.IRepository;
using DAL;
using BLL.IProviders;

namespace BLL.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        readonly IRepository<Categories> _repo;
        public CategoryProvider(Entities db)
        {
            _repo = new CategoriesRepository(db);
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

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(CategoriesDto item)
        {
            _repo.EditItem(new Categories()
            {
                category = item.Category,
                category_img = item.CategoryImg,
                description = item.Description,
                id = item.Id,
                type_id = item.TypeId
            });
        }

        public CategoriesDto getCategoryByInfo(int typeId, string category)
        {
            var tmp = _repo.GetById(1);
            CategoriesDto category1 = new CategoriesDto()
            {
                Category = tmp.category,
                CategoryImg = tmp.category_img,
                Id = tmp.id,
                Description = tmp.description,
                TypeId = tmp.type_id
            };
            return category1;
        }
    }
}
