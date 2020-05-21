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
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Pedido>>>Get([FromServices] DataContext context)
        {
            var pedidos = await context.Pedidos.Include(p => p.Cliente)
                                .Include(p => p.Produto)
                                .AsNoTracking()
                                .ToListAsync();
            return pedidos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Pedido>> GetById([FromServices] DataContext context, int id)
        {
            var pedido = await context.Pedidos.Include(p => p.Cliente)
                                .Include(p => p.Produto)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(p => p.Id == id);
            return pedido;
        }

        [HttpGet]
        [Route("cliente/{id:int}")]
        public async Task<ActionResult<List<Pedido>>> GetByCliente([FromServices] DataContext context, int id)
        {
            var pedidos = await context.Pedidos.Include(p => p.Cliente)
                                .Include(p => p.Produto)
                                .AsNoTracking()
                                .Where(p => p.ClienteId == id)
                                .ToListAsync();
            return pedidos;
        }

        [HttpGet]
        [Route("produto/{id:int}")]
        public async Task<ActionResult<List<Pedido>>> GetByProduto([FromServices] DataContext context, int id)
        {
            var pedidos = await context.Pedidos.Include(p => p.Cliente)
                                .Include(p => p.Produto)
                                .AsNoTracking()
                                .Where(p => p.ProdutoId == id)
                                .ToListAsync();
            return pedidos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pedido>> Post([FromServices] DataContext context, [FromBody] Pedido model)
        {
            if (ModelState.IsValid)
            {
                model.DataCompra = DateTime.Now;

                context.Pedidos.Add(model);
                await context.SaveChangesAsync();

                return model;
            }
            else
            {
                return BadRequest();
            }
        }


    }
}