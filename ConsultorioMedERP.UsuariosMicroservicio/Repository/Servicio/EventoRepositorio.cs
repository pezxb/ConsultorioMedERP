using ConsultorioMedERP.Common.Evento;
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
    public class EventoRepositorio : IEventoRepositorio
    {
        private readonly UsuarioContext UsuarioContext;

        

        public EventoRepositorio(UsuarioContext usuarioContext)
        {
            UsuarioContext = usuarioContext;
        }

        public async Task<Evento> Delete(int eventoId)
        {
            try
            {
                var EventoBorrar = await UsuarioContext.Evento.Where(x=>x.ID == eventoId).FirstOrDefaultAsync();
                UsuarioContext.Evento.Remove(EventoBorrar);
                return EventoBorrar;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Evento>> getAllEventos()
        {
            try
            {
                var resultados = await UsuarioContext.Evento.ToListAsync();
                    return resultados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Evento> getEvento(int eventoid)
        {
            try
            {
                var result = await UsuarioContext.Evento.Where(e => e.ID == eventoid).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TipoEvento>> getTipoEvento()
        {
            try
            {
                var result = await UsuarioContext.TipoEvento.OrderBy(X=>X.DESCRIPCION).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Evento> Post(Evento evento)
        {
            try
            {
                UsuarioContext.Evento.Add(evento);
                return evento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Evento> Put(Evento evento)
        {
            try
            {
                var EventoModificar = await UsuarioContext.Evento.FirstOrDefaultAsync(x => x.ID == evento.ID);
                EventoModificar.TITULO = evento.TITULO;
                EventoModificar.DESCRIPCION = evento.DESCRIPCION;
                EventoModificar.DIACOMPLETO = evento.DIACOMPLETO;
                EventoModificar.FECHAINICIO = evento.FECHAINICIO;
                EventoModificar.FECHAFIN = evento.FECHAFIN;
                EventoModificar.TIPOEVENTOID = evento.TIPOEVENTOID;
                EventoModificar.USUARIORESPONSABLEID = evento.USUARIORESPONSABLEID;
                return evento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<EventosProximos>> proximosEventos()
        {
            try{
                var resultados = await UsuarioContext.Evento.Where(x=>(x.FECHAINICIO>= DateTime.UtcNow && x.DIACOMPLETO != true)||(x.DIACOMPLETO &&  x.FECHAINICIO.Date>= DateTime.Today)).GroupBy(e => new { y = e.FECHAINICIO.Year, m = e.FECHAINICIO.Month, d = e.FECHAINICIO.Day }).Select(x => new EventosProximos
                {
                    id = $"{x.Key.y}{x.Key.m}{x.Key.d}",
                    dia=new DateTime(x.Key.y,x.Key.m,x.Key.d),
                    eventos= x.ToList()
                }).ToListAsync();
                return resultados;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
