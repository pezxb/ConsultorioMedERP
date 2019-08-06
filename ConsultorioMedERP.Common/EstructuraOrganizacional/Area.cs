using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultorioMedERP.Common.EstructuraOrganizacional
{
    public class Area
    {
        public int AreaId { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public int UsuarioIdResponsable { get; set; }
        public int AreaPadreId { get; set; }
    }
}
