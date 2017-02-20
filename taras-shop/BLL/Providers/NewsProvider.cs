using BLL.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repository;
using DAL.IRepository;

namespace BLL.Providers
{
    public class NewsProvider : IProvider<NewsDto>
    {
        readonly IRepository<News> _repo;
        public NewsProvider(Entities db)
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
    }
}
