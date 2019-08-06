using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultorioMedERP.Common.Notificaciones
{
    public class Notificacion
    {
        public decimal NotificacionId { get; set; }
        public int TipoNotificacion { get; set; }
        public int SubTipoNotificacion { get; set; }
        public bool Visto { get; set; }
        public bool Leido { get; set; }
        public string DatosNotificacion { get; set; }
        public int UsuarioId { get; set; }

    }
}
