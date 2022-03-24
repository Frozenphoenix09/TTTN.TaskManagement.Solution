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
            optionBuilder.UseSqlServer("Data Source=DESKTOP-68VUDPF\\DATHUNG;Initial Catalog=TaskMangement;Trusted_Connection=True;");
            return new TTTNTaskManagementDbcontext(optionBuilder.Options);
        }
    }
}
