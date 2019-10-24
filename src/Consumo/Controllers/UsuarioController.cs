using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumo.Context;
using Consumo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consumo.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioController()
        {
           
        }

        public IActionResult Index()
        {

            var db = new ConsumoDbContext();

            ViewBag.CantidadUsuarios = db.Usuario.Count();

            return View(db.Usuario.Include(x => x.Electrodomestico).ToList());
        }
    }
}