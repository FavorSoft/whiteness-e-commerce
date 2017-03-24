using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Identity
{
    public class UserIdentityRepository : IRepository<UsersIdentity>
    {
        IdentityContext context;
        public UserIdentityRepository()
        {
            context = new IdentityContext();
        }
        public void AddItem(UsersIdentity item)
        {
            context.Users.Add(item);
        }

        public void DeleteItem(int id)
        {
            context.Users.Remove(new UsersIdentity() { Id = id });
        }

        public void EditItem(UsersIdentity item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UsersIdentity> GetAll()
        {
            return context.Users;
        }

        public UsersIdentity GetById(int id)
        {
            return context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
