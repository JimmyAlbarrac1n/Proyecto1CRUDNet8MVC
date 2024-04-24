using CRUDNet8MVC.Datos;
using CRUDNet8MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUDNet8MVC.Controllers
{
    public class InicioController : Controller
    {
        // private readonly ILogger<InicioController> _logger; esto sirve para el login

        public readonly ApplicationDbContext _contexto;

        public InicioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Contacto.ToListAsync());
        }
        [HttpGet]//se utiliza para aplicaciones web para diferenciar
        public IActionResult Crear() 
        { 
            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Proteger de ataques css
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                //Agregar la fecha y hora actual dinamicamente
                contacto.FechaCreacion = DateTime.Now;

               _contexto.Contacto.Add(contacto);
                await _contexto.SaveChangesAsync();//guardar en la base de datos
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var contacto = _contexto.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(contacto);
                await _contexto.SaveChangesAsync();//guardar en la base de datos
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
