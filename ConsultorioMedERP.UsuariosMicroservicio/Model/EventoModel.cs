using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Model
{
    public class EventoModel
    {
        public decimal ID { get; set; }
        public string TITULO { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHAINICIO { get; set; }
        public DateTime FECHAFIN { get; set; }
        public bool DIACOMPLETO { get; set; }
        public int USUARIORESPONSABLEID { get; set; }
        public int TIPOEVENTOID { get; set; }
    }
}
