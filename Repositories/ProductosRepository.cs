using Fruteria_Team.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruteria_Team.Repositories
{
    public class ProductosRepository
    {
        fruteriaContext context = new fruteriaContext();
        Productos p = new Productos();

        public IEnumerable<Productos> GetAll()
        {
            return context.Productos.Include(x => x.IdGrupoNavigation).OrderBy(x => x.NomProducto);
        }
     

        public void Insert(Productos p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public bool Validate(Productos p)
        {
            if (string.IsNullOrWhiteSpace(p.NomProducto))
            {
                throw new ArgumentException("Especifique el nombre del producto");

            }
            if (p.Precio==0)
            {
                throw new ArgumentException("El precio no puede ser 0");
            }
            if (string.IsNullOrWhiteSpace(p.IdGrupo.ToString()))
            {
                throw new ArgumentException("Introduzca el id del grupo");
            }
            return true;
        }
        public void Update(Productos p)
        {
            Productos productos = context.Productos.FirstOrDefault(x => x.IdProducto == p.IdProducto);

            if (productos != null)
            {
                productos.NomProducto = p.NomProducto;
                productos.Precio = p.Precio;
                productos.IdGrupo = p.IdGrupo;
                context.SaveChanges();
            }
        }
        public void Delete(Productos p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
    }
}
