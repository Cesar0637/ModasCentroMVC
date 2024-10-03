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
    public class VentasController : Controller
    {
        private ModasDelCentro_DBEntities db = new ModasDelCentro_DBEntities();

        // GET: Ventas
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Empleados);
            return View(ventas.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Id_Empleado", "Nombre");
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Venta,Total,Empleado_ID,Status_ID,Folio,Fecha_Venta,disponibilidad")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(ventas);
                db.SaveChanges();
                SweetAlert("Creado", "Venta creada exitosamente", NotificationType.succes);
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Id_Empleado", "Nombre", ventas.Empleado_ID);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Id_Empleado", "Nombre", ventas.Empleado_ID);
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Venta,Total,Empleado_ID,Status_ID,Folio,Fecha_Venta,disponibilidad")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventas).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert("Actualizado", "Venta actualizada exitosamente", NotificationType.succes);
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "Id_Empleado", "Nombre", ventas.Empleado_ID);
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventas ventas = db.Ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ventas ventas = db.Ventas.Find(id);
            db.Ventas.Remove(ventas);
            db.SaveChanges();
            SweetAlert("Eliminado", "Venta eliminada exitosamente", NotificationType.succes);
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
            TempData["sweetalert"] = script;
        }

        private void SweetAlert_Eliminar(int id)
        {
            var script = "<script languaje='javascript'>" +
                "Swal.fire({" +
                "title: '¿Estás Seguro?'," +
                "text: 'Estás a punto de eliminar la venta: " + id.ToString() + "'," +
                "icon: 'info'," +
                "showDenyButton: true," +
                "showCancelButton: true," +
                "confirmButtonText: 'Eliminar'," +
                "denyButtonText: 'Cancelar'" +
                "}).then((result) => {" +
                "if (result.isConfirmed) {  " +
                "window.location.href = '/Ventas/DeleteConfirmed/" + id + "';" +
                "} else if (result.isDenied) {  " +
                "Swal.fire('Se ha cancelado la operación','','info');" +
                "}" +
                "});" +
            "</script>";

            TempData["sweetalert"] = script;
        }
        #endregion
    }
}
