using DTO;

namespace taras_shop.Models
{
    public class ItemPageModels : Article
    {
        public ItemPageModels(Article article)
        {
            base.category = article.category;
            base.images = article.images;
            base.sizes = article.sizes;
            base.unit = article.unit;
            base.unitsInfo = article.unitsInfo;
        }

        public string CategoryType { get; set; }
    }
}