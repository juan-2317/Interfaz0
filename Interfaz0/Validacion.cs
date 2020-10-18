using System;
using System.Windows.Forms;

namespace Interfaz0
{
    public partial class Validacion : Form
    {
        private Conexion c;
        private static string nombreUsuario;
        public Validacion(Conexion c)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.c = c;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string clave = textBox2.Text;
            string usuarioObtenido = c.GetNombreUsuario(clave, usuario);
            string claveObtenida = c.GetClave(usuario, clave);
            if (usuario.Equals(usuarioObtenido) && clave.Equals(claveObtenida))
            {
                this.Hide();
                Menu forma2 = new Menu(c);
                nombreUsuario = usuario;
                forma2.Show();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registrar reg = new Registrar(c);
            reg.Show();
        }

        public static string NombreUsuario{
            get
            {
                return nombreUsuario;
            }
        }
    }
}
