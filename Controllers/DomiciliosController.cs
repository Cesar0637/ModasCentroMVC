using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModasCentroMVC;
using static TransportesMVC.Models.Enum;

namespace ModasCentroMVC.Controllers
{
    public class DomiciliosController : Controller
    {
        private ModasDelCentro_DBEntities db = new ModasDelCentro_DBEntities();

        // GET: Domicilios
        public ActionResult Index()
        {
            return View(db.Domicilios.ToList());
        }

        // GET: Domicilios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domicilios domicilios = db.Domicilios.Find(id);
            if (domicilios == null)
            {
                return HttpNotFound();
            }
            return View(domicilios);
        }

        // GET: Domicilios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Domicilios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Domicilio,Calle,Numero,Colonia,Ciudad,disponibilidad")] Domicilios domicilios)
        {
            if (ModelState.IsValid)
            {
                db.Domicilios.Add(domicilios);
                db.SaveChanges();
                SweetAlert("Agregado", "Domicilio agregado con éxito", NotificationType.succes);
                return RedirectToAction("Index");
            }

            return View(domicilios);
        }

        // GET: Domicilios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domicilios domicilios = db.Domicilios.Find(id);
            if (domicilios == null)
            {
                return HttpNotFound();
            }
            return View(domicilios);
        }

        // POST: Domicilios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Domicilio,Calle,Numero,Colonia,Ciudad,disponibilidad")] Domicilios domicilios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(domicilios).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert("Actualizado", "Domicilio actualizado con éxito", NotificationType.succes);
                return RedirectToAction("Index");
            }
            return View(domicilios);
        }

        // GET: Domicilios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domicilios domicilios = db.Domicilios.Find(id);
            if (domicilios == null)
            {
                return HttpNotFound();
            }
            return View(domicilios);
        }

        // POST: Domicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Domicilios domicilios = db.Domicilios.Find(id);
            db.Domicilios.Remove(domicilios);
            db.SaveChanges();
            SweetAlert("Eliminado", "Domicilio eliminado con éxito", NotificationType.succes);
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

        #region Sweet Alert
        private void SweetAlert(string title, string msg, NotificationType type)
        {
            var script = "<script languaje='javascript'> " +
                         "Swal.fire({" +
                         "title: '" + title + "'," +
                         "text: '" + msg + "'," +
                         "icon: '" + type + "'" +
                         "});" +
                         "</script>";
            TempData["seetalert"] = script;
        }

        private void SweetAlert_Eliminar(int id)
        {
            var script = "<script languaje='javascript'>" +
                "Swal.fire({" +
                "title: '¿Estás Seguro?'," +
                "text: 'Estás a punto de eliminar el domicilio: " + id.ToString() + "'," +
                "icon: 'info'," +
                "showDenyButton: true," +
                "showCancelButton: true," +
                "confirmButtonText: 'Eliminar'," +
                "denyButtonText: 'Cancelar'" +
                "}).then((result) => {" +
                "if (result.isConfirmed) {  " +
                "window.location.href = '/Domicilios/DeleteConfirmed/" + id + "';" +
                "} else if (result.isDenied) {  " +
                "Swal.fire('Se ha cancelado la operación','','info');" +
                "}" +
                "});" +
            "</script>";

            TempData["seetalert"] = script;
        }
        #endregion
    }
}
