using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductosAccesoDatos;
using ProductosEntidades;

namespace ProductosLogicaNegocio
{
    public class ProductoBol
    {
      private ProductosDataAccessLayer dataAccessLayer = new ProductosDataAccessLayer();

        public void RegistrarProducto(Productos producto)
        {
            dataAccessLayer.Insertar(producto);
        }

        public void ActualizarProducto(Productos producto)
        {
            dataAccessLayer.Actualizar(producto);
        }

        public List<Productos> MostrarTodos()
        {
            return dataAccessLayer.ListarProductos();
        }

        public void EliminarProducto(int idProducto)
        {
            dataAccessLayer.Eliminar(idProducto);
        }
    }
}
