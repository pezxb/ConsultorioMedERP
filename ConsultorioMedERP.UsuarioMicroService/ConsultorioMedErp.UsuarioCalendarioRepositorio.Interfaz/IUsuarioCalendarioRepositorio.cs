using System.Collections.Generic;
using ConsultorioMedERP.Common.Agenda;

namespace ConsultorioMedERP.UsuarioAgendaRepositorio.Interfaz
{
    public interface IUsuarioAgenda
    {
        IEnumerable<IUsuarioAgenda> obtenerPorId(int UsuarioAgendaId);
        void borrarPorId(int UsuarioAgendaId, int AgendaId);
        void Agregar(UsuarioAgenda usuarioAgenda);
    }
}
