using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICategoryProvider
    {
        void AddItem(DTO.Categories category);
        IEnumerable<DTO.Categories> GetAll();
        DTO.Categories GetById(int id);
    }
}
