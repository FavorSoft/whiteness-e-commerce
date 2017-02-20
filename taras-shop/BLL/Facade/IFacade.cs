using BLL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IFacade
{
    public interface IFacade
    {
        IUnitOfWork getBasicFunctionality();
        IEnumerable<Article> getPopularArticles(int count);
        IEnumerable<Article> getRecommendsArticles(int count);
    }
}
