using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWebConEntityFramework.Models;
namespace MiPrimeraAplicacionWebConEntityFramework.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje

        public void listarLugar()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Lugar
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDLUGAR.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaLugar = lista;
            }
        }

        public void listarBus()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Bus
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.PLACA,
                             Value = item.IIDBUS.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaBus = lista;
            }
        }

        public void listarCombos()
        {
            listarLugar();
            listarBus();
        }

        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }

        public ActionResult Index()
        {
            List<ViajeCLS> listaViaje = null;
            using(var bd= new BDPasajeEntities())
            {
                listaViaje = (from viaje in bd.Viaje
                              join lugarOrigen in bd.Lugar
                              on viaje.IIDLUGARORIGEN equals lugarOrigen.IIDLUGAR

                              join lugarDestino in bd.Lugar
                              on viaje.IIDLUGARDESTINO equals lugarDestino.IIDLUGAR

                              join bus in bd.Bus
                              on viaje.IIDBUS equals bus.IIDBUS

                              select new ViajeCLS
                              {
                                  iidViaje = viaje.IIDVIAJE,
                                  nombreBus = bus.PLACA,
                                  nombreLugarOrigen = lugarOrigen.NOMBRE,
                                  nombreLugarDestino = lugarDestino.NOMBRE
                              }).ToList();
            }
            return View(listaViaje);
        }
    }
}