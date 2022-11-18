using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IdentityWeb.Data
{
    public class MyDbContextDesignTimeFactory : IDesignTimeDbContextFactory<MyDbcontext>
    {
        public MyDbcontext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MyDbcontext> buidler = new DbContextOptionsBuilder<MyDbcontext>();

            buidler.UseSqlServer("Server=.;Database=identity;Trusted_connection=true;TrustServerCertificate=true");

            return new MyDbcontext(buidler.Options);
        }
    }
}
