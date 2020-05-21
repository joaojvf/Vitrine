using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vitrine.Domain.Entities;
using Vitrine.Domain.Services;
using Vitrine.Infra.Data;

namespace Vitrine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET: api/Cliente
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] DataContext context)
        {
            var clientes = await context.Clientes.ToListAsync();
            return clientes;
        }

        // GET: api/Cliente/5
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<Cliente>> GetById([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return cliente;
        }

        // POST: api/Cliente
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<Cliente>> Post([FromServices] DataContext context, [FromBody] Cliente model)
        {
            if (ModelState.IsValid)
            {
                model.DataNascimento = DateTime.Now;
                context.Clientes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Logar([FromServices]DataContext context,[FromBody] Cliente model)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Email == model.Email);

            if (cliente == null)
            {
                return NotFound(new { message = "Email nao cadastrado" });
            }

            var token = TokenService.GerarToken(cliente);
            //model.Senha = "";

            return new
            {
                cliente = cliente,
                token = token
            };
        }
    }
}
