using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface INewsProvider
    {
        void AddItem(DTO.News category);
        IEnumerable<DTO.News> GetAll();
        DTO.News GetById(int id);
    }
}
