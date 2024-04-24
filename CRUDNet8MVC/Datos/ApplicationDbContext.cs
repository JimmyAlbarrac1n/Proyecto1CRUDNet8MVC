using CRUDNet8MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDNet8MVC.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //Agregar los modelos aqui, cada modelo corresponde a una tabla Db
        public DbSet<Contacto> Contacto { get; set; }//Creado primer modelo en el contexto

    }
}
