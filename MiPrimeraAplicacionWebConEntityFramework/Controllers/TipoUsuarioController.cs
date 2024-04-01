using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWebConEntityFramework.Models;

namespace MiPrimeraAplicacionWebConEntityFramework.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        public ActionResult Index()
        {
            List<TipoUsuarioCLS> listaTipoUsuario = null;
            using(var bd=new BDPasajeEntities())
            {
                listaTipoUsuario = (from tipoUsuario in bd.TipoUsuario
                                    where tipoUsuario.BHABILITADO == 1
                                    select new TipoUsuarioCLS
                                    {
                                        iidtipousuario = tipoUsuario.IIDTIPOUSUARIO,
                                        nombre = tipoUsuario.NOMBRE,
                                        descripcion = tipoUsuario.DESCRIPCION
                                    }).ToList();
            }
            return View(listaTipoUsuario);
        }
    }
}