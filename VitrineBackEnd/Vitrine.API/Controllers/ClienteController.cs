using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vitrine.Domain.Entities;
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
        public async Task<ActionResult<Cliente>> GetById([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return cliente;
        }

        // POST: api/Cliente
        [HttpPost]
        [Route("")]
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
    }
}
