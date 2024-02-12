using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWebConEntityFramework.Models;
namespace MiPrimeraAplicacionWebConEntityFramework.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            List<MarcaCLS> listaMarca = null;
            using (var bd = new BDPasajeEntities())
            {
                listaMarca = (from marca in bd.Marca
                              where marca.BHABILITADO == 1
                                             select new MarcaCLS
                                             {
                                                 iidmarca = marca.IIDMARCA,
                                                 nombre = marca.NOMBRE,
                                                 descripcion = marca.DESCRIPCION
                                             }).ToList();
            }
            return View(listaMarca);
        }
        //Muestra la lista
        public ActionResult Agregar()
        {
            return View();    
        }

        public ActionResult Editar(int uf)
        {
            MarcaCLS oMarcaCLS = new MarcaCLS();
            using(var bd=new BDPasajeEntities())
            {
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(uf)).First();
                oMarcaCLS.iidmarca = oMarca.IIDMARCA;
                oMarcaCLS.nombre = oMarca.NOMBRE;
                oMarcaCLS.descripcion = oMarca.DESCRIPCION;
            }
            return View(oMarcaCLS);
        }

        [HttpPost]
        public ActionResult Editar(MarcaCLS oMarcaCLS)
        {
            int nregistrosEncontrados = 0;
            string nombreMarca = oMarcaCLS.nombre;
            int iidmarca = oMarcaCLS.iidmarca;
            using (var bd = new BDPasajeEntities())
            {
                nregistrosEncontrados = bd.Marca.Where(p => p.NOMBRE.Equals(nombreMarca) && !p.IIDMARCA.Equals(iidmarca)).Count();
            }

            if (!ModelState.IsValid || nregistrosEncontrados >= 1)
            {
                if (nregistrosEncontrados >= 1) oMarcaCLS.mensajeError = "Ya se encuentra registrada la marca";
                return View(oMarcaCLS);
            }
            

            int idMarca = oMarcaCLS.iidmarca;
            using(var bd=new BDPasajeEntities())
            {                
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(idMarca)).First();
                oMarca.NOMBRE = oMarcaCLS.nombre;
                oMarca.DESCRIPCION = oMarcaCLS.descripcion;
                bd.SaveChanges();
            }

            return RedirectToAction("Index");
        }
            
        //Hace la inserción
        [HttpPost]
        public ActionResult Agregar(MarcaCLS oMarcaCLS)
        {
            int nregistrosEncontrados = 0;
            string nombreMarca = oMarcaCLS.nombre;
            using (var bd = new BDPasajeEntities())
            {
                nregistrosEncontrados = bd.Marca.Where(p => p.NOMBRE.Equals(nombreMarca)).Count();
            }
            /////////////////////////////////
            if (!ModelState.IsValid || nregistrosEncontrados  >= 1)
            {
                if (nregistrosEncontrados >= 1) oMarcaCLS.mensajeError = "El nombre Marca ya existe";
                return View(oMarcaCLS);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Marca oMarca = new Marca();
                    oMarca.NOMBRE = oMarcaCLS.nombre;
                    oMarca.DESCRIPCION = oMarcaCLS.descripcion;
                    oMarca.BHABILITADO = 1;
                    bd.Marca.Add(oMarca);
                    bd.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int uf)
        {
            using(var bd=new BDPasajeEntities())
            {
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(uf)).First();
                oMarca.BHABILITADO = 0;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}