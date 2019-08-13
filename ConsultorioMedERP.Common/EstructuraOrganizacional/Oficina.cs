using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultorioMedERP.Common.EstructuraOrganizacional
{
    //consultorio
    [Table("OFICINA")]
    public class Oficina
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string TELEFONO { get; set; }
    }
}
