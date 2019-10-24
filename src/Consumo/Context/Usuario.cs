using System;
using System.Collections.Generic;

namespace Consumo.Context
{
    public partial class Usuario
    {
        public Usuario()
        {
            Electrodomestico = new HashSet<Electrodomestico>();
        }

        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<Electrodomestico> Electrodomestico { get; set; }
    }
}
