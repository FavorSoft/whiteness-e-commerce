using System.Collections.Generic;
using System.Linq;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;
using DTO;

namespace BLL.IProviders
{
    public class NewsImagesProvider : IProvider<NewsImagesDto>
    {
        readonly IRepository<News_image> _repo;
        public NewsImagesProvider(LocalEntities db)
        {
            _repo = new NewsImageRepository(db);
        }
        public int AddItem(NewsImagesDto images)
        {
            return _repo.AddItem(new News_image()
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

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(NewsImagesDto item)
        {
            _repo.EditItem(new News_image()
            {
                id = item.Id,
                image = item.Image,
                owner_id = item.OwnerId
            });
        }
    }
}
