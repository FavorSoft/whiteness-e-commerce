using BLL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Facade
{
    public class Facade
    {
        readonly IUnitOfWork uow;
        public Facade(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        private List<Article> ConvertUnitsToArticles(List<UnitDto> units, List<ImagesDto> images)
        {
            List<Article> article = new List<Article>();
            for (int i = 0; i < units.Count; i++)
            {
                article.Add(new Article()
                {
                    unit = units[i],
                    images = images.Where(x => x.OwnerId == units[i].Id)
                });
            }
            return article;
        }

        public IEnumerable<Article> getPopularArticles(int count)
        {
            List<Article> res = new List<Article>();
            var units = uow.getUnit.GetPopular(count);
            res = ConvertUnitsToArticles(units.ToList(), uow.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList());
            return res;
        }

        public IEnumerable<Article> getRecommendsArticles(int count)
        {
            List<Article> res = new List<Article>();
            var units = uow.getUnit.GetPopular(count);
            res = ConvertUnitsToArticles(units.ToList(), uow.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList());
            return res;
        }

        public IUnitOfWork getBasicFunctionality()
        {
            return uow;
        }
    }
}
