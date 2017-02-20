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
    public class UserProvider : IProvider<UsersDto>
    {
        readonly IRepository<Users> _repo;
        public UserProvider(Entities db)
        {
            _repo = new UserRepository(db);
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
                role_id = user.RoleId
            });
        }

        public IEnumerable<UsersDto> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
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
                    Surname = i.surname
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
                Surname = i.surname
            };
        }
    }
}
