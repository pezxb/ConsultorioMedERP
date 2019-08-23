using AutoMapper;
using ConsultorioMedERP.Common.Evento;
using ConsultorioMedERP.UsuariosMicroservicio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Mappers
{
    public class EventosProximosProfile:Profile
    {
        public EventosProximosProfile()
        {
            this.CreateMap<Evento, EventoModel>();
        }
    }
}
