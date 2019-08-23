using ConsultorioMedERP.Common.Evento;
using ConsultorioMedERP.UsuariosMicroservicio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos
{
    public interface IEventoRepositorio
    {
        Task<List<Evento>> getAllEventos();
        Task<List<EventosProximos>> proximosEventos();
    }
}
