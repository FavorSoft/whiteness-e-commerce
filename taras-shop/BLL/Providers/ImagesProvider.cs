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
    public class ImagesProvider : IImagesProvider
    {
        IImagesRepository _repo;
        public ImagesProvider()
        {
            _repo = new ImagesRepository();
        }
        public void AddItem(DTO.Images images)
        {
            _repo.AddItem(new DAL.Images()
            {
                image = images.Image,
                owner_id = images.OwnerId
            });
        }

        public IEnumerable<DTO.Images> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.Images> ConvertModeltoDTO(IQueryable<DAL.Images> repo)
        {
            List<DTO.Images> res = new List<DTO.Images>();
            foreach (var i in repo)
            {
                res.Add(new DTO.Images()
                {
                    Id = i.id,
                    Image = i.image,
                    OwnerId = i.owner_id
                });
            }
            return res;
        }

        public DTO.Images GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new DTO.Images()
            {
                Id = tmp.id,
                Image = tmp.image,
                OwnerId = tmp.owner_id
            };
        }
    }
}
