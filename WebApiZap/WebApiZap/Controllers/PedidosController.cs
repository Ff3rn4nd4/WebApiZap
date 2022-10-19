using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiZap.Entidades;

namespace WebApiZap.Controllers
{

    //validaciones 
    [ApiController]
    //ruta
    [Route("api/pedidos")]

    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PedidosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        //para obtener los datos de la tabla zapatos
        public async Task<ActionResult<List<Pedido>>> GetAll()
        {
            return await dbContext.Pedidos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pedido>> GetById(int id)
        {
            return await dbContext.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Pedido pedido)
        {
            //validando que exista ese zapato
            var existeZapato = await dbContext.Zapatos.AnyAsync(x => x.Id == pedido.ZapatoId);

            if (!existeZapato)
            {
                return BadRequest($"No existe un zapato con el id: {pedido.ZapatoId}");
            }

            dbContext.Add(pedido);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Pedido pedido, int id)
        {
            var exist = await dbContext.Pedidos.AnyAsync(x => x.Id == id);

            if(!exist)
            {
                return NotFound("El pedido no exsite");
            }

            if(pedido.Id != id)
            {
                return BadRequest("El id del pedido no coincide con la URL");
            }

            dbContext.Update(pedido);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Pedidos.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El pedido no fue encontrado");
            }

            dbContext.Remove(new Pedido{Id = id});
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
