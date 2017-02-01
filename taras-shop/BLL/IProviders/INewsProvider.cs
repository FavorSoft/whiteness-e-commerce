using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface INewsProvider
    {
        void AddItem(DTO.NewsDto category);
        IEnumerable<DTO.NewsDto> GetAll();
        DTO.NewsDto GetById(int id);
    }
}
