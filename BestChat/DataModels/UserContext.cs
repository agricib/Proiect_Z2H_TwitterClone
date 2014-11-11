
using System.Data.Entity;
using User.Entities;
namespace DataModels
{
    public class UniversityContext : DbContext 
    {
        public DbSet<UserInfo> UserSet { get; set; }

    }
}
