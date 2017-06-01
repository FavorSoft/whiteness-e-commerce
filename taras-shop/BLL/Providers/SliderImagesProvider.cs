using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DTO.Exceptions;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;
using System;
using DTO.Helpers;

namespace BLL.Providers
{
    public class SliderImagesProvider : IProvider<SliderImagesDto>
    {
        readonly IRepository<Slider_images> _repo;
        public SliderImagesProvider(AzureEntities db)
        {
            _repo = new SliderImagesRepository(db);
        }
        public int AddItem(SliderImagesDto item)
        {
            return _repo.AddItem(new Slider_images()
            {
                Image = item.Image
            });
        }

        public IEnumerable<SliderImagesDto> GetAll()
        {
            return _repo.GetAll().Select(i => new SliderImagesDto()
            {
                Id = i.Id,
                Image = i.Image
            }).ToList();
        }

        public SliderImagesDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new SliderImagesDto()
            {
                Id = tmp.Id,
                Image = tmp.Image
            };
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(SliderImagesDto item)
        {
            _repo.EditItem(new Slider_images()
            {
                Id = item.Id,
                Image = item.Image                
            });
        }
    }
}
