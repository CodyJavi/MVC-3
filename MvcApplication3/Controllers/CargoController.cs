using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;

namespace MvcApplication3.Controllers
{
    public class CargoController : Controller
    {
        //
        // GET: /Cargo/

        bd_escuelaEntities entidad = new bd_escuelaEntities();

        public ActionResult Index()
        {
            var listaCargos = entidad.cargo;

            return View(listaCargos.ToList());
        }

        public ActionResult ListadoMaestraCargos()
        {
            var listaCargos = entidad.cargo;
            return View(listaCargos.ToList());
        }

        public ActionResult UsuarioXCargo(string tcargo)
        {
            var modelo = from p in entidad.usuario where p.cargo.car_des == tcargo select p;
            return View(modelo.ToList());
        }

        public ActionResult ListadoUsuarioConDescripcionCargo()
        {
            var modelo = from p in entidad.usuario
                         join c in entidad.cargo
                             on p.car_cod equals c.car_cod
                         select new ElUsuario
                         {
                             codigo = p.usu_cod,
                             nombre = p.usu_nom,
                             cargo = c.car_des
                         };

            return View(modelo.ToList());
        }




    }
}
