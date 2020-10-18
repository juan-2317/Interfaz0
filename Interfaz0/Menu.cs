using System;
using System.Windows.Forms;

namespace Interfaz0
{
    public partial class Menu : Form
    {
        private Conexion c;
        public Menu(Conexion c)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.c = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Generar forma3 = new Generar(c);
            forma3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Escanear forma4 = new Escanear(c);
            forma4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Historial his = new Historial(c);
            his.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
