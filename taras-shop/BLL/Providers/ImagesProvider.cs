using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;

namespace BLL.Providers
{
    public class ImagesProvider : IImagesProvider
    {
        readonly IRepository<Image> _repo;
        public ImagesProvider(AzureEntities db)
        {
            _repo = new ImagesRepository(db);
        }
        public int AddItem(ImagesDto images)
        {
            return _repo.AddItem(new Image()
            {
                image = images.Image,
                owner_id = images.OwnerId
            });
        }

        public IEnumerable<ImagesDto> GetAll()
        {
            return _repo.GetAll().Select(x => new ImagesDto()
            {
                Id = x.id,
                Image = x.image,
                OwnerId = x.owner_id
            });
        }

        IEnumerable<ImagesDto> ConvertModeltoDTO(IQueryable<Image> repo)
        {
            IEnumerable<ImagesDto> res = repo.Select(i => new ImagesDto()
                {
                    Id = i.id,
                    Image = i.image,
                    OwnerId = i.owner_id
                });
            return res;
        }

        public ImagesDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new ImagesDto()
            {
                Id = tmp.id,
                Image = tmp.image,
                OwnerId = tmp.owner_id
            };
        }
        public IEnumerable<ImagesDto> GetByOwner(int id)
        {
            return _repo.GetAll().Where(x => x.owner_id == id).Select(i => new ImagesDto()
            {
                Id = i.id,
                Image = i.image,
                OwnerId = i.owner_id
            }).ToList();
        }
        public IEnumerable<ImagesDto> GetByOwners(int[] id)
        {
            List<ImagesDto> res = new List<ImagesDto>();
            foreach (int ids in id)
            {
                res.AddRange(_repo.GetAll().Where(x => x.owner_id == ids).Select(i => new ImagesDto()
                {
                    Id = i.id,
                    Image = i.image,
                    OwnerId = i.owner_id
                }));
            }
            return res;
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(ImagesDto item)
        {
            _repo.EditItem(new Image()
            {
                id = item.Id,
                image = item.Image,
                owner_id = item.OwnerId
            });
        }
    }
}
