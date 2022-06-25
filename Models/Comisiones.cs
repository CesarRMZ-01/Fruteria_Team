using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fruteria_Team.Models
{
    public partial class Comisiones
    {
        public int IdComision { get; set; }
        public int Idvendedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Comision { get; set; }

        public virtual Vendedores IdvendedorNavigation { get; set; }
    }
}
