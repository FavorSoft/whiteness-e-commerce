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
        IEnumerable<Article> getArticleById(int id);
        IEnumerable<Article> getRecommendsArticles(int count);
        bool isUserInRole(string username, string role);
        void changeRole(int userId, string role);
    }
}
