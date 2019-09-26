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
        Task<Evento> getEvento(int eventoId);
        Task<Evento> Delete(int eventoId);
        Task<List<EventosProximos>> proximosEventos();
        Task<Evento> Post(Evento evento);
        Task<Evento> Put(Evento evento);
        Task<List<TipoEvento>> getTipoEvento();
    }
}
