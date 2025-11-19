using PruebaTecnica.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class ClientesApiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public JsonResult GetCliente(int id)
        {
            var cliente = db.Clientes.Find(id);

            if (cliente == null)
                return Json(new { error = "Cliente no encontrado" }, JsonRequestBehavior.AllowGet);

            return Json(new
            {
                cliente.Id,
                cliente.Nombre,
                cliente.Apellido,
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                //return RedirectToAction("Clientes");
            }

            //return View(cliente);
            return RedirectToAction("Create");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}