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
    public class ImagesProvider : IImagesProvider
    {
        readonly IRepository<Images> _repo;
        public ImagesProvider(Entities db)
        {
            _repo = new ImagesRepository(db);
        }
        public void AddItem(ImagesDto images)
        {
            _repo.AddItem(new Images()
            {
                image = images.Image,
                owner_id = images.OwnerId
            });
        }

        public IEnumerable<ImagesDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<ImagesDto> ConvertModeltoDTO(IQueryable<Images> repo)
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
            return ConvertModeltoDTO(_repo.GetAll().Where(x => x.owner_id == id)); ;
        }
        public IEnumerable<ImagesDto> GetByOwners(int[] id)
        {
            List<ImagesDto> res = new List<ImagesDto>();
            foreach (int i in id)
            {
                res.AddRange(ConvertModeltoDTO(_repo.GetAll().Where(x => x.owner_id == i)));
            }
            return res;
        }
    }
}
