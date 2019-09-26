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
        private IUsuarioRepositorio _usuario;

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

        public IUsuarioRepositorio Usuario
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new UsuarioRepositorio(_usuarioContext);
                }
                return _usuario;
            }
        }

        public void Save()
        {
            _usuarioContext.SaveChanges();
        }
    }
}
