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
            List<Article> articles = new List<Article>();
            for (int i = 0; i < units.Count; i++)
            {
                int id = units[i].Id;
                IDictionary<SizesDto, UnitInfoDto> sizes = new Dictionary<SizesDto, UnitInfoDto>();
                foreach (var j in uow.getUnitInfo.GetByOwner(id))
                {
                    sizes.Add(new KeyValuePair<SizesDto, UnitInfoDto>(uow.getSizes.GetAll().Where(x => x.Id == j.SizeId).FirstOrDefault(), j));
                }
                
                articles.Add(new Article()
                {
                    unit = units[i],
                    images = images.Where(x => x.OwnerId == id).ToList(),
                    category = uow.getCategory.GetById(units[i].CategoryId),
                    sizes = sizes
                });
            }
            return articles;
        }
        private Article ConvertUnitToArticle(UnitDto unit, List<ImagesDto> images)
        {
            IDictionary<SizesDto, UnitInfoDto> sizes = new Dictionary<SizesDto, UnitInfoDto>();
            foreach (var i in uow.getUnitInfo.GetByOwner(unit.Id))
            {
                sizes.Add(new KeyValuePair<SizesDto, UnitInfoDto>(uow.getSizes.GetAll().Where(x => x.Id == i.SizeId).FirstOrDefault(), i));
            }
            Article article = new Article()
            {
                unit = unit,
                images = images.Where(x => x.OwnerId == unit.Id).ToList(),
                category = uow.getCategory.GetById(unit.CategoryId),
                sizes = sizes
            };

            return article;
        }

        public IEnumerable<Article> getPopularArticles(int count)
        { 
            var units = uow.getUnit.GetPopular(count);
            return ConvertUnitsToArticles(units.ToList(), uow.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList());
        }


        public IEnumerable<Article> getRecommendsArticles(int count)
        {
            List<Article> res = new List<Article>();
            var units = uow.getUnit.GetPopular(count);
            res = ConvertUnitsToArticles(units.ToList(), uow.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList());
            return res;
        }

        public Article getArticleById(int id)
        {
            return ConvertUnitToArticle(uow.getUnit.GetById(id), uow.getImages.GetByOwner(id).ToList());
        }

        public IUnitOfWork getBasicFunctionality()
        {
            return uow;
        }
    }
}
