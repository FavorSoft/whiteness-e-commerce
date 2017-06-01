using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class SliderImagesRepository : IRepository<Slider_images>
    {
        public SliderImagesRepository(AzureEntities db) : base(db)
        {

        }

        public override int AddItem(Slider_images item)
        {
            return entities.Slider_images.Add(item).Id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Slider_images.FirstOrDefault(x => x.Id == id);
            entities.Slider_images.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Slider_images item)
        {
            entities.Slider_images.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Slider_images> GetAll()
        {
            return entities.Slider_images;
        }

        public override Slider_images GetById(int id)
        {
            return entities.Slider_images.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
