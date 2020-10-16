using AppCDeportivos.Bussines;
using AppCDeportivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCDeportivos.Controllers
{
    public class ComplejosController : Controller
    {
        ComplejoBL complejoBL;
        // GET: Complejos
        public ActionResult Complejos()
        {
            complejoBL = new ComplejoBL();
            return View(complejoBL.ListarComplejos());
        }
        [HttpGet]
        public ActionResult CrearComplejo()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult CrearComplejo(ComplejoModel complejoM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    complejoBL = new ComplejoBL();

                    if (complejoBL.RegistrarComplejo(complejoM) >= 1)
                    {
                        ViewBag.Message = "Complejo registrado";
                        ModelState.Clear();
                    }
                }

                return View();
            }
            catch
            {

                return View();
            }
        }
        [HttpGet]
        public ActionResult EditarComplejo(int id)
        {
            complejoBL = new ComplejoBL();
            return View(complejoBL.ListarComplejos().Find(complejomodel => complejomodel.ComplejoID == id));
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult EditarComplejo(ComplejoModel complejoModel, int id)
        {
            try
            {
                complejoBL = new ComplejoBL();
                complejoBL.EditarComplejo(complejoModel);
                return RedirectToAction("Complejos");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EliminarComplejo(int id)
        {
            complejoBL = new ComplejoBL();
            return View(complejoBL.ListarComplejos().Find(complejomodel => complejomodel.ComplejoID == id));

        }
        [HttpPost]
        public ActionResult EliminarComplejo(int id, SedeModel sedeModel)
        {
            try
            {
                complejoBL = new ComplejoBL();
                if (complejoBL.DeleteComplejo(id) >= 1)
                {
                    ViewBag.AlertMsg = "Complejo eliminado";
                }
                return RedirectToAction("Complejos");
            }
            catch
            {
                return View();
            }
        }
    }
}