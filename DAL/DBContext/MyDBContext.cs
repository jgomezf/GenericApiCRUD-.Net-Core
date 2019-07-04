using Audit.Core;
using Audit.EntityFramework;
using DAL.Migrations;
using DAL.Repository;
using ENT.Ent;
using ENT.Resources;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using ViewModel.Enumerations;

namespace DAL.DBContext
{
    public sealed class MyDBContext : AuditDbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            DbInitializer.Initialize(this);
            AuditEventType = "{database}_{context}";
            Mode = AuditOptionMode.OptOut;
            IncludeEntityObjects = false;
            Audit.Core.Configuration.DataProvider = new AuditProvider();
        }

        public MyDBContext()
        {
            DbInitializer.Initialize(this);
            AuditEventType = "{database}_{context}";
            Mode = AuditOptionMode.OptOut;
            IncludeEntityObjects = false;
            Audit.Core.Configuration.DataProvider = new AuditProvider();
        }

        

        public DbSet<Person> Person { get; set; }
        public DbSet<Country> Country { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
           .UseSqlServer(ConfigurationEnum.BaseConn);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override void OnScopeSaving(AuditScope auditScope)
        {
            if (!Singleton.Instance.Audit) auditScope.Discard();
            auditScope.SetCustomField("Ip", Singleton.Instance.Ip);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) => base.SaveChangesAsync(cancellationToken);
    }
}
