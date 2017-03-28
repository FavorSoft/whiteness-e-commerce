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
using System.Security.Claims;

namespace BLL.Providers
{
    public class UserProvider : IUserProvider
    {
        readonly IRepository<Users> _repo;
        public UserProvider(Entities context)
        {
            _repo = new UserRepository(context);
        }
        public void AddItem(UsersDto user)
        {
            _repo.AddItem(new Users()
            {
                email = user.Email,
                name = user.Name,
                number = user.Number,
                password = user.Password,
                reg_date = user.RegDate,
                surname = user.Surname,
                role_id = user.RoleId,
                is_man = user.IsMan
            });
        }

        public IEnumerable<UsersDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        public IEnumerable<UsersDto> GetAll(int skip, int amount)
        {
            return ConvertModeltoDTO(_repo.GetAll().OrderByDescending(x => x.email).Skip(skip).Take(amount));
        }

        IEnumerable<UsersDto> ConvertModeltoDTO(IQueryable<Users> repo)
        {
            List<UsersDto> res = repo.Select(i => new UsersDto()
                {
                    Id = i.id,
                    Email = i.email,
                    Name = i.name,
                    Number = i.number,
                    Password = i.password,
                    RegDate = i.reg_date,
                    RoleId = i.role_id,
                    Surname = i.surname,              
                    IsMan = i.is_man
                }).ToList();
            
            return res;
        }
        public UsersDto GetById(int id)
        {
            var i = _repo.GetById(id);
            return new UsersDto()
            {
                Id = i.id,
                Email = i.email,
                Name = i.name,
                Number = i.number,
                Password = i.password,
                RegDate = i.reg_date,
                RoleId = i.role_id,
                Surname = i.surname,
                IsMan = i.is_man
            };
        }
        
        public UsersDto GetByInfo(UsersDto user)
        {
            return _repo.GetAll().Where(x => x.email == user.Email).Select(x => new UsersDto()
            {
                Email = x.email,
                Id = x.id,
                Password = x.password,
                Name = x.name,
                Surname = x.surname,
                Number = x.number,
                RegDate = x.reg_date,
                RoleId = x.role_id,
                IsMan = x.is_man
            }).FirstOrDefault();
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public void EditItem(UsersDto item)
        {
            _repo.EditItem(new Users()
            {
                id = item.Id,
                email = item.Email,
                is_man = item.IsMan,
                name = item.Name,
                number = item.Number,
                password = item.Password,
                reg_date = item.RegDate,
                role_id = item.RoleId,
                surname = item.Surname
            });
        }

        public bool IsInRole(string role, int id)
        {
            bool flag = false;

            int roleId = _repo.GetEntities().Roles.Where(x => x.role == role).FirstOrDefault().id;
            if (roleId == GetById(id).RoleId)
            {
                flag = true;
            }
            return flag;
        }

        public void ChangeRole(int userId, int roleId)
        {
            _repo.GetById(userId).role_id = roleId;
        }
    }
}
