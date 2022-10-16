using Microsoft.AspNetCore.Mvc;
using WebApiZap.Entidades;

namespace WebApiZap.Controllers
{

    //validaciones 
    [ApiController]
    //ruta
    [Route("pedidos")]

    public class PedidosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PedidosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }


    }
}
