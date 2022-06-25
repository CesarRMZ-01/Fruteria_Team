using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fruteria_Team.Models
{
    public partial class Vendedores
    {
        public Vendedores()
        {
            Comisiones = new HashSet<Comisiones>();
            Ventas = new HashSet<Ventas>();
        }

        public int IdVendedor { get; set; }
        public string NombreVendedor { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Nif { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Direccion { get; set; }
        public int Poblacion { get; set; }
        public string CodPostal { get; set; }
        public string Telefon { get; set; }
        public int EstalCivil { get; set; }

        public virtual Estadocivil EstalCivilNavigation { get; set; }
        public virtual Poblacion PoblacionNavigation { get; set; }
        public virtual ICollection<Comisiones> Comisiones { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
