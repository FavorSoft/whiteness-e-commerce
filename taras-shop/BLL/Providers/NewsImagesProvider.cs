using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Helpers;
using DAL;
using DAL.Repositories;

namespace BLL.IProviders
{
    public class NewsImagesProvider : INewsImagesProvider
    {
        INewsImageRepository _repo;
        public NewsImagesProvider()
        {
            _repo = new NewsImageRepository();
        }
        public void AddItem(NewsImages images)
        {
            _repo.AddItem(new News_image()
            {
                image = images.Image,
                owner_id = images.OwnerId
            });
        }

        public IEnumerable<NewsImages> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.Helpers.NewsImages> ConvertModeltoDTO(IQueryable<DAL.News_image> repo)
        {
            List<DTO.Helpers.NewsImages> res = new List<DTO.Helpers.NewsImages>();
            foreach (var i in repo)
            {
                res.Add(new DTO.Helpers.NewsImages()
                {
                    Id = i.id,
                    Image = i.image,
                    OwnerId = i.owner_id
                });
            }
            return res;
        }

        public NewsImages GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new NewsImages()
            {
                Id = tmp.id,
                Image = tmp.image,
                OwnerId = tmp.owner_id
            };
        }
    }
}
