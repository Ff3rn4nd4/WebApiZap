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

        [HttpPost]
        public async Task<ActionResult> Post(Zapato zapato)
        {
            dbContext.Add(zapato);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
