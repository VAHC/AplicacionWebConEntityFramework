using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWebConEntityFramework.Models;
namespace MiPrimeraAplicacionWebConEntityFramework.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index(ClienteCLS oClienteCLS)
        {
            List<ClienteCLS> listaCliente = null;
            int iidsexo = oClienteCLS.iidsexo;
            llenarSexo();
            ViewBag.lista = listaSexo;

            using (var bd= new BDPasajeEntities())
            {
                if(oClienteCLS.iidsexo == 0) { 
                listaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iidcliente = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    apPaterno = cliente.APPATERNO,
                                    apMaterno = cliente.APMATERNO,
                                    telefonoFijo = cliente.TELEFONOFIJO
                                }).ToList();
                }
                else
                {
                    listaCliente = (from cliente in bd.Cliente
                                    where cliente.BHABILITADO == 1
                                    && cliente.IIDSEXO==iidsexo
                                    select new ClienteCLS
                                    {
                                        iidcliente = cliente.IIDCLIENTE,
                                        nombre = cliente.NOMBRE,
                                        apPaterno = cliente.APPATERNO,
                                        apMaterno = cliente.APMATERNO,
                                        telefonoFijo = cliente.TELEFONOFIJO
                                    }).ToList();
                }
            }
            return View(listaCliente);
        }

        public ActionResult Editar(int ad)
        {
            ClienteCLS oClienteCLS = new ClienteCLS();
            using (var bd = new BDPasajeEntities())
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                
                Cliente oCliente = bd.Cliente.Where(p => p.IIDCLIENTE.Equals(ad)).First();
                
                oClienteCLS.iidcliente = oCliente.IIDCLIENTE;
                oClienteCLS.nombre = oCliente.NOMBRE;
                oClienteCLS.apPaterno = oCliente.APPATERNO;
                oClienteCLS.apMaterno = oCliente.APMATERNO;
                oClienteCLS.direccion = oCliente.DIRECCION;
                oClienteCLS.email = oCliente.EMAIL  ;
                oClienteCLS.iidsexo = (int) oCliente.IIDSEXO;
                oClienteCLS.telefonoCelular = oCliente.TELEFONOCELULAR;
                oClienteCLS.telefonoFijo = oCliente.TELEFONOFIJO;
            }
            return View(oClienteCLS);
        }

        [HttpPost]
        public ActionResult Editar(ClienteCLS oClienteCLS)
        {
            int idCliente = oClienteCLS.iidcliente;
            int nregistrosEncontrados = 0;
            string nombre = oClienteCLS.nombre;
            string aPaterno = oClienteCLS.apPaterno;
            string aMaterno = oClienteCLS.apMaterno;

            using (var bd = new BDPasajeEntities())
            {
                nregistrosEncontrados = bd.Cliente.Where(p => p.NOMBRE.Equals(nombre) && p.APPATERNO.Equals(aPaterno) && p.APMATERNO.Equals(aMaterno) && !p.IIDCLIENTE.Equals(idCliente)).Count();
            }

            if (!ModelState.IsValid || nregistrosEncontrados >= 1)
            {
                if (nregistrosEncontrados >= 1) oClienteCLS.mensajeError = "Ya existe el Cliente";
                llenarSexo();
                return View(oClienteCLS);
            }

            using(var bd=new BDPasajeEntities())
            {
                Cliente oCliente = bd.Cliente.Where(p => p.IIDCLIENTE.Equals(idCliente)).First();
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APPATERNO = oClienteCLS.apPaterno;
                oCliente.APMATERNO = oClienteCLS.apMaterno;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.IIDSEXO = oClienteCLS.iidsexo;
                oCliente.TELEFONOCELULAR = oClienteCLS.telefonoCelular;
                oCliente.TELEFONOFIJO = oClienteCLS.telefonoFijo;

                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        List<SelectListItem> listaSexo;

        private void llenarSexo()
        {
            using(var bd=new BDPasajeEntities())
            {
                listaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }
        public ActionResult Agregar()
        {
            llenarSexo();
            ViewBag.lista = listaSexo;
            return View();
        }
        // ViewBag.lista-> permite pasar datos de la controller a la lista


        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            int nregistrosEncontrados = 0;
            string nombre = oClienteCLS.nombre;
            string aPaterno = oClienteCLS.apPaterno;
            string aMaterno = oClienteCLS.apMaterno;
            using (var bd = new BDPasajeEntities())
            {
                nregistrosEncontrados = bd.Cliente.Where(p => p.NOMBRE.Equals(nombre) && p.APPATERNO.Equals(aPaterno) && p.APMATERNO.Equals(aMaterno)).Count();
            }

            if (!ModelState.IsValid || nregistrosEncontrados >= 1)
            {
                if (nregistrosEncontrados >= 1) oClienteCLS.mensajeError = "Ya existe el cliente registrado";
                llenarSexo();
                ViewBag.lista = listaSexo;
                return View(oClienteCLS);
            }
            using (var bd = new BDPasajeEntities())
            {
                Cliente oCliente = new Cliente();
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APPATERNO = oClienteCLS.apPaterno;
                oCliente.APMATERNO = oClienteCLS.apMaterno;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.IIDSEXO = oClienteCLS.iidsexo;
                oCliente.TELEFONOFIJO = oClienteCLS.telefonoFijo;
                oCliente.TELEFONOCELULAR = oClienteCLS.telefonoCelular;
                oCliente.BHABILITADO = 1;
                bd.Cliente.Add(oCliente);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int iidcliente)
        {
            using(var bd= new BDPasajeEntities())
            {
                Cliente oCliente = bd.Cliente.Where(p => p.IIDCLIENTE.Equals(iidcliente)).First();
                oCliente.BHABILITADO = 0;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}