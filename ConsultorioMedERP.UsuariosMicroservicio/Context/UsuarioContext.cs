using System.Collections.Generic;
using ConsultorioMedERP.Common.EstructuraOrganizacional;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioMedERP.UsuariosMicroservicio.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options)
            : base(options)
        {

        }
        public DbSet<Usuario> Usuario{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
        }
    }
}
