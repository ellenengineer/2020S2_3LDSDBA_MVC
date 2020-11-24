using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using MVC.Aplicacao;

namespace MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private INFONEWContext _contexto;
        public ProdutoController(INFONEWContext contexto)
        {
            _contexto = contexto;
        }
        // GET: Contato
        public ActionResult Produto()
        {
            ProdutoAplicacao aplicacao = new ProdutoAplicacao(_contexto);

            List<Produto> lista = aplicacao.GetAllPRoducts();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


    }
}