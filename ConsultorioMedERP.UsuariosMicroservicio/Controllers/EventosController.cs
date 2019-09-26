using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConsultorioMedERP.Common.Evento;
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
        public async Task<IActionResult> getCommingEvents()
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
        [HttpGet("{eventoid}")]
        public async Task<IActionResult> Get( int eventoid)
        {
            try
            {
                var result = await repositoryWrapper.Evento.getEvento(eventoid);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "error");
            }
        }

        [HttpDelete("{eventoid}")]
        public async Task<IActionResult> Delete(int eventoid)
        {
            try
            {
                var result = await repositoryWrapper.Evento.Delete(eventoid);
                repositoryWrapper.Save();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Evento evento)
        {
            try
            {
                var result = await repositoryWrapper.Evento.Post(evento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "error");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Evento evento)
        {
            try
            {
                var result = await repositoryWrapper.Evento.Put(evento);
                repositoryWrapper.Save();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "error");
            }
        }
        [HttpGet("TipoEvento")]
        public async Task<IActionResult> getAllTipoEvento()
        {
            try
            {
                var result = await repositoryWrapper.Evento.getTipoEvento();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "error");
            }
        }
    }
}