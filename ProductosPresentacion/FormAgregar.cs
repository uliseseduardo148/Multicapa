using ProductosEntidades;
using ProductosLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosPresentacion
{
    public partial class FormAgregar : Form
    {
        private Productos producto;
        private readonly ProductoBol productoBol = new ProductoBol();
        private readonly Validador validador = new Validador();
        public FormAgregar(Productos producto)
        {
            InitializeComponent();
            if (producto != null)
            {
                this.producto = producto;
                txtNombre.Text = producto.NombreProducto;
                txtPrecio.Text = producto.PrecioProducto.ToString();
                txtCantidad.Text = producto.CantidadProducto.ToString();
            }
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = validador.EsAlfabetico(txtNombre.Text);
                decimal precio = Convert.ToDecimal(validador.EsDecimal(txtPrecio.Text));
                int cantidad = Convert.ToInt32(validador.EsNumeroEntero(txtCantidad.Text));
                if (producto == null)
                {
                    producto = new Productos();
                    producto.NombreProducto = nombre;
                    producto.PrecioProducto = Convert.ToDecimal(precio);
                    producto.CantidadProducto = Convert.ToInt32(cantidad);
                    productoBol.RegistrarProducto(producto);
                    MessageBox.Show("Datos registrados con éxito");
                }
                else
                {
                    producto.NombreProducto = nombre;
                    producto.PrecioProducto = Convert.ToDecimal(precio);
                    producto.CantidadProducto = Convert.ToInt32(cantidad);
                    productoBol.ActualizarProducto(producto);
                    MessageBox.Show("Datos actualizados con éxito");
                }
                this.Close();
                Form1.f1.TraerTodos();
            }
            catch {
                MessageBox.Show("Verifique los datos");
            }
        }

    }
}
