using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DbmsSims.Models
{

    // You can add profile data for the user by adding more properties to your DbmsSimsUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class DbmsSimsUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DbmsSimsUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class DbmsSimsIdentityDbContext : IdentityDbContext<DbmsSimsUser>
    {
        public DbmsSimsIdentityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DbmsSimsIdentityDbContext Create()
        {
            return new DbmsSimsIdentityDbContext();
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
                                                                          //add this to change the column name
            modelBuilder.Entity<DbmsSimsUser>().ToTable("DbmsSimsUser"); //.Property(p => p.Id).HasColumnName("system_user_id");


        }


    }
}