using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTN.TaskManagement.Data.Entities
{
    public class  TTTNTaskManagementDbcontext : DbContext
    {
        public TTTNTaskManagementDbcontext(DbContextOptions<TTTNTaskManagementDbcontext> options) : base(options)
        {
        }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleAction> ModuleActions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationDetail> NotificationDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleModuleAction> RoleModuleActions { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
