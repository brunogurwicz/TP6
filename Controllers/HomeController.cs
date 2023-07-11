using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPBase.Models;

namespace TPBase.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

      public IActionResult Index()
    {
        ViewBag.ListaPartidos = DB.ListarPartidos();
        return View();
    }
       public IActionResult VerDetallePartido(int IdPartido)
    {
        ViewBag.Partido = DB.VerInfoPartido(IdPartido);
        ViewBag.ListaCandidatos = DB.ListarCandidatos(IdPartido);
        return View();
    }
         public IActionResult VerDetalleCandidato(int IdCandidato)
    {
        ViewBag.Candidato = DB.VerInfoCandidato(IdCandidato);
        return View();
    }
        public IActionResult AgregarCandidato(int IdPartido)
    {   
        ViewBag.IdPartido = IdPartido;
        return View();
    }
        public IActionResult AgregarPartido()
    {   
        return View();
    }

        [HttpPost]public IActionResult GuardarCandidato(Candidato can)
        {
            DB.AgregarCandidato(can);
            return RedirectToAction("VerDetallePartido", new{IdPartido = can.IdPartido});
        }
        public IActionResult EliminarCandidato(int IdPartido, int IdCandidato)
        {
            DB.EliminarCandidato(IdCandidato);
            return RedirectToAction("VerDetallePartido", new{IdPartido = IdPartido});
        }
        [HttpPost]public IActionResult GuardarPartido(Partido par)
        {
            DB.AgregarPartido(par);
            return RedirectToAction("Index");
        }
        public IActionResult EliminarPartido(int IdPartido, int IdCandidato)
        {
            DB.EliminarPartido(IdPartido);
            return RedirectToAction("Index");
        }

        public IActionResult Elecciones()
        {
            ViewBag.ListaPartidos = DB.ListarPartidos();
            return View();
        }
        public IActionResult Creditos()
        {
            return View();
        }
}

