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
        private TipoUsuarioCLS oTipoVal;
        private bool buscarTipoUsuario(TipoUsuarioCLS oTipoUsuarioCLS)
        {
            bool busquedaId = true;
            bool busquedaNombre = true;
            bool busquedaDescripcion = true;

            if (oTipoVal.iidtipousuario > 0)
                busquedaId = oTipoUsuarioCLS.iidtipousuario.ToString().Contains(oTipoVal.iidtipousuario.ToString());

            if (oTipoVal.nombre != null)
                busquedaNombre = oTipoUsuarioCLS.nombre.ToString().Contains(oTipoVal.nombre);

            if (oTipoVal.descripcion != null)
                busquedaDescripcion = oTipoUsuarioCLS.descripcion.ToString().Contains(oTipoVal.descripcion);

            return (busquedaId && busquedaNombre && busquedaDescripcion);
        }

        // GET: TipoUsuario
        public ActionResult Index(TipoUsuarioCLS oTipoUsuario)
        {
            oTipoVal = oTipoUsuario;
            List<TipoUsuarioCLS> listaTipoUsuario = null;
            //Pongo una variable
            List<TipoUsuarioCLS> listaFiltrado;
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
                if (oTipoUsuario.iidtipousuario == 0 && oTipoUsuario.nombre == null
                    && oTipoUsuario.descripcion == null)
                    listaFiltrado = listaTipoUsuario;
                else
                {
                    Predicate<TipoUsuarioCLS> pred = new Predicate<TipoUsuarioCLS>(buscarTipoUsuario);
                    listaFiltrado = listaTipoUsuario.FindAll(pred);
                }
            }
            return View(listaFiltrado);
        }
    }
}