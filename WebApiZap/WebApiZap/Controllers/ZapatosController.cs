using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WebApiZap.Entidades;

namespace WebApiZap.Controllers
{
    //validaciones automaticas
    [ApiController]
    //ruta
    [Route("api/zapatos")]
    public class ZapatosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ZapatosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        //consultar datos
        [HttpGet]
        public async Task<ActionResult<List<Zapato>>> Get()
        {
            /*return new List<Zapato>()
            {
                datos dummy (sirvieron para crear la base)
                new Zapato() { Id=1,Talla= 22, Color="azul" },
                new Zapato() { Id=2,Talla= 24, Color="rosa" }
            };*/

            //ayuda a obtener un listado desde la base
            return await dbContext.Zapatos.ToListAsync();
        }

        //ingresar datos
        [HttpPost]
        public async Task<ActionResult> Post(Zapato zapato)
        {
            dbContext.Add(zapato);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //actualizar datos
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Zapato zapato, int id)
        {
            if(zapato.Id != id)
            {
                return BadRequest("El id ingresado no coincide con el establecido en la url");
            }

            dbContext.Update(zapato);
            await dbContext.SaveChangesAsync();
            return Ok();
        }


        //eliminar datos
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Zapatos.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El id no fue encontrado ");
            }

            dbContext.Remove(new Zapato()
            {
                Id = id
            });

            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
