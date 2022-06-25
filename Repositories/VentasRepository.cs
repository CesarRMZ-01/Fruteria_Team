using Fruteria_Team.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruteria_Team.Repositories
{
    public class VentasRepository
    {
        fruteriaContext context = new fruteriaContext();
        Ventas v = new Ventas();

        public Ventas GetById(Ventas v)
        {
            return context.Ventas.FirstOrDefault(x => x.Idventa == v.Idventa);
        }
      
            public IEnumerable<Ventas> GetAll()
            {
                return context.Ventas.Include(x => x.CodVendedorNavigation).Include(x => x.CodProductoNavigation).OrderBy(x => x.Idventa);
            }
        
        public IEnumerable<Poblacion> GetP()
        {
            return context.Poblacion.OrderBy(x => x.Id);
        }
        public IEnumerable<Vendedores> GetV()
        {
            return context.Vendedores.OrderBy(x => x.IdVendedor);
        }
        public IEnumerable<Productos> GetPro()
        {
            return context.Productos.OrderBy(x => x.IdProducto);
        }
        public IEnumerable<Grupos> GetG()
        {
            return context.Grupos.OrderBy(x => x.IdGrupo);
        }
        public IEnumerable<Estadocivil> GetEc()
        {
            return context.Estadocivil.OrderBy(x => x.Id);
        }
       
        public void Insert(Ventas v)
        {
            var transaccion = context.Database.BeginTransaction();
            try
            {
                context.Add(v);
                context.SaveChanges();
                transaccion.Commit();
            }
            catch(Exception)
            {
                transaccion.Rollback();
            }
        }
        public void Update(Ventas v)
        {
            var transaccion = context.Database.BeginTransaction();
            try
            {

                Ventas ventas = context.Ventas.FirstOrDefault(x => x.Idventa == v.Idventa);
                if (ventas != null)
                {

                    ventas.Idventa = v.Idventa;
                    ventas.Kilos = v.Kilos;
                    ventas.Fecha = v.Fecha;
                    ventas.CodProducto = v.CodProducto;
                    ventas.CodVendedor = v.CodVendedor;

                    context.SaveChanges();
                    transaccion.Commit();
                }
            }
            catch (Exception)
            {
                transaccion.Rollback();
            }
            }
        
        public void Delete(Ventas v)
        {
            var transaccion = context.Database.BeginTransaction();
            try
            {
                context.Remove(v);
                context.SaveChanges();
                transaccion.Commit();
            }
            catch (Exception)
            {

                transaccion.Rollback();
            }
            
        }
        public bool Validate(Ventas v)
        {
            if (v.Kilos==0)
            {
                throw new ArgumentException("Especifique el numero de kilos a llevar");
            }
            if (string.IsNullOrWhiteSpace(v.CodProducto.ToString()))
            {
                throw new ArgumentException("Especifique el codigo del producto");
            }
            if (string.IsNullOrWhiteSpace(v.CodVendedor.ToString()))
            {
                throw new ArgumentException("Especifique le codigo de vendedor");

            }
            if (v.Fecha > DateTime.Now)
            {
                throw new ArgumentException("La fecha no puede ser antes de la fecha de hoy");
            }
            return true;
        }

    }
}
