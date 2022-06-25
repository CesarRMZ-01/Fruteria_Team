using Fruteria_Team.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruteria_Team.Repositories
{
    public class VendedoresRepository
    {

        fruteriaContext context = new fruteriaContext();
        Vendedores v = new Vendedores();

        public IEnumerable<Vendedores> GetAll()
        {
            return context.Vendedores.Include(x => x.PoblacionNavigation).Include(x =>x.EstalCivilNavigation).OrderBy(x => x.NombreVendedor);
        }
        public Vendedores GetById(Vendedores v)
        {
            return context.Vendedores.FirstOrDefault(x => x.IdVendedor == v.IdVendedor);
        }

        public void Insert(Vendedores v)
        {
            context.Add(v);
            context.SaveChanges();
        }
        public bool Validate(Vendedores v)
        {
            if (string.IsNullOrWhiteSpace(v.NombreVendedor))
            {
                throw new ArgumentException("Especifique el nombre del vendedor");
            }
            if (v.FechaAlta>DateTime.Now)
            {
                throw new ArgumentException("La fecha de alta no es valida");

            }
            if (string.IsNullOrWhiteSpace(v.Nif.ToString()))
            {
                throw new ArgumentException("Especifique el Nif");
            }
            if (v.FechaNac> DateTime.Now)
            {
                throw new ArgumentException("La fecha de nacimiento no es valida");
            }
           
            if (string.IsNullOrWhiteSpace(v.Poblacion.ToString()))
            {
                throw new ArgumentException("Introduzca la poblacion");

            }
            if (string.IsNullOrWhiteSpace(v.CodPostal))
            {
                throw new ArgumentException("Especifique el codigo postal");
            }
            if (string.IsNullOrWhiteSpace(v.Telefon))
            {
                throw new ArgumentException("Introduzca el telefono");
            }
            if (string.IsNullOrWhiteSpace(v.EstalCivil.ToString()))
            {
                throw new ArgumentException("Coloque el estado civil");
            }
            return true;
        }
        public void Update(Vendedores v)
        {
            Vendedores vendedores = context.Vendedores.FirstOrDefault(x => x.IdVendedor == v.IdVendedor);

            if (vendedores!=null)
            {
                vendedores.IdVendedor = v.IdVendedor;
                vendedores.NombreVendedor = v.NombreVendedor;
                vendedores.FechaAlta = v.FechaAlta;
                vendedores.Nif = v.Nif;
                vendedores.FechaNac = v.FechaNac;
                vendedores.Direccion = v.Direccion;
                vendedores.Poblacion = v.Poblacion;
                vendedores.CodPostal = v.CodPostal;
                vendedores.Telefon = v.Telefon;
                vendedores.EstalCivil = v.EstalCivil;
                context.SaveChanges();
            }
        }
        public void Delete(Vendedores v)
        {
            context.Remove(v);
            context.SaveChanges();
        }


    }
}
