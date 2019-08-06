using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultorioMedERP.Common.Notificaciones
{
   public class SubTipoNotificacion
    {
        public int SubTipoNotificacionId { get; set; }
        public int TipoNotificacionId { get; set; }
        public string PlantillaNotificacion { get; set; }
        public string PlantillaCorreo { get; set; }
        public string Descripcion { get; set; }
    }
}
