using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {

        private INFONEWContext _contexto;
        public LoginController(INFONEWContext contexto)
        {
            _contexto = contexto;
        }
        // GET: Contato
        public ActionResult Login()
        {
            UsuarioAplicacao aplicacao = new UsuarioAplicacao(_contexto);
        
            List<Login> lista = aplicacao.GetAllUsers();
             return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

     
    }
}
