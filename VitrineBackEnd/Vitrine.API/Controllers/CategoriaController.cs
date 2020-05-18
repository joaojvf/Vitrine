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
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            var categoria = await context.Categorias.ToListAsync();

            return categoria;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context,
            [FromBody]Categoria model
            )
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }




    }
}