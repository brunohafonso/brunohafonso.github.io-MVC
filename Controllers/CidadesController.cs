using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proj.Models;
using Proj.Repositorio;

namespace Proj.Controllers
{
    public class CidadesController : Controller
    {
        CidadeRep cidadeRep = new CidadeRep();
        public IActionResult Index()
        {
            ViewData["title"] = "Cidades";
            var lista = cidadeRep.ListarCidades();
            return View(lista);
        }

        public IActionResult CidadesEstados()
        {
            ViewData["title"] = "CidadesController e Estados";
            var lista = cidadeRep.ListarCidades();
            return View(lista);
        }

        public IActionResult TodosOsDados()
        {
            ViewData["title"] = "Todos os Dados";
            var lista = cidadeRep.ListarCidades();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([Bind] Cidade cidade)
        {
            cidadeRep.Cadastrar(cidade);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int Id) {
            var dados = cidadeRep.ListarCidades(Id);
            return View(dados);
        }

        [HttpPost]
        public IActionResult Editar([Bind] Cidade cidade) {
            cidadeRep.Editar(cidade);
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult Deletar(int Id) {
          cidadeRep.Deletar(Id);
          return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhes(int Id) {
            var dados = cidadeRep.ListarCidades(Id);
            return View(dados);
        }
    }
}