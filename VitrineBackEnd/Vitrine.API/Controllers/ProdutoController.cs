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
    public class ProdutoController : ControllerBase
    {       
        // GET: api/Produto
        [HttpGet]
        [Route ("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var products = await context.Produtos.Include(x => x.Categoria).ToListAsync();
            return products;
        }

        // GET: api/Produto/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos.Include(x => x.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpGet]
        [Route("categoria/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetByCategoria([FromServices] DataContext context, int id)
        {
            var products = await context.Produtos.Include(x => x.Categoria)
                .AsNoTracking()
                .Where(x => x.CategoriaId == id)
                .ToListAsync();

            return products;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post (
            [FromServices] DataContext context,
            [FromBody] Produto model)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
