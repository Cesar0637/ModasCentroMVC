using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModasCentroMVC;

namespace ModasCentroMVC.Controllers
{
    public class Status_VentaController : Controller
    {
        private ModasDelCentro_DBEntities db = new ModasDelCentro_DBEntities();

        // GET: Status_Venta
        public ActionResult Index()
        {
            return View(db.Status_Venta.ToList());
        }

        // GET: Status_Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Venta status_Venta = db.Status_Venta.Find(id);
            if (status_Venta == null)
            {
                return HttpNotFound();
            }
            return View(status_Venta);
        }

        // GET: Status_Venta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status_Venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Status,Descripcion")] Status_Venta status_Venta)
        {
            if (ModelState.IsValid)
            {
                db.Status_Venta.Add(status_Venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(status_Venta);
        }

        // GET: Status_Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Venta status_Venta = db.Status_Venta.Find(id);
            if (status_Venta == null)
            {
                return HttpNotFound();
            }
            return View(status_Venta);
        }

        // POST: Status_Venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Status,Descripcion")] Status_Venta status_Venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status_Venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status_Venta);
        }

        // GET: Status_Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Venta status_Venta = db.Status_Venta.Find(id);
            if (status_Venta == null)
            {
                return HttpNotFound();
            }
            return View(status_Venta);
        }

        // POST: Status_Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status_Venta status_Venta = db.Status_Venta.Find(id);
            db.Status_Venta.Remove(status_Venta);
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
