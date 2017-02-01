using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface INewsImagesProvider
    {
        void AddItem(DTO.Helpers.NewsImagesDto images);
        IEnumerable<DTO.Helpers.NewsImagesDto> GetAll();
        DTO.Helpers.NewsImagesDto GetById(int id);
    }
}
