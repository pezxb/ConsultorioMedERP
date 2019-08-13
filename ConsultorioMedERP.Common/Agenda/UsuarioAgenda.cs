using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultorioMedERP.Common.Agenda
{
    [Table("USUARIOAGENDA")]
    public class UsuarioAgenda
    {
        public int ID { get; set; }//usuariId 
        public int AGENDAID { get; set; }//calendario de otro usuario

        
    }
}
