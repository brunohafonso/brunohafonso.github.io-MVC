using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proj.Models;

namespace Proj.Controllers
{
    public class CidadesController : Controller
    {
        Cidade cidade = new Cidade();
        public IActionResult Index()
        {
            ViewData["title"] = "Cidades";
            var lista = cidade.ListarCidades();
            return View(lista);
        }

        public IActionResult CidadesEstados()
        {
            ViewData["title"] = "CidadesController e Estados";
            var lista = cidade.ListarCidades();
            return View(lista);
        }

        public IActionResult TodosOsDados()
        {   
            ViewData["title"] = "Todos os Dados";
            var lista = cidade.ListarCidades();
            return View(lista);
        }
    }
}