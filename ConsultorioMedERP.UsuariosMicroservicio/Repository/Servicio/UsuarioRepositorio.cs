using ConsultorioMedERP.Common.EstructuraOrganizacional;
using ConsultorioMedERP.UsuariosMicroservicio.Context;
using ConsultorioMedERP.UsuariosMicroservicio.Model;
using ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Repository.Servicio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuarioContext contexto;
        public UsuarioRepositorio(UsuarioContext contexto)
        {
            this.contexto = contexto;
        }
        public async Task<List<IonSelectOption>> getAllUsuarios()
        {
            try
            {
                var result = await contexto.Usuario.Select(x=>new IonSelectOption { ID=x.ID,DESCRIPCION=$"{x.NOMBRE} {x.APELLIDOPATERNO} {x.APELLIDOMATERNO}".Trim()}).ToListAsync();
                return result;
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
