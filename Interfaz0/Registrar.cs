using System;
using System.Windows.Forms;

namespace Interfaz0
{
    public partial class Registrar : Form
    {
        private Conexion c;

        public Registrar(Conexion c)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.c = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clave1 = txtClave.Text;
            string clave2 = txtClave2.Text;
            if (!clave1.Equals(clave2))
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {
                string nombre = this.txtUsuario.Text;
                string ciudad = this.txtCiudad.Text;
                string direccion = this.txtDireccion.Text;
                string fecha = this.txtFecha.Text;
                MessageBox.Show(c.InsertarUsuario(nombre, ciudad, direccion, fecha, clave1));
                this.Hide();
                Validacion val = new Validacion(c);
                val.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Validacion val = new Validacion(c);
            val.Show();
        }
    }
}
