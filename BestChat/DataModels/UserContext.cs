
using System.Data.Entity;
using User.Entities;
namespace DataModels
{
    public class UserContext : DbContext 
    {
        public DbSet<UserInfo> UserSet { get; set; }

    }
}
