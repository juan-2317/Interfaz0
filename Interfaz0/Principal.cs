using System;
using System.Windows.Forms;

namespace Interfaz0
{
    static class Principal
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Conexion c = new Conexion("codigoqr");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Validacion(c));
        }
    }
}
