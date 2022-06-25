using Fruteria_Team.Models;
using Fruteria_Team.Repositories;
using Fruteria_Team.Views;
using GalaSoft.MvvmLight.Command;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fruteria_Team.ViewModels
{
    public class FruteriaViewModel : INotifyPropertyChanged
    {

        private string error;
        public string Error
        {
            get { return error; }
            set { error = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Error")); }
        }
        private List<Poblacion> pobl;
        public List<Poblacion> Pobl
        {
            get { return pobl; }
            set { pobl = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pobl")); }
        }
        private List<Vendedores> vend;
        public List<Vendedores> Vend
        {
            get { return vend; }

            set
            {
                vend = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vend"));
            }
        }
        private List<Productos> pro;
        public List<Productos> Pro
        {
            get { return pro; }

            set
            {
                pro = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pro"));
            }
        }
        private List<Grupos> gru;
        public List<Grupos> Gru
        {
            get { return gru; }

            set
            {
                gru = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Gru"));
            }
        }
        private List<Estadocivil> ec;
        public List<Estadocivil> Ec
        {
            get { return ec; }

            set
            {
                ec = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ec"));
            }
        }

        VentasRepository repos = new VentasRepository();
        ProductosRepository reposP = new ProductosRepository();
        VendedoresRepository reposV = new VendedoresRepository();
        ComisionesRepository reposC = new ComisionesRepository();
        private AgregarVenta agregarDialog;
        private EditarVenta editarVDialog;
        private EditarVendedor editarVendedorDialog;
        private EditarProducto editarProductoDialog;
        private VendedoresView vendedorDialog;
        private ProductosView productosDialog;
        private AgregarVendedor AggvendedorDialog;
        
        private ComisionesView comisionesDialog;
        private AgregarProducto AggproductoDialog;
        public ICommand verAgregarVentaCommand { get; set; }
        public ICommand verAgregarVendedor { get; set; }
        public ICommand verAgregarProducto { get; set; }
        public ICommand verProductoCommand { get; set; }
        public ICommand verVendedorCommand { get; set; }
        public ICommand verComisionesCommand { get; set; }
        public ICommand AgregarVentaCommand { get; set; }
        public ICommand AgregarVendedorCommand { get; set; }
        public ICommand AgregarProductoCommand { get; set; }
        public ICommand verEditarCommand { get; set; }
        public ICommand verEditarVendedorCommand { get; set; }
        public ICommand verEditarProductosCommand { get; set; }
        public ICommand EditarCommand { get; set; }
        public ICommand EditarVendedorCommand { get; set; }
        public ICommand EditarProductosCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand ImprimirReporteCommand { get; set; }


        private Ventas ventas;
         public Ventas Ventas
        {
            get { return ventas; }
            set { ventas = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ventas")); }
        }

        private Vendedores vendedores;
        public Vendedores Vendedores
        {
            get { return vendedores; }
            set { vendedores = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vendedores")); }
        }
        private Productos productos;
        public Productos Productos
        {
            get { return productos; }
            set { productos = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Productos")); }
        }
        private Comisiones comisiones;
        public Comisiones Comisiones
        {
            get { return comisiones; }
            set { comisiones = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Comisiones")); }
        }
        private ObservableCollection<Ventas> listaVentas;
        public ObservableCollection<Ventas> ListaVentas
        {
            get { return listaVentas; }
            set { listaVentas = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListaVentas")); }

        }
        private ObservableCollection<Comisiones> listaComisiones;
        public ObservableCollection<Comisiones> ListaComisiones
        {
            get { return listaComisiones; }
            set { listaComisiones = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListaComisiones")); }

        }
        private ObservableCollection<Productos> listaProductos;
        public ObservableCollection<Productos> ListaProductos
        {
            get { return listaProductos; }
            set { listaProductos = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListaProductos")); }

        }
        private ObservableCollection<Vendedores> listaVendedores;
        public ObservableCollection<Vendedores> ListaVendedores
        {
            get { return listaVendedores; }
            set { listaVendedores = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListaVendedores")); }

        }
     
        private void VerVendedor()
        {
            vendedorDialog = new VendedoresView();
            vendedorDialog.DataContext = this;
            Vendedores = new Vendedores();
            vendedorDialog.ShowDialog();
        }
        private void VerProducto()
        {
            productosDialog = new ProductosView();
            productosDialog.DataContext = this;
            Productos = new Productos();
            productosDialog.ShowDialog();
        }
        private void VerComisiones()
        {
            Comisiones = new Comisiones();
            ListaComisiones = new ObservableCollection<Comisiones>(reposC.GetAll());
            reposC= new ComisionesRepository();
            comisionesDialog = new ComisionesView();
            comisionesDialog.DataContext = this;
            comisionesDialog.ShowDialog();
        }
        private void VerAgregarVenta()
        {
            Pro = new List<Productos>(repos.GetPro());
            Vend = new List<Vendedores>(repos.GetV());
            Error = "";
            agregarDialog = new AgregarVenta();
            agregarDialog.DataContext = this;
            Ventas = new Ventas();
            agregarDialog.ShowDialog();
        }
        private void VerAgregarVendedores()
        {
            pobl = new List<Poblacion>(repos.GetP());
            ec = new List<Estadocivil>(repos.GetEc());
            Error = "";
            AggvendedorDialog = new AgregarVendedor();
            AggvendedorDialog.DataContext = this;
            Vendedores = new Vendedores();
            AggvendedorDialog.ShowDialog();
        }
        private void VerAgregarProductos()
        {
            gru = new List<Grupos>(repos.GetG());
            Error = "";
            AggproductoDialog = new AgregarProducto();
            AggproductoDialog.DataContext = this;
            Productos = new Productos();
            AggproductoDialog.ShowDialog();
        }
        private void AgregarVenta()
        {
            Error = "";
            try
            {
                if (repos.Validate(ventas))
                {
                    repos.Insert(ventas);

                    agregarDialog.Close();
                    Error = "";
                    ListaVentas = new ObservableCollection<Ventas>(repos.GetAll());
                    
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        private void AgregarVendedor()
        {
            Error = "";
            try
            {
                if (reposV.Validate(vendedores))
                {
                    reposV.Insert(vendedores);

                    AggvendedorDialog.Close();
                    Error = "";
                    ListaVendedores = new ObservableCollection<Vendedores>(reposV.GetAll());
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        private void AgregarProducto()
        {
            Error = "";
            try
            {
                if (reposP.Validate(productos))
                {
                    reposP.Insert(productos);

                    AggproductoDialog.Close();
                    Error = "";
                    ListaProductos = new ObservableCollection<Productos>(reposP.GetAll());
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private void VerEditar(Ventas v)
        {
            Pro = new List<Productos>(repos.GetPro());
            Vend = new List<Vendedores>(repos.GetV());
            Error = "";
            if (v != null)
            {
                if (v.Idventa != 0)
                {


                    Ventas copia = new Ventas()
                    {
                        Kilos = v.Kilos,
                        Fecha = v.Fecha,
                        
                        CodProducto = v.CodProducto,
                        CodVendedor = v.CodVendedor,
                        Idventa = v.Idventa

                    };
                    Ventas = copia;
                    editarVDialog = new EditarVenta();
                    editarVDialog.DataContext = this;
                    editarVDialog.ShowDialog();
                }
            }
            else
            {
                Error = "Seleccione a una venta para editar";
            }
        }
        private void VerEditarVendedor(Vendedores v)
        {
            pobl = new List<Poblacion>(repos.GetP());
            ec = new List<Estadocivil>(repos.GetEc());
            Error = "";
            if (v != null)
            {
                if (v.IdVendedor != 0)
                {


                    Vendedores copia = new Vendedores()
                    {
                        IdVendedor = v.IdVendedor,
                        CodPostal = v.CodPostal,
                        Direccion = v.Direccion,
                        EstalCivil = v.EstalCivil,
                        FechaAlta = v.FechaAlta,
                        FechaNac = v.FechaNac,
                        Nif = v.Nif,
                        NombreVendedor = v.NombreVendedor,
                        Poblacion = v.Poblacion,
                        Telefon = v.Telefon
                                  


                    };
                    Vendedores = copia;
                    editarVendedorDialog = new EditarVendedor();
                    editarVendedorDialog.DataContext = this;
                    editarVendedorDialog.ShowDialog();
                }
            }
            else
            {
                Error = "Seleccione a un vendedor para editar";
            }
        }
        private void VerEditarProducto(Productos p)
        {
            gru = new List<Grupos>(repos.GetG());
         
            Error = "";
            if (p != null)
            {
                if (p.IdProducto != 0)
                {


                    Productos copia = new Productos()
                    {
                       IdProducto=p.IdProducto,
                        NomProducto=p.NomProducto,
                         Precio=p.Precio,
                          IdGrupo=p.IdGrupo
                    };
                    Productos = copia;
                    editarProductoDialog = new EditarProducto();
                    editarProductoDialog.DataContext = this;
                    editarProductoDialog.ShowDialog();
                }
            }
            else
            {
                Error = "Seleccione un producto para editar";
            }
        }
        public void Editar()
        {
            Error = "";
            try
            {
                if (repos.Validate(ventas))
                {
                    repos.Update(ventas);

                    editarVDialog.Close();
                    Error = "";
                    ListaVentas = new ObservableCollection<Ventas>(repos.GetAll());
                }
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
        }
        public void EditarVendedor()
        {
            Error = "";
            try
            {
                if (reposV.Validate(vendedores))
                {
                    reposV.Update(vendedores);

                    editarVendedorDialog.Close();
                    Error = "";
                    ListaVendedores = new ObservableCollection<Vendedores>(reposV.GetAll());
                }
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
        }
        public void EditarProducto()
        {
            Error = "";
            try
            {
                if (reposP.Validate(productos))
                {
                    reposP.Update(productos);

                    editarProductoDialog.Close();
                    Error = "";
                    ListaProductos= new ObservableCollection<Productos>(reposP.GetAll());
                }
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
        }
        public void Eliminar(Ventas v)
        {
            Error = "";
            try
            {
                if (v == null)
                {
                    Error = "Seleccione una venta que quiera eliminar";
                }
                else
                {
                    repos.Delete(v);
                    ListaVentas = new ObservableCollection<Ventas>(repos.GetAll());
                }
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }
        }
        private void Cancelar()
        {
            Error = "";
            Ventas = null;
            if (editarVDialog != null)
            {
                editarVDialog.Close();
            }
            if (editarVendedorDialog!=null)
            {
                editarVendedorDialog.Close();
            }
            if (editarProductoDialog!=null)
            {
                editarProductoDialog.Close();
            }
           
        }
        private void ImprimirDatos()
        {
            Vend = reposV.GetAll().ToList();
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "Views/Informe.rdlc";
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", Vend));
            Warning[] warnings = null;
            string[] streamIds = null;
            string mimeType = string.Empty;
            string enconding = string.Empty;
            string extension = string.Empty;
            string filetype = string.Empty;
            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out enconding, out extension, out streamIds, out warnings);
            FileStream fs = new FileStream("ListaVendedores.pdf", FileMode.OpenOrCreate);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            Process.Start(new ProcessStartInfo(fs.Name) { UseShellExecute = true });
        }
        public FruteriaViewModel()
        {
            ListaVentas = new ObservableCollection<Ventas>(repos.GetAll());
            ListaProductos = new ObservableCollection<Productos>(reposP.GetAll());
            ListaVendedores = new ObservableCollection<Vendedores>(reposV.GetAll());
            ListaComisiones = new ObservableCollection<Comisiones>(reposC.GetAll());
            verAgregarVentaCommand = new RelayCommand(VerAgregarVenta);
            verVendedorCommand = new RelayCommand(VerVendedor);
            verProductoCommand = new RelayCommand(VerProducto);
            verAgregarVendedor = new RelayCommand(VerAgregarVendedores);
            verAgregarProducto = new RelayCommand(VerAgregarProductos);
            verComisionesCommand = new RelayCommand(VerComisiones);
            AgregarVentaCommand = new RelayCommand(AgregarVenta);
            AgregarVendedorCommand = new RelayCommand(AgregarVendedor);
            AgregarProductoCommand = new RelayCommand(AgregarProducto);
            EliminarCommand = new RelayCommand<Ventas>(Eliminar);
            verEditarCommand = new RelayCommand<Ventas>(VerEditar);
            verEditarVendedorCommand = new RelayCommand<Vendedores>(VerEditarVendedor);
            verEditarProductosCommand = new RelayCommand<Productos>(VerEditarProducto);
            EditarCommand = new RelayCommand(Editar);
            EditarVendedorCommand = new RelayCommand(EditarVendedor);
            EditarProductosCommand = new RelayCommand(EditarProducto);
            CancelarCommand = new RelayCommand(Cancelar);
            ImprimirReporteCommand = new RelayCommand(ImprimirDatos);

           
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
