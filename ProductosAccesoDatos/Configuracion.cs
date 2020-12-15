using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosAccesoDatos
{
    public class Configuracion
    {
        
        public SqlConnection ObtenerConexion ()
        {
            SqlConnection connection = new SqlConnection("server=localhost;database=Productos;integrated security=true");
            connection.Open();

            return connection;
        }
        
    }
}
