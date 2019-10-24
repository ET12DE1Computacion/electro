using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumo.Context;
using Microsoft.AspNetCore.Mvc;

namespace Consumo.Controllers
{
    public class ElectrodomesticoController : Controller
    {
        public ElectrodomesticoController()
        {
        }

        public IActionResult Index()
        {
            var db = new ConsumoDbContext();

            return View("Index", db.Electrodomestico.ToList());
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Electrodomestico electrodomestico)
        {
            var db = new ConsumoDbContext();

            db.Electrodomestico.Add(electrodomestico);

            db.SaveChanges();

            return View("Index", db.Electrodomestico.ToList());
        }
    }
}