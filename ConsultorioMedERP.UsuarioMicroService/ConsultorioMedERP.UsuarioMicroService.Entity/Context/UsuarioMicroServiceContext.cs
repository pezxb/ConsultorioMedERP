using System;
using System.Threading.Tasks;
using System.Linq;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ConsultorioMedERP.UsuarioMicroService.Entity.EstructuraOrganizacional;
using Castle.Core.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity;

namespace ConsultorioMedERP.UsuarioMicroService.Entity.Context
{
    public class UsuarioMicroServiceContext : DbContext
    {

        public UsuarioMicroServiceContext(DbContextOptions<UsuarioMicroServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        //lazy-loading
        //https://entityframeworkcore.com/querying-data-loading-eager-lazy
        //https://docs.microsoft.com/en-us/ef/core/querying/related-data
        //EF Core will enable lazy-loading for any navigation property that is virtual and in an entity class that can be inherited
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseLazyLoadingProxies();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            //Fluent API
           // modelBuilder.Entity<User>()
           //.HasOne(u => u.Account)
           //.WithMany(e => e.Users);

           // //concurrency
           // modelBuilder.Entity<Account>()
           // .Property(a => a.RowVersion).IsRowVersion();
           // modelBuilder.Entity<User>()
           // .Property(a => a.RowVersion).IsRowVersion();

            //modelBuilder.Entity<User>()
            //.Property(p => p.DecryptedPassword)
            //.HasComputedColumnSql("Uncrypt(p.PasswordText)");
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    //((BaseEntity)entry.Entity).FechaCreacion = DateTime.UtcNow;
                }
//((BaseEntity)entry.Entity).FechaModificacion = DateTime.UtcNow;
}
        }

    }
    public class AppDbContextConfiguration : DbConfiguration
    {
        public AppDbContextConfiguration()
        {
            this.AddInterceptor(new MyEntityFrameworkInterceptor());
        }
    }

    class MyEntityFrameworkInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuted(
            DbCommand command,
            DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (interceptionContext.Result == null) return;
            interceptionContext.Result = new WrappingDbDataReader(interceptionContext.Result);
        }

        public override void ScalarExecuted(
            DbCommand command,
            DbCommandInterceptionContext<object> interceptionContext)
        {
            interceptionContext.Result = ModifyReturnValues(interceptionContext.Result);
        }

        static object ModifyReturnValues(object result)
        {
            // Transform and then
            return result;
        }
    }

    class WrappingDbDataReader : DbDataReader, IDataReader
    {
        // Wrap an existing DbDataReader, proxy all calls to the underlying instance, 
        // modify return values and/or parameters as needed...
        public WrappingDbDataReader(DbDataReader reader)
        {
        }
    }
}
