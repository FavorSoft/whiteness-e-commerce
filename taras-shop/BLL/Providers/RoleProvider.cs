using BLL.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repositories;

namespace BLL.Providers
{
    public class RoleProvider : IRoleProvider
    {
        IRoleRepository _repo;
        public RoleProvider()
        {
            _repo = new RoleRepository();
        }
        public void AddItem(DTO.Roles role)
        {
            _repo.AddItem(new DAL.Roles()
            {
                role = role.Role
            });
        }

        public IEnumerable<DTO.Roles> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.Roles> ConvertModeltoDTO(IQueryable<DAL.Roles> repo)
        {
            List<DTO.Roles> res = new List<DTO.Roles>();
            foreach (var i in repo)
            {
                res.Add(new DTO.Roles()
                {
                    Id = i.id,
                    Role = i.role
                });
            }
            return res;
        }

        public DTO.Roles GetById(int id)
        {
            var tmp = _repo.GetById(id);
            return new DTO.Roles()
            {
                Id = tmp.id,
                Role = tmp.role
            };
        }
    }
}
