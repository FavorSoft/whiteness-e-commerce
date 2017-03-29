using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;

namespace BLL.Providers
{
    public class NewsProvider : IProvider<NewsDto>
    {
        readonly IRepository<News> _repo;
        public NewsProvider(LocalEntities db)
        {
            _repo = new NewsRepository(db);
        }

        public void AddItem(NewsDto category)
        {
            _repo.AddItem(new News()
            {
                data_create = category.DataCreate,
                description = category.Description,
                title = category.Title
            });
        }

        public IEnumerable<NewsDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<NewsDto>ConvertModeltoDTO(IQueryable<News> repo)
        {
            IEnumerable<NewsDto> res = repo.Select(i => new NewsDto()
                {
                    Id = i.id,
                    DataCreate = i.data_create,
                    Title = i.title,
                    Description = i.description
                });
            return res;
        }

        public NewsDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new NewsDto()
            {
                Id = tmp.id,
                DataCreate = tmp.data_create,
                Description = tmp.description,
                Title = tmp.title
            };
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(NewsDto item)
        {
            _repo.EditItem(new News()
            {
                data_create = item.DataCreate,
                description = item.Description,
                id = item.Id,
                title = item.Title
            });
        }
    }
}
