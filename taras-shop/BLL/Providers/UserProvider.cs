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
    public class UserProvider : IUserProvider
    {
        IUserRepositiry _repo;
        public UserProvider()
        {
            _repo = new UserRepository();
        }
        public void AddItem(DTO.Users user)
        {
            _repo.AddItem(new DAL.Users()
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

        public IEnumerable<DTO.Users> GetAll()
        {
            return ConvertModeltoDTO(_repo.GetAll());
        }

        List<DTO.Users> ConvertModeltoDTO(IQueryable<DAL.Users> repo)
        {
            List<DTO.Users> res = new List<DTO.Users>();
            foreach (var i in repo)
            {
                res.Add(new DTO.Users()
                {
                    Id = i.id,
                    Email = i.email,
                    Name = i.name,
                    Number = i.number,
                    Password = i.password,
                    RegDate = i.reg_date,
                    RoleId = i.role_id,
                    Surname = i.surname
                });
            }
            return res;
        }
        public DTO.Users GetById(int id)
        {
            var i = _repo.GetById(id);
            return new DTO.Users()
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
