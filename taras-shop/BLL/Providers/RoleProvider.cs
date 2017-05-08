using BLL.IProviders;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DALLocalDB;
using DALLocalDB.Repository;
using DALLocalDB.IRepository;

namespace BLL.Providers
{
    public class RoleProvider : IRolesProvider
    {
        readonly IRepository<Roles> _repo;
        public RoleProvider(LocalEntities db)
        {
            _repo = new RoleRepository(db);
        }
        public int AddItem(RolesDto role)
        {
            return _repo.AddItem(new Roles()
            {
                role = role.Role
            });
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(RolesDto item)
        {
            _repo.EditItem(new Roles()
            {
                id = item.Id,
                role = item.Role
            });
        }

        public IEnumerable<RolesDto> GetAll()
        {
            return _repo.GetAll().Select(i => new RolesDto()
            {
                Id = i.id,
                Role = i.role
            }).ToList();
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

        public int GetIdByRole(string role)
        {
            return _repo.GetEntities().Roles.Where(x => x.role == role).Select(x => x.id).FirstOrDefault();
        }
    }
}
