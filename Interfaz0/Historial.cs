using System;
using System.Windows.Forms;

namespace Interfaz0
{
    public partial class Historial : Form
    {
        private Conexion c;

        public Historial(Conexion c)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.c = c;
            c.CargarHistorial(dgTabla);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(c);
            menu.Show();
        }
    }
}
