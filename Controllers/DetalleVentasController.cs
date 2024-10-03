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
    public class DetalleVentasController : Controller
    {
        private ModasDelCentro_DBEntities db = new ModasDelCentro_DBEntities();

        // GET: DetalleVentas
        public ActionResult Index()
        {
            return View(db.DetalleVentas.Include(d => d.Productos).Include(d => d.Ventas).ToList());
        }

        // GET: DetalleVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVentas detalleVentas = db.DetalleVentas.Find(id);
            if (detalleVentas == null)
            {
                return HttpNotFound();
            }
            return View(detalleVentas);
        }

        // GET: DetalleVentas/Create
        public ActionResult Create()
        {
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Codigo_Producto");
            ViewBag.Venta_ID = new SelectList(db.Ventas, "ID_Venta", "Folio");
            return View();
        }

        // POST: DetalleVentas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Detalle_Venta,Venta_ID,Producto_ID,Cantidad,Precio_Unitario,SubTotal,disponibilidad")] DetalleVentas detalleVentas)
        {
            if (ModelState.IsValid)
            {
                db.DetalleVentas.Add(detalleVentas);
                db.SaveChanges();
                SweetAlert("Agregado", "Detalle de venta agregado con éxito", NotificationType.succes);
                return RedirectToAction("Index");
            }

            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Codigo_Producto", detalleVentas.Producto_ID);
            ViewBag.Venta_ID = new SelectList(db.Ventas, "ID_Venta", "Folio", detalleVentas.Venta_ID);
            return View(detalleVentas);
        }

        // GET: DetalleVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVentas detalleVentas = db.DetalleVentas.Find(id);
            if (detalleVentas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Codigo_Producto", detalleVentas.Producto_ID);
            ViewBag.Venta_ID = new SelectList(db.Ventas, "ID_Venta", "Folio", detalleVentas.Venta_ID);
            return View(detalleVentas);
        }

        // POST: DetalleVentas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Detalle_Venta,Venta_ID,Producto_ID,Cantidad,Precio_Unitario,SubTotal,disponibilidad")] DetalleVentas detalleVentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleVentas).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert("Actualizado", "Detalle de venta actualizado con éxito", NotificationType.succes);
                return RedirectToAction("Index");
            }
            ViewBag.Producto_ID = new SelectList(db.Productos, "ID_Producto", "Codigo_Producto", detalleVentas.Producto_ID);
            ViewBag.Venta_ID = new SelectList(db.Ventas, "ID_Venta", "Folio", detalleVentas.Venta_ID);
            return View(detalleVentas);
        }

        // GET: DetalleVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVentas detalleVentas = db.DetalleVentas.Find(id);
            if (detalleVentas == null)
            {
                return HttpNotFound();
            }
            return View(detalleVentas);
        }

        // POST: DetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleVentas detalleVentas = db.DetalleVentas.Find(id);
            db.DetalleVentas.Remove(detalleVentas);
            db.SaveChanges();
            SweetAlert("Eliminado", "Detalle de venta eliminado con éxito", NotificationType.succes);
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
                "text: 'Estás apunto de eliminar el detalle de venta: " + id.ToString() + "'," +
                "icon: 'info'," +
                "showDenyButton: true," +
                "showCancelButton: true," +
                "confirmButtonText: 'Eliminar'," +
                "denyButtonText: 'Cancelar'" +
                "}).then((result) => {" +
                "if (result.isConfirmed) {  " +
                "window.location.href = '/DetalleVentas/DeleteConfirmed/" + id + "';" +
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
