using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConsultorioMedERP.UsuariosMicroservicio.Model;
using ConsultorioMedERP.UsuariosMicroservicio.Repository.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioMedERP.UsuariosMicroservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public EventosController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await repositoryWrapper.Evento.proximosEventos();
               
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"error");
            }
        }
    }
}