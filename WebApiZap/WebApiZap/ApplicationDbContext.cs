using Microsoft.EntityFrameworkCore;
using WebApiZap.Entidades;

namespace WebApiZap
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        //tablas para cada entidad
        public DbSet<Zapato> Zapatos { get; set; }
    }

    
}
