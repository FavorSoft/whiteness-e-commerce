using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SizesRepository : IRepository.IRepository<Sizes>
    {
        public SizesRepository(Entities db) : base(db)
        {
        }

        public override void AddItem(Sizes item)
        {
            entities.Sizes.Add(item);
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Sizes.FirstOrDefault(x => x.id == id);
            entities.Sizes.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Sizes item)
        {
            entities.Sizes.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Sizes> GetAll()
        {
            return entities.Sizes;
        }

        public override Sizes GetById(int id)
        {
            return entities.Sizes.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
