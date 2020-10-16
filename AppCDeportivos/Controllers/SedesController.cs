using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppCDeportivos.Bussines;
using AppCDeportivos.Models;

namespace AppCDeportivos.Controllers
{
    public class SedesController : Controller
    {
        SedesBL sedeBL;
        // GET: Sedes
        [HttpGet]
        public ActionResult Sedes()
        {
            sedeBL = new SedesBL();
            
            return View(sedeBL.ListarSedes());
        }
        public ActionResult ListarSedes()
        {
            sedeBL = new SedesBL();
            return PartialView(sedeBL.ListarSedes());
            //return PartialView(new TipoComplejoBL().ListarTComplejo());
        }
        [HttpGet]
        public ActionResult CrearSede()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult CrearSede(SedeModel sedeModel)
        {
            var m = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    sedeBL = new SedesBL();

                    if (sedeBL.RegistrarSede(sedeModel) >= 1)
                    {
                        ViewBag.Message = "Sede registrada";
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
        public ActionResult EditarSede(int id)
        {
            sedeBL = new SedesBL();
            return View(sedeBL.ListarSedes().Find(sedemodel => sedemodel.SedeID == id));
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult EditarSede(SedeModel sedeModel, int id )
        {
            try
            {
                sedeBL = new SedesBL();
                sedeBL.EditarSede(sedeModel);
                return RedirectToAction("Sedes");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EliminarSede(int id)
        {
            sedeBL = new SedesBL();
            return View(sedeBL.ListarSedes().Find(sedemodel => sedemodel.SedeID == id));
            
        }
        [HttpPost]
        public ActionResult EliminarSede(int id, SedeModel sedeModel)
        {
            try
            {
                sedeBL = new SedesBL();
                if (sedeBL.DeleteSede(id)>=1)
                {
                    ViewBag.AlertMsg = "Empleado eliminado";
                }
                return RedirectToAction("Sedes");
            }
            catch
            {
                return View();
            }
        }
    }
}