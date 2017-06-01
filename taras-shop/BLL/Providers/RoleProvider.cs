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
        readonly IRepository<Role> _repo;
        public RoleProvider(AzureEntities db)
        {
            _repo = new RoleRepository(db);
        }
        public int AddItem(RolesDto role)
        {
            return _repo.AddItem(new Role()
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
            _repo.EditItem(new Role()
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
