using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultorioMedERP.Common.Evento
{
    public class Evento
    {
        public decimal EventoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTimeOffset FechaInicio { get; set;}
        public DateTimeOffset FechaFin { get; set; }
        public bool DiaCompleto { get; set; }
        public int UsuarioResponsableId { get; set; }
        public int TipoEventoId { get; set; }
    }
}
