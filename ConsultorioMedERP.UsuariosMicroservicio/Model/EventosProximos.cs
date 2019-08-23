using ConsultorioMedERP.Common.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Model
{
    public class EventosProximos
    {
        public DateTime dia;

        public string id { get; set; }
        public List<Evento> eventos { get; set; }
    }
}
