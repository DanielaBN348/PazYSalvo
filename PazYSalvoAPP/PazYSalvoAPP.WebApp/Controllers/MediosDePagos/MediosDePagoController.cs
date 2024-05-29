﻿using Microsoft.AspNetCore.Mvc;
using PazYSalvoAPP.Models;
using PazYSalvoAPP.Business.Services;
using PazYSalvoAPP.WebApp.Models.ViewModels;

namespace PazYSalvoAPP.WebApp.Controllers.MediosDePagos
{
    public class MediosDePagoController : Controller
    {
        private readonly IMediosDePagoService _mediosDePagoService;
        public MediosDePagoController(IMediosDePagoService mediosDePagoService)
        {
            _mediosDePagoService = mediosDePagoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarMediosDePagos()
        {
            IQueryable<MediosDePago>? consultaDeMediosDePagos = await _mediosDePagoService.LeerTodos();

            List<MediosDePago> listadoDeMediosDePagos = consultaDeMediosDePagos.Select(f => new MediosDePago
            {
                Id = f.Id,
                Nombre = f.Nombre,
                Descripcion = f.Descripcion,


            }).ToList();

            return PartialView("_listadoDeMediosDePagos",
                              listadoDeMediosDePagos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarClientes([FromBody] MediosDePagoViewModel model)
        {
            MediosDePago mediosDePago = new MediosDePago()
            {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,

            };

            bool response = await _mediosDePagoService.Insertar(mediosDePago);

            if (response)
            {

                return Json(new { success = true, message = "Medio de pago agregado con éxito" });
            }
            else
            {
                return Json(new { success = false, message = "Error al agregar medio de pago" });
            }

        }

        public async Task<IActionResult> EditarMediosDePago(int id)
        {
            var mediosDePago = await _mediosDePagoService.Leer(id);
            MediosDePagoViewModel mediosDePagoAEditar = new MediosDePagoViewModel()
            {
                Id = mediosDePago.Id,
                Nombre = mediosDePago.Nombre,
                Descripcion = mediosDePago.Descripcion,

            };
            return View("EditarMediosDePago", mediosDePagoAEditar);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ActualizarMediosDePago(MediosDePagoViewModel model)
        {
            MediosDePago mediosDePagoAEditar = await _mediosDePagoService.Leer(model.Id);
            if (mediosDePagoAEditar == null)
            {
                TempData["ErrorMessage"] = "Medio de pago no encontrado";
                return RedirectToAction("EditarMediosDePago", new { id = model.Id });
            }

            MediosDePago mediosDePago = new MediosDePago()
            {
                Id = model.Id,
                Nombre = model.Nombre == null ? mediosDePagoAEditar.Nombre : model.Nombre,
                Descripcion = model.Descripcion == null ? mediosDePagoAEditar.Descripcion : model.Descripcion,

            };

            bool response = await _mediosDePagoService.Actualizar(mediosDePago);

            if (response)
            {
                return RedirectToAction("Index", "MediosDePago");
            }
            else
            {
                TempData["ErrorMessage"] = "Error al actualizar medio de pago";
                return RedirectToAction("EditarMediosDePago", new { id = model.Id });
            }
        }
    }
}