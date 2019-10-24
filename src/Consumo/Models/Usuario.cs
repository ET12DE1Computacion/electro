﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumo.Models
{
    public class Usuario
    {
        public int dni { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public List<Electrodomestico> electrodomesticos { get; set; }
    }
}
