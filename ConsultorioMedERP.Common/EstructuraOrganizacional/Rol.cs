using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultorioMedERP.Common.EstructuraOrganizacional
{
    [Table("ROL")]
    public class Rol
    {
        public int ID { get; private set; }
        public string NOMBRE { get; set; }
    }
}
