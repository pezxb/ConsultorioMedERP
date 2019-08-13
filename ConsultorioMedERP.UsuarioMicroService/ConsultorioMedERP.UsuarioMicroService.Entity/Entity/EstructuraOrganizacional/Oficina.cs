using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultorioMedERP.UsuarioMicroService.Entity.EstructuraOrganizacional
{
    //consultorio
    public class Oficina:BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string telefono { get; set; }
    }
}
