using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultorioMedERP.Common.Evento
{
    [Table("TIPOEVENTO")]
    public class TipoEvento
    {
        public int ID { get; set; }
        public string  DESCRIPCION { get; set; }
    }
}
