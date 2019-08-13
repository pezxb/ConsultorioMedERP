using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultorioMedERP.UsuarioMicroService.Entity.Notificaciones
{
    public class Notificacion:BaseEntity
    {
        public int TipoNotificacion { get; set; }
        public int SubTipoNotificacion { get; set; }
        public bool Visto { get; set; }
        public bool Leido { get; set; }
        public string DatosNotificacion { get; set; }
        public int UsuarioId { get; set; }

    }
}
