using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioMedERP.UsuariosMicroservicio.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioMedERP.UsuariosMicroservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioContext usuarioContext;

        public UsuariosController(UsuarioContext usuarioContext)
        {
            this.usuarioContext = usuarioContext;
        }
        
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var  resultado = await usuarioContext.Usuario.FirstOrDefaultAsync();
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
