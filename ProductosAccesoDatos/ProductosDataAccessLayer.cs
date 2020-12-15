using ProductosEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosAccesoDatos
{

    public class ProductosDataAccessLayer
    {
        //Esto deberia cambiarse a la clase de Configuracion
        SqlConnection connection = new SqlConnection("server=localhost;database=Productos;integrated security=true");
        
        /*En esta clase se agregan las 4 operaciones de altas, bajas, consultas y modificaciones
         * se hace la instancia de la clase configuración para obtener la conexión a la base de datos
         */
        public void Insertar(Productos producto) {
            connection.Open();
            string query = ("EXEC SP_insertarProducto @nombre, @precio, @cantidad");
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@nombre", producto.NombreProducto) ;
            command.Parameters.AddWithValue("@precio", producto.PrecioProducto);
            command.Parameters.AddWithValue("@cantidad", producto.CantidadProducto);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Productos> ListarProductos() {
            connection.Open();
            List<Productos> listaProductos = new List<Productos>();
            string query = ("EXEC SP_listarProductos");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Productos producto = new Productos {
                    IdProducto = Convert.ToInt32(reader["fld_idProducto"]),
                    NombreProducto = Convert.ToString(reader["fld_nombreProducto"]),
                    PrecioProducto = Convert.ToDecimal(reader["fld_precio"]),
                    CantidadProducto = Convert.ToInt32(reader["fld_cantidad"])
                    };
                listaProductos.Add(producto);
            }
            connection.Close();
            return listaProductos;
        }

        public void Actualizar(Productos producto) {
            connection.Open();
            string query = ("EXEC SP_modificarProducto @idProducto,@nombre, @precio, @cantidad");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@idProducto", producto.IdProducto);
            command.Parameters.AddWithValue("@nombre", producto.NombreProducto);
            command.Parameters.AddWithValue("@precio", producto.PrecioProducto);
            command.Parameters.AddWithValue("@cantidad", producto.CantidadProducto);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Eliminar(int idProducto) {
            connection.Open();
            string query = ("EXEC SP_eliminarProducto @idProducto");
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@idProducto",idProducto);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
