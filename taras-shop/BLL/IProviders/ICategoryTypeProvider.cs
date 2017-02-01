using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL.IProviders
{
    public interface ICategoryTypeProvider
    {
        void AddItem(CategoryTypeDto categoryType);
        IEnumerable<CategoryTypeDto> GetAll();
        DTO.CategoryTypeDto GetById(int id);
    }
}
