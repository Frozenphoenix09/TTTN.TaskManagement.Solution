using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TTTN.TaskManagement.Data.Entities
{
    public class TTTNDbContextFactory : IDesignTimeDbContextFactory<TTTNTaskManagementDbcontext>
    {
        public TTTNTaskManagementDbcontext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<TTTNTaskManagementDbcontext>();
            optionBuilder.UseSqlServer("Data Source=DESKTOP-6DN1B2N;Initial Catalog=TaskMangement;User Id=TaskManagement;Password=12344321;");
            return new TTTNTaskManagementDbcontext(optionBuilder.Options);
        }
    }
}
