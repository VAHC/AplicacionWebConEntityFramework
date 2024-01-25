using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWebConEntityFramework.Models;
namespace MiPrimeraAplicacionWebConEntityFramework.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleado = null;
            using(var bd=new BDPasajeEntities())
            {
                listaEmpleado = (from empleado in bd.Empleado
                                 join tipoUsuario in bd.TipoUsuario
                                 on empleado.IIDTIPOUSUARIO equals tipoUsuario.IIDTIPOUSUARIO
                                 join tipoContrato in bd.TipoContrato
                                 on empleado.IIDTIPOCONTRATO equals tipoContrato.IIDTIPOCONTRATO
                                 where empleado.BHABILITADO == 1
                                 select new EmpleadoCLS
                                 {
                                     iidEmpleado = empleado.IIDEMPLEADO,
                                     nombre = empleado.NOMBRE,
                                     apPaterno = empleado.APPATERNO,
                                     nombreTipoUsuario = tipoUsuario.NOMBRE,
                                     nombreTipoContrato = tipoContrato.NOMBRE
                                 }).ToList();
            }
            return View(listaEmpleado);
        }

        public void listarComboSexo()
        {
            //agregar
            List<SelectListItem> lista;
            using(var bd=new BDPasajeEntities())
            {
                lista = (from sexo in bd.Sexo
                         where sexo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = sexo.NOMBRE,
                             Value = sexo.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaSexo = lista;
            }
        }

        public void listarTipoContrato()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoContrato
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOCONTRATO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoContrato = lista;
            }
        }

        public void listarTipoUsuario()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoUsuario
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOUSUARIO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoUsuario = lista;
            }
        }

        public void listarCombos()
        {
            listarTipoUsuario();
            listarTipoContrato();
            listarComboSexo();
        }

        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(EmpleadoCLS oEmpleadoCLS)
        {
            if (!ModelState.IsValid)
            {
                listarCombos();
                return View(oEmpleadoCLS);
            }
            using(var bd=new BDPasajeEntities())
            {
                Empleado oEmpleado = new Empleado();
                oEmpleado.NOMBRE = oEmpleadoCLS.nombre;
                oEmpleado.APPATERNO = oEmpleadoCLS.apPaterno;
                oEmpleado.APMATERNO = oEmpleadoCLS.apMaterno;
                oEmpleado.FECHACONTRATO = oEmpleadoCLS.fechaContrato;
                oEmpleado.SUELDO = oEmpleadoCLS.sueldo;
                oEmpleado.IIDTIPOUSUARIO = oEmpleadoCLS.iidTipoUsuario;
                oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.iidTipoContrato;
                oEmpleado.IIDSEXO = oEmpleadoCLS.iidSexo;
                oEmpleado.BHABILITADO = 1;

                bd.Empleado.Add(oEmpleado);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int od)
        {
            listarCombos();
            EmpleadoCLS oEmpleadoCLS = new EmpleadoCLS();

            using(var bd = new BDPasajeEntities())
            {
                Empleado oEmpleado = bd.Empleado.Where(p => p.IIDEMPLEADO.Equals(od)).First();
                oEmpleadoCLS.iidEmpleado = oEmpleado.IIDEMPLEADO;
                oEmpleadoCLS.nombre = oEmpleado.NOMBRE;
                oEmpleadoCLS.apPaterno = oEmpleado.APPATERNO;
                oEmpleadoCLS.apMaterno = oEmpleado.APMATERNO;
                oEmpleadoCLS.fechaContrato = (DateTime) oEmpleado.FECHACONTRATO;
                oEmpleadoCLS.sueldo = (decimal) oEmpleado.SUELDO;
                oEmpleadoCLS.iidTipoUsuario = (int) oEmpleado.IIDTIPOUSUARIO;
                oEmpleadoCLS.iidTipoContrato = (int) oEmpleado.IIDTIPOCONTRATO;
                oEmpleadoCLS.iidSexo = (int) oEmpleado.IIDSEXO;
            }
            return View(oEmpleadoCLS);
        }
    }
}