using BLL.IProviders;
using DALLocalDB;
using DALLocalDB.IRepository;
using DALLocalDB.Repositories;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Providers
{
    public class SizesProvider : ISizesProvider
    {
        readonly IRepository<Size> _repo;
        public SizesProvider(AzureEntities db)
        {
            _repo = new SizesRepository(db);
        }

        public int AddItem(SizesDto item)
        {
            return _repo.AddItem(new Size()
            {
                size = item.Size
            });
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(SizesDto item)
        {
            _repo.EditItem(new Size()
            {
                id = item.Id,
                size = item.Size
            });
        }

        public IEnumerable<SizesDto> GetAll()
        {
            return _repo.GetAll().Select(x => new SizesDto()
            {
                Id = x.id,
                Size = x.size
            });
        }

        public SizesDto GetById(int id)
        {
            var res = _repo.GetById(id);
            return new SizesDto()
            {
                Id = res.id,
                Size = res.size
            };
        }

        public List<int> GetIdsBySizes(List<string> sizes)
        {

            var res = _repo.GetAll().Select(x => new SizesDto()
            {
                Id = x.id,
                Size = x.size
            }).Where(x => sizes.Contains(x.Size)).Select(x => x.Id).ToList();
            return res;
        }
    }
}
