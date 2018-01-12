using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proj.Models;
using Proj.Repositorio;

namespace Proj.Controllers
{
    public class CidadesController : Controller
    {
        CidadeRep cidade = new CidadeRep();
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

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([Bind] Cidade cid)
        {
            cidade.Cadastrar(cid);
            return RedirectToAction("Index");
        }
    }
}