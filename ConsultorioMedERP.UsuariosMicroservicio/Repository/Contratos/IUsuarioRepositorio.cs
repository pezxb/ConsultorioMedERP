using ConsultorioMedERP.Common.EstructuraOrganizacional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObtenerUsuario(int id);
        Task<List<Usuario>> ObtenerUsuariosPorOficina(int OficinaId);
        Task<Usuario> ModificarUsuario(Usuario usuario);
        Task<Usuario> AgregarUsuario(Usuario usuario);
        Task<UsuarioMedia> EstablecerImagen(UsuarioMedia usuarioMedia);
        Task BorrarUsuario(int id);
    }
}
