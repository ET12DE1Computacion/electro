using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumo.Models
{
    public class Electrodomestico
    {
        public int idElectrodomestico { get; set; }

        public int dniUsuario { get; set; }

        public string nombre { get; set; }

        public double potenciaKW { get; set; }
    }
}
