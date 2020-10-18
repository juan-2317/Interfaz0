using System;
using System.Windows.Forms;

namespace Interfaz0
{
    public partial class Generar : Form
    {
        private Conexion c;

        public Generar(Conexion c)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.c = c;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu forma2 = new Menu(c);
            forma2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Texto forma5 = new Texto(c);
            forma5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            URL forma6 = new URL(c);
            forma6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SMS sms = new SMS(c);
            sms.Show();
        }

        private void Generar_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Email mail = new Email(c);
            mail.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ubicacion ubicacion = new Ubicacion(c);
            ubicacion.Show();
        }
    }
}
