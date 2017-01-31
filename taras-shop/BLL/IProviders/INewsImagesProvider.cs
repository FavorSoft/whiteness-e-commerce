using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface INewsImagesProvider
    {
        void AddItem(DTO.Helpers.NewsImages images);
        IEnumerable<DTO.Helpers.NewsImages> GetAll();
        DTO.Helpers.NewsImages GetById(int id);
    }
}
