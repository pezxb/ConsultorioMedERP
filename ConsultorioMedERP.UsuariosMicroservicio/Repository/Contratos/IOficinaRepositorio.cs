using ConsultorioMedERP.Common.EstructuraOrganizacional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos
{
    interface IOficinaRepositorio
    {
        Task<Oficina> ObtenerOFicina(int Id);
        Task<Oficina> modificarOficina(Oficina oficina);
        Task BorrarOficina(int Id);
    }
}
