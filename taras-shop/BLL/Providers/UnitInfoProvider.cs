using BLL.IProviders;
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
    public class UnitInfoProvider : IUnitInfoProvider
    {
        readonly IRepository<UnitInfo> _repo;
        public UnitInfoProvider(Entities db)
        {
            _repo = new UnitInfoRepository(db);
        }
        public void AddItem(UnitInfoDto item)
        {
            _repo.AddItem(new UnitInfo()
            {
                amount = item.Amount,
                size_id = item.SizeId,
                unit_id = item.UnitId
            });
        }

        public IEnumerable<UnitInfoDto> GetAll()
        {
            return _repo.GetAll().Select(x => new UnitInfoDto()
            {
                Amount = x.amount,
                Id = x.id,
                SizeId = x.size_id,
                UnitId = x.unit_id
            });
        }

        public UnitInfoDto GetById(int id)
        {
            var res = _repo.GetById(id);
            return new UnitInfoDto()
            {
                Amount = res.amount,
                Id = res.id,
                SizeId = res.size_id,
                UnitId = res.unit_id
            };
        }

        public IEnumerable<UnitInfoDto> GetByOwner(int id)
        {
            return _repo.GetAll().Where(x => x.unit_id == id).Select(x => new UnitInfoDto()
            {
                Id = x.id,
                Amount = x.amount,
                SizeId = x.size_id,
                UnitId = x.unit_id
            });
        }

        public IEnumerable<UnitInfoDto> GetByOwners(int[] ids)
        {
            List<UnitInfoDto> res = new List<UnitInfoDto>();
            foreach(int id in ids)
            {
                var i = _repo.GetById(id);
                res.Add(new UnitInfoDto()
                { 
                    Amount = i.amount,
                    Id = i.id,
                    SizeId = i.size_id,
                    UnitId = i.unit_id
                });
            }

            return res;
        }
    }
}
