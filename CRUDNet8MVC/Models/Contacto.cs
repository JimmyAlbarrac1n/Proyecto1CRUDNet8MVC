using System.ComponentModel.DataAnnotations;

namespace CRUDNet8MVC.Models
{
    public class Contacto
    {
        
        public int Id { get; set; }//entero para autoincrementar, siempre existe id, es llave primaria
        [Required (ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email{ get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
