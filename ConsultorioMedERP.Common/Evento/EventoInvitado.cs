using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultorioMedERP.Common.Evento
{
    [Table("EVENTOINVITADO")]
    public class EventoInvitado
    {
        public long ID { get; set; }//eventoid
        public int USUARIOID { get; set; }//usuarioinvitado
    }
}
