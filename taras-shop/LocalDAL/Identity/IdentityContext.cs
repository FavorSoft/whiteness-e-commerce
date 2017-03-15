using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Identity
{
    class IdentityContext : DbContext
    {
        public IdentityContext() :
            base("DefaultConnection")
        { }

        public DbSet<UsersIdentity> Users { get; set; }

    }
}
