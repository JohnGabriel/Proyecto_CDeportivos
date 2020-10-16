using AppCDeportivos.Bussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCDeportivos.Controllers
{
    public class TipoComplejoController : Controller
    {
        TipoComplejoBL tipoComplejoBL;
        // GET: TipoComplejo
        public ActionResult Index()
        {
            return View();
        }
        // Listar los tipos de complejos:polideportivos,unideportivos 
        public JsonResult f_tipocomplejo(int v_idFamilia = 0, int v_idsubfamilia = 0)
        {
            return Json(new { Result = "OK", Records = new TipoComplejoBL().ListarTComplejo() });
        }
        // Listar los tipos de complejos para una vista parcial
        public ActionResult ListarTipoComplejo()
        {
            return PartialView(new TipoComplejoBL().ListarTComplejo());    
        }
    }
}