using DAL;
using DAL.IRepository;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Providers
{
    public class SizesProvider : IProviders.IProvider<SizesDto>
    {
        readonly IRepository<Sizes> _repo;
        public SizesProvider(Entities db)
        {
            _repo = new SizesRepository(db);
        }

        public void AddItem(SizesDto item)
        {
            _repo.AddItem(new Sizes()
            {
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
    }
}
