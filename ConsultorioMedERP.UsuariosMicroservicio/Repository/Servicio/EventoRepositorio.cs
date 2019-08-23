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

        public async Task<List<EventosProximos>> proximosEventos()
        {
            try{
                var resultados = await UsuarioContext.Evento.GroupBy(e => new { y = e.FECHAINICIO.Year, m = e.FECHAINICIO.Month, d = e.FECHAINICIO.Day }).Select(x => new EventosProximos
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
