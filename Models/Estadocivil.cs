using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fruteria_Team.Models
{
    public partial class Estadocivil
    {
        public Estadocivil()
        {
            Vendedores = new HashSet<Vendedores>();
        }

        public int Id { get; set; }
        public string EstadoCivil1 { get; set; }

        public virtual ICollection<Vendedores> Vendedores { get; set; }
    }
}
