using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fruteria_Team.Models
{
    public partial class Grupos
    {
        public Grupos()
        {
            Productos = new HashSet<Productos>();
        }

        public int IdGrupo { get; set; }
        public string NombreGrupo { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
