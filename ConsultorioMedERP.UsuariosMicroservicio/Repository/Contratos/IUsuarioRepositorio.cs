using ConsultorioMedERP.Common.EstructuraOrganizacional;
using ConsultorioMedERP.UsuariosMicroservicio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos
{
    public interface IUsuarioRepositorio
    {
        Task<List<IonSelectOption>> getAllUsuarios();
    }
}
