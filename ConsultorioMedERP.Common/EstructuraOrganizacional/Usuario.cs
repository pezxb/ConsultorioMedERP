using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultorioMedERP.Common.EstructuraOrganizacional
{
    [Table("USUARIO")]
    public class Usuario
    {
        public Usuario()
        {

        }
        public int ID { get; private set; }
        public string NOMBRE { get; set; }
        public string APELLIDOPATERNO { get; set; }
        public string APELLIDOMATERNO { get; set; }
        public int? OFICINAID { get; set; }
        public int? ROLID { get; set; }
        
    }
}
