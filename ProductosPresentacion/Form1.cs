using ProductosEntidades;
using ProductosLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosPresentacion
{
    public partial class Form1 : Form
    {
        public static Form1 f1;
        private readonly ProductoBol productoBol= new ProductoBol();
        public Form1()
        {
            InitializeComponent();
            Form1.f1 = this;
            TraerTodos();
        }

       
        public void TraerTodos()
        {
            List<Productos> listaProductos = productoBol.MostrarTodos();

            if (listaProductos.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = listaProductos;
                dataGridView1.Columns["columnNombre"].DataPropertyName="NombreProducto";
                dataGridView1.Columns["columnPrecio"].DataPropertyName = "PrecioProducto";
                dataGridView1.Columns["columnCantidad"].DataPropertyName = "CantidadProducto";
            }
            else
                MessageBox.Show("No existen productos registrado");
        }

        private void Eliminar(int id)
        {
            try
            {
                productoBol.EliminarProducto(id);
                MessageBox.Show("Producto eliminado satisfactoriamente");
                TraerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormAgregar formAgregar = new FormAgregar(null);
            formAgregar.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            List<Productos> listaProductos = productoBol.MostrarTodos();
            if (dataGridView1.SelectedRows.Count < 0)
            {
                MessageBox.Show("Seleccione un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else {
                DialogResult dialog = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialog == DialogResult.Yes)
                {
                    int indice = dataGridView1.CurrentCell.RowIndex;
                    int id = listaProductos[indice].IdProducto;
                    productoBol.EliminarProducto(id);
                    MessageBox.Show("Registro eliminado de forma exitosa");
                }
            }
            TraerTodos();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            List<Productos> listaProductos = productoBol.MostrarTodos();
            if (dataGridView1.SelectedRows.Count<0)
            {
                MessageBox.Show("Seleccione un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                int indice = dataGridView1.CurrentCell.RowIndex;
                Productos producto = listaProductos[indice];
                FormAgregar formAgregar = new FormAgregar(producto);
                formAgregar.Show();
            }
        }
    }
}
