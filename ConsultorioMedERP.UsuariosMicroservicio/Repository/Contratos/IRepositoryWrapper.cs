using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos
{
    public interface IRepositoryWrapper
    {
        IEventoRepositorio Evento { get; }
        void Save();
    }
}
