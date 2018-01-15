using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Proj.Models;
using Proj.Repositorio;

namespace Proj.Controllers
{
    public class CidadesController : Controller
    {
        //instanciando classe de conexão com banco
        CidadeRep cidadeRep = new CidadeRep();

        //action para chamar a view index
        public IActionResult Index()
        {
            //definindo titulo da view
            ViewData["title"] = "Cidades";
            //listando as cidades no metodo da classe de conexão
            var lista = cidadeRep.ListarCidades();
            //retornando view com dados do banco
            return View(lista);
        }

        //action para view cidades estados
        public IActionResult CidadesEstados()
        {
            //definindo titulo da view
            ViewData["title"] = "CidadesController e Estados";
            //listando as cidades no metodo da classe de conexão
            var lista = cidadeRep.ListarCidades();
            //retornando view com dados do banco
            return View(lista);
        }

        public IActionResult TodosOsDados()
        {
            //definindo titulo da view
            ViewData["title"] = "Todos os Dados";
            //listando as cidades no metodo da classe de conexão
            var lista = cidadeRep.ListarCidades();
            // retornando view com dados do banco
            return View(lista);
        }

        //action que chama view cadastrar
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        //action que cadastra os dados
        [HttpPost]
        public IActionResult Cadastrar([Bind] Cidade cidade)
        {
            //metrodo cadastrar na classe de conexão
            cidadeRep.Cadastrar(cidade);
            //retornando para a action index
            return RedirectToAction("Index");
        }

        //action que exibe a view de edição de dados
        [HttpGet]
        public IActionResult Editar(int Id)
        {
            //listanto cidades que tem o mesmo id buscado na url
            var dados = cidadeRep.ListarCidades().Where(c => c.Id == Id).FirstOrDefault();
            //retornando dados do banco para a view
            return View(dados);
        }

        //execucando action para atualizar dados
        [HttpPost]
        public IActionResult Editar(Cidade cidade)
        {
            //chamando metodo da classe de conexão de dados para edição de registro no banco
            var dados = cidadeRep.Editar(cidade);
            //retornando para action Index
            return RedirectToAction("Index");
        }

        //action para deletar os dados
        [HttpGet]
        public IActionResult Deletar(int Id)
        {
            //chamando metodo que deleta dados do banco
            cidadeRep.Deletar(Id);
            //retorando para a action index
            return RedirectToAction("Index");
        }

        //
        [HttpGet]
        public IActionResult Detalhes(int Id)
        {
            var dados = cidadeRep.ListarCidades(Id);
            return View(dados);
        }
    }
}