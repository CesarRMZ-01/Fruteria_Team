using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fruteria_Team.Models
{
    public partial class Ventas
    {
        public int Idventa { get; set; }
        public int CodVendedor { get; set; }
        public int CodProducto { get; set; }
        public DateTime Fecha { get; set; }
        public double Kilos { get; set; }

        public virtual Productos CodProductoNavigation { get; set; }
        public virtual Vendedores CodVendedorNavigation { get; set; }
    }
}
