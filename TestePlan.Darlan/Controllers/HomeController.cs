using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestePlan.Darlan.Models;

namespace TestePlan.Darlan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Descrição da Aplicação.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de Contatos.";

            return View();
        }
        public ActionResult CadastrarCliente()
        {
            return View();
        }
        public ActionResult CadastroCliente()
        {
            ViewBag.Message = "Cadastrar novo cliente";

            return View();
        }

        [HttpPost]
        public ActionResult xxCadastroCliente([Bind(Include = "Nome,Documento")] Cliente movie)
        {
            if (ModelState.IsValid)
            {
                //db.Movies.Add(movie);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}