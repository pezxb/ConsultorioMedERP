using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultorioMedERP.Common.EstructuraOrganizacional
{
    [Table("USURIOMEDIA")]
    public class UsuarioMedia
    {
        public int ID { get; set; }
        public string USUARIOIMAGEN { get; set; }
    }
}
