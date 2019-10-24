using System;
using System.Collections.Generic;

namespace Consumo.Context
{
    public partial class Electrodomestico
    {
        public int IdElectrodomestico { get; set; }
        public int DniUsuario { get; set; }
        public string Nombre { get; set; }
        public double PotenciaKw { get; set; }

        public virtual Usuario DniUsuarioNavigation { get; set; }
    }
}
