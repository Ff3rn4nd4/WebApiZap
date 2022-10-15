using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public ActionResult<List<Zapato>> Get()
        {
            return new List<Zapato>()
            {
                new Zapato() { Id=1,Talla= 22, Color="azul" },
                new Zapato() { Id=2,Talla= 24, Color="rosa" }
            };
        }
    }
}
