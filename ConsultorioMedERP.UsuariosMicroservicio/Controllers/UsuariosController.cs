using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioMedERP.UsuariosMicroservicio.Context;
using ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioMedERP.UsuariosMicroservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public UsuariosController(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }
        
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllUsuarios()
        {
            try
            {
                var resultado = await repositoryWrapper.Usuario.getAllUsuarios();
                if(resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
