using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fruteria_Team.Models
{
    public partial class Productos
    {
        public Productos()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int IdProducto { get; set; }
        public string NomProducto { get; set; }
        public int? IdGrupo { get; set; }
        public decimal Precio { get; set; }

        public virtual Grupos IdGrupoNavigation { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
