﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWebConEntityFramework.Models;
namespace MiPrimeraAplicacionWebConEntityFramework.Controllers
{
    public class BusController : Controller
    {
        public void listarTipoBus()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoBus
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOBUS.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoBus = lista;
            }
        }

        public void listarMarca()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Marca
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMARCA.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaMarca = lista;
            }
        }

        public void listarModelo()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Modelo
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMODELO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaModelo = lista;
            }
        }

        public void listarSucursal()
        {
            //agregar
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Sucursal
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDSUCURSAL.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaSucursal = lista;
            }
        }

        public void listarCombos()
        {
            listarTipoBus();
            listarMarca();
            listarModelo();
            listarSucursal();
        }
        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(BusCLS oBusCLS)
        {
            int nregistrosEncontrados = 0;
            string placa = oBusCLS.placa;

            using(var bd=new BDPasajeEntities())
            {
                nregistrosEncontrados = bd.Bus.Where(p => p.PLACA.Equals(placa)).Count();
            }
            if (!ModelState.IsValid || nregistrosEncontrados >= 1)
            {
                if (nregistrosEncontrados >= 1) oBusCLS.mensajeError = "Ya existe el Bus";
                listarCombos();
                return View(oBusCLS);
            }

            using(var bd=new BDPasajeEntities())
            {
                Bus oBus = new Bus();
                oBus.IIDSUCURSAL = oBusCLS.iidSucursal;
                oBus.IIDTIPOBUS = oBusCLS.iidTipoBus;
                oBus.PLACA = oBusCLS.placa;
                oBus.FECHACOMPRA = oBusCLS.fechaCompra;
                oBus.IIDMODELO = oBusCLS.iidModelo;
                oBus.NUMEROFILAS = oBusCLS.numeroFilas;
                oBus.NUMEROCOLUMNAS = oBusCLS.numeroColumnas;
                oBus.DESCRIPCION = oBusCLS.descripcion;
                oBus.OBSERVACION = oBusCLS.observacion;
                oBus.IIDMARCA = oBusCLS.iidmarca;
                oBus.BHABILITADO = 1;

                bd.Bus.Add(oBus);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(BusCLS oBusCLS)
        {
            int idBus = oBusCLS.iidBus;
            int nregistrosEncontrados = 0;
            string placa = oBusCLS.placa;

            using (var bd = new BDPasajeEntities())
            {
                nregistrosEncontrados = bd.Bus.Where(p => p.PLACA.Equals(placa) && !p.IIDBUS.Equals(idBus)).Count();
            }
            
            if (!ModelState.IsValid || nregistrosEncontrados >= 1)
            {
                if (nregistrosEncontrados >= 1) oBusCLS.mensajeError = "El Bus ya existe";
                listarCombos();
                return View(oBusCLS);
            }
            using(var bd=new BDPasajeEntities())
            {
                Bus oBus = bd.Bus.Where(p => p.IIDBUS.Equals(idBus)).First();

                oBus.IIDSUCURSAL = oBusCLS.iidSucursal;
                oBus.PLACA = oBusCLS.placa;
                oBus.FECHACOMPRA = oBusCLS.fechaCompra;
                oBus.IIDMODELO = oBusCLS.iidModelo;
                oBus.NUMEROCOLUMNAS = oBusCLS.numeroColumnas;
                oBus.NUMEROFILAS = oBusCLS.numeroFilas;
                oBus.DESCRIPCION = oBusCLS.descripcion;
                oBus.OBSERVACION = oBusCLS.observacion;
                oBus.IIDMARCA = oBusCLS.iidmarca;

                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            BusCLS oBusCLS = new BusCLS();
            listarCombos();
            using(var bd= new BDPasajeEntities())
            {
                Bus oBus = bd.Bus.Where(p => p.IIDBUS.Equals(id)).First();
                oBusCLS.iidBus = oBus.IIDBUS;
                oBusCLS.iidSucursal = (int)oBus.IIDSUCURSAL;
                oBusCLS.iidTipoBus = (int)oBus.IIDTIPOBUS;
                oBusCLS.placa = oBus.PLACA;
                oBusCLS.fechaCompra = (DateTime)oBus.FECHACOMPRA;
                oBusCLS.iidModelo = (int)oBus.IIDMODELO;
                oBusCLS.numeroColumnas = (int)oBus.NUMEROCOLUMNAS;
                oBusCLS.numeroFilas = (int)oBus.NUMEROFILAS;
                oBusCLS.descripcion = oBus.DESCRIPCION;
                oBusCLS.observacion = oBus.OBSERVACION;
                oBusCLS.iidmarca = (int)oBus.IIDMARCA;
            }
            return View(oBusCLS);
        }

        // GET: Bus
        public ActionResult Index(BusCLS oBusCLS)
        {
            listarCombos();
            List<BusCLS> listaRpta = new List<BusCLS>();
            List<BusCLS> listaBus = null;
            using(var bd=new BDPasajeEntities())
            {
                listaBus = (from bus in bd.Bus

                            join sucursal in bd.Sucursal
                            on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL

                            join tipoBus in bd.TipoBus
                            on bus.IIDTIPOBUS equals tipoBus.IIDTIPOBUS

                            join tipoModelo in bd.Modelo
                            on bus.IIDMODELO equals tipoModelo.IIDMODELO

                            where bus.BHABILITADO == 1

                            select new BusCLS
                            {
                                iidBus = bus.IIDBUS,
                                placa = bus.PLACA,
                                nombreModelo = tipoModelo.NOMBRE,
                                nombreSucursal = sucursal.NOMBRE,
                                nombreTipoBus = tipoBus.NOMBRE,
                                iidModelo = tipoModelo.IIDMODELO,
                                iidSucursal = sucursal.IIDSUCURSAL,
                                iidTipoBus = tipoBus.IIDTIPOBUS
                            }).ToList();

                if (oBusCLS.iidBus == 0 && oBusCLS.placa == null
                    && oBusCLS.iidModelo == 0 && oBusCLS.iidSucursal == 0
                    && oBusCLS.iidTipoBus == 0) 
                {
                    listaRpta = listaBus;
                }
                else
                {
                    // Filtro por Bus
                    if(oBusCLS.iidBus != 0)
                    {
                        listaBus = listaBus.Where(p => p.iidBus.ToString().Contains(oBusCLS.iidBus.ToString())).ToList();
                    }
                    // Filtro por Placa
                    if (oBusCLS.placa != null)
                    {
                        listaBus = listaBus.Where(p => p.placa.Contains(oBusCLS.placa)).ToList();
                    }
                    // Filtro por Modelo
                    if (oBusCLS.iidModelo != 0)
                    {
                        listaBus = listaBus.Where(p => p.iidModelo.ToString().Contains(oBusCLS.iidModelo.ToString())).ToList();
                    }
                    // Filtro por Sucursal
                    if (oBusCLS.iidSucursal != 0)
                    {
                        listaBus = listaBus.Where(p => p.iidSucursal.ToString().Contains(oBusCLS.iidSucursal.ToString())).ToList();
                    }
                    // Filtro por Tipo Bus
                    if (oBusCLS.iidTipoBus != 0)
                    {
                        listaBus = listaBus.Where(p => p.iidTipoBus.ToString().Contains(oBusCLS.iidTipoBus.ToString())).ToList();
                    }
                    listaRpta = listaBus;
                }
            }

            return View(listaRpta);
        }

        [HttpPost]
        public ActionResult Eliminar(int iidBus)
        {
            using (var bd = new BDPasajeEntities())
            {
                Bus oBus = bd.Bus.Where(p => p.IIDBUS.Equals(iidBus)).First();
                oBus.BHABILITADO = 0;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}