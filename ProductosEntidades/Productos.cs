using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosEntidades
{
    public class Productos
    {
        private int idProducto;
        private string nombreProducto;
        private decimal precioProducto;
        private int cantidadProducto;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public decimal PrecioProducto { get => precioProducto; set => precioProducto = value; }
        public int CantidadProducto { get => cantidadProducto; set => cantidadProducto = value; }
    }
}
