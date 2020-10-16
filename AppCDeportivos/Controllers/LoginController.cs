using AppCDeportivos.Bussines;
using AppCDeportivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppCDeportivos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginBL loginBL = new LoginBL();
        public ActionResult Logeo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logeo(UsuarioModel user)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                if (loginBL.ValidaUsuario(user) > 0)
                {
                    Session["UsuarioID"] = user.UsuarioID.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else {
                    message = "usuario o contraseña incorrecto";
                }
            }
            else
            {
                message = "Todos los campos son requeridos";
            }
            ModelState.AddModelError("", message);
            return View();





            //if (Request.IsAjaxRequest())
            //{
            //    return Json(message, JsonRequestBehavior.AllowGet);
            //}else {
            //    return RedirectToAction("Index", "Home");
            //}
        }

            //Console.Write("Prueba");
            //using (OurDBContext db = new OurDBContext())
            //{
            //return RedirectToAction("Home");
            //return RedirectToAction("Index", "Home");

            //return View();
            /*
            var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
            if (usr != null)
            {
                Session["UserID"] = usr.UserID.ToString();
                Session["Username"] = usr.Username.ToString();
                return RedirectToAction("LoggedIn");
            }

            else
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrecto.");
            }
        }
        return View();
        */
        
    }
}