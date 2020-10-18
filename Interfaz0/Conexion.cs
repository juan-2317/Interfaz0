using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Interfaz0
{
    public class Conexion
    {
        private static SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private SqlDataAdapter da;

        public Conexion(string baseDatos)
        {
            try
            {
                // Ruta de la conexión
                cn = new SqlConnection("Data Source=.;Initial Catalog=" + baseDatos + ";Integrated Security=True");
                // Abrir conexión
                cn.Open();
                MessageBox.Show("Conexión a la base de datos realizada correctamente");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se conectó a la base de datos: " + ex.Message);
            }
        }

        public string InsertarUsuario(string nombre, string ciudad, string direccion, string fecha, string clave)
        {
            string salida = "Registro exitoso";
            try
            {
                cmd = new SqlCommand("insert into usuario values(next value for usuario_sequencia, '"
                    + nombre + "', '" + ciudad + "', '" + direccion + "', '" + fecha + "', '" + clave + "')", cn);
                // Ejecutar sentencia
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                salida = "No se conectó: " + ex.Message;
            }
            return salida;
        }

        public void InsertarHistorial(string tipoCodigo, string contenido)
        {
            try
            {
                int codigo = 0;
                cmd = new SqlCommand("select cod_usuario from usuario where nombre = '"
                    + Validacion.NombreUsuario + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr.GetInt32(0);
                }
                dr.Close();
                DateTime thisDay = DateTime.Now;
                cmd = new SqlCommand("insert into historial values(next value for historial_sequencia, "
                    + codigo + ", '" + tipoCodigo + "', '" + contenido + "', '" + thisDay.ToString() + "')", cn);
                // Ejecutar sentencia
                cmd.ExecuteNonQuery();            
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar el historial " + ex.Message);
            }
        }

        // Este método es para saber cuantas personas existen con un código determinado
        public int PersonaRegistrada(int codigoUsuario)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("select * from where codigo_usuario = " + codigoUsuario, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo realizar la consulta: " + ex.Message);
            }
            return contador;
        }

        public void CargarHistorial(DataGridView dgv)
        {
            try
            {
                int codigo = 0;
                cmd = new SqlCommand("select cod_usuario from usuario where nombre = '"
                    + Validacion.NombreUsuario + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr.GetInt32(0);
                }
                dr.Close();
                da = new SqlDataAdapter("select tipo_codigo, contenido, fecha from historial where cod_usuario = "
                    + codigo, cn);
                DataTable dt; dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo llenar el Datagridview: " + ex.Message);
            }
        }

        // Un método get se puede declarar como en Java, pero C# tiene esta notación
        //  especial
        public static SqlConnection Cn
        {
            get
            {
                return cn;
            }           
        }
        
        public string GetClave(string usuario, string clave)
        {
            string txt = "";
            try
            {
                cmd = new SqlCommand("select clave from usuario where nombre = '"
                    + usuario + "' and clave = '" + clave + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt = dr.GetString(0);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("No se pudo realizar la consulta " + e.Message);
            }
            dr.Close();
            return txt;
        }

        public string GetNombreUsuario(string clave, string usuario)
        {
            string txt = "";
            try
            {
                cmd = new SqlCommand("select nombre from usuario where clave = '" + clave
                    + "' and nombre = '" + usuario + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt = dr.GetString(0);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("No se pudo realizar la consulta " + e.Message);
            }
            dr.Close();
            return txt;           
        }
    }
}
