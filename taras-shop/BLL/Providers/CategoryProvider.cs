using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;
using DALLocalDB;
using BLL.IProviders;

namespace BLL.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        readonly IRepository<Categories> _repo;
        public CategoryProvider(LocalEntities db)
        {
            _repo = new CategoriesRepository(db);
        }
        public int AddItem(CategoriesDto category)
        {
            return _repo.AddItem(new Categories()
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
            CategoriesDto res = null;
            if (typeId!= 0)
            {
                res = (from categories in _repo.GetEntities().Categories
                           join s in _repo.GetEntities().Category_type on categories.type_id equals s.id
                           where s.id == typeId && categories.category == category
                           select new
                           {
                               Id = categories.id,
                               Category = categories.category,
                               CategoryImg = categories.category_img,
                               Description = categories.description,
                               TypeId = categories.type_id
                           }
                      ).Select(x => new CategoriesDto()
                      {
                          Category = x.Category,
                          CategoryImg = x.CategoryImg,
                          Description = x.Description,
                          Id = x.Id,
                          TypeId = x.TypeId
                      }).FirstOrDefault();
            }
            

            return res;
        }
    }
}
