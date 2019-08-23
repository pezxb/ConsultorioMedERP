using ConsultorioMedERP.UsuariosMicroservicio.Context;
using ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Repository.Servicio
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        private readonly UsuarioContext _usuarioContext;
        private IEventoRepositorio _evento;

        public RepositoryWrapper(UsuarioContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }
        
        public IEventoRepositorio Evento
        {
            get
            {
                if(_evento == null)
                {
                    _evento = new EventoRepositorio(_usuarioContext);
                }
                return _evento;
            }
        }

        public void Save()
        {
            _usuarioContext.SaveChanges();
        }
    }
}
