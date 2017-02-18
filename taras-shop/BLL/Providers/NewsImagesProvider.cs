using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Helpers;
using DAL;
using DAL.Repository;

namespace BLL.IProviders
{
    public class NewsImagesProvider : INewsImagesProvider
    {
        readonly INewsImageRepository _repo;
        public NewsImagesProvider(INewsImageRepository di)
        {
            _repo = di;
        }
        public void AddItem(NewsImagesDto images)
        {
            _repo.AddItem(new News_image()
            {
                image = images.Image,
                owner_id = images.OwnerId
            });
        }

        public IEnumerable<NewsImagesDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<NewsImagesDto> ConvertModeltoDTO(IQueryable<News_image> repo)
        {
            IEnumerable<NewsImagesDto> res = repo.Select(i => new NewsImagesDto()
                {
                    Id = i.id,
                    Image = i.image,
                    OwnerId = i.owner_id
                });
            return res;
        }

        public NewsImagesDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new NewsImagesDto()
            {
                Id = tmp.id,
                Image = tmp.image,
                OwnerId = tmp.owner_id
            };
        }
    }
}
