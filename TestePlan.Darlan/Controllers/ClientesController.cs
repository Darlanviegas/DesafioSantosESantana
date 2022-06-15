using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestePlan.Darlan.DAL;
using TestePlan.Darlan.Models;
using TestePlan.Darlan.Models.AutoMapper;
using TestePlan.Darlan.Models.ViewModels;

namespace TestePlan.Darlan.Controllers
{
    public class ClientesController : Controller
    {
        private Context db = new Context();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.Where(p => p.Inativo == false).ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,TipoCliente,Documento")] ClienteViewModel cliente)
        {
            Cliente mappercliente = new Cliente(); 
            cliente.DataCadastro = DateTime.UtcNow;
            if (cliente.TipoCliente == TipoCliente.PessoaFisica)
            {
                if (!cliente.ValidarDocumento())
                {
                   
                    ViewBag.Mensagem = cliente.MensagemErro.FirstOrDefault();
                    return View(cliente);
                }
                mappercliente = MapperTemp.MapeamentoView_EntidadeCliente(cliente);

            }

            // Validação de CNPJ
            if (cliente.TipoCliente == TipoCliente.PessoaJuridica)
            {
                if (!cliente.ValidarDocumento())
                {                   
                    ViewBag.Mensagem = cliente.MensagemErro.FirstOrDefault();
                    return View(cliente);
                }                 
                mappercliente = MapperTemp.MapeamentoView_EntidadeCliente(cliente);

            }
            // Validação de CPF
            db.Clientes.Add(mappercliente);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            var mappercliente = MapperTemp.MapeamentoEntidade_ViewCliente(cliente);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(mappercliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCliente,Nome,TipoCliente,Documento,DataCadastro,Inativo")] ClienteViewModel cliente)
        {
           var mappercliente = MapperTemp.MapeamentoView_EntidadeCliente(cliente);
            if (ModelState.IsValid)
            {
                db.Entry(mappercliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            cliente.Inativo = true;
            db.Entry(cliente).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
