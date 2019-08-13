using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultorioMedERP.UsuarioMicroService.Entity.EstructuraOrganizacional
{
    public class Area:BaseEntity
    {
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public int UsuarioIdResponsable { get; set; }
        public int AreaPadreId { get; set; }
    }
}
