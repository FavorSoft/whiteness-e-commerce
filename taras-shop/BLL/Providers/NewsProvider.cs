using BLL.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repositories;

namespace BLL.Providers
{
    public class NewsProvider : INewsProvider
    {
        INewsRepository _repo;
        public NewsProvider()
        {
            _repo = new NewsRepository();
        }

        public void AddItem(DTO.News category)
        {
            _repo.AddItem(new DAL.News()
            {
                data_create = category.DataCreate,
                description = category.Description,
                title = category.Title
            });
        }

        public IEnumerable<DTO.News> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.News>ConvertModeltoDTO(IQueryable<DAL.News> repo)
        {
            List<DTO.News> res = new List<DTO.News>();
            foreach (var i in repo)
            {
                res.Add(new DTO.News()
                {
                    Id = i.id,
                    DataCreate = i.data_create,
                    Title = i.title,
                    Description = i.description
                });
            }
            return res;
        }

        public DTO.News GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new DTO.News()
            {
                Id = tmp.id,
                DataCreate = tmp.data_create,
                Description = tmp.description,
                Title = tmp.title
            };
        }
    }
}
