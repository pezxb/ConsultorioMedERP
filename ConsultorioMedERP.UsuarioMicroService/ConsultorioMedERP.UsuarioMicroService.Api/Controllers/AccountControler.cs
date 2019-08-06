using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using ConsultorioMedERP.UsuarioMicroService.Domain;
using ConsultorioMedERP.UsuarioMicroService.Entity.Context;
using ConsultorioMedERP.UsuarioMicroService.Domain.Service;
using Microsoft.Extensions.Logging;
using Serilog;
using ConsultorioMedERP.UsuarioMicroService.Entity;

namespace ConsultorioMedERP.UsuarioMicroService.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService<AccountViewModel, Account> _accountService;
        public AccountController(AccountService<AccountViewModel, Account> accountService)
        {
            _accountService = accountService;
        }

        //get all
        [Authorize]
        [HttpGet]
        public IEnumerable<AccountViewModel> GetAll()
        {
            //Log.Information("Log: Log.Information");
            //Log.Warning("Log: Log.Warning");
            //Log.Error("Log: Log.Error");
            //Log.Fatal("Log: Log.Fatal");
            var test = _accountService.DoNothing();
            var items = _accountService.GetAll();
            return items;
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _accountService.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        //add
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Create([FromBody] AccountViewModel account)
        {
            if (account == null)
                return BadRequest();

            var id = _accountService.Add(account);
            return Created($"api/Account/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AccountViewModel account)
        {
            if (account == null || account.Id != id)
                return BadRequest();

            int retVal = _accountService.Update(account);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(account);
        }

        //delete 
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _accountService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }
    }
}


