using BLL.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repository;
using DAL.IRepository;

namespace BLL.Providers
{
    public class RoleProvider : IProvider<RolesDto>
    {
        readonly IRepository<Roles> _repo;
        public RoleProvider(Entities db)
        {
            _repo = new RoleRepository(db);
        }
        public void AddItem(RolesDto role)
        {
            _repo.AddItem(new Roles()
            {
                role = role.Role
            });
        }

        public IEnumerable<RolesDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        IEnumerable<RolesDto> ConvertModeltoDTO(IQueryable<Roles> repo)
        {
            List<RolesDto> res = repo.Select(i => new RolesDto()
                {
                    Id = i.id,
                    Role = i.role
                }).ToList();
            return res;
        }

        public RolesDto GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new RolesDto()
            {
                Id = tmp.id,
                Role = tmp.role
            };
        }
    }
}
