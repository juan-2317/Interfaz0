using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace Interfaz0
{
    public partial class Escanear : Form
    {
        private Conexion c;

        public Escanear(Conexion c)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.c = c;
        }


        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Image JPG (*.jpg)|*.jpg",
                InitialDirectory = @"C:\Users\Gepar\Desktop\Codigos barra"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                BarcodeReader br = new BarcodeReader();
                string texto = br.Decode((Bitmap)pictureBox1.Image).ToString();
                txtContenido.Text = texto;
            }
            c.InsertarHistorial("Codigo Escaneado", txtContenido.Text);
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            if (txtContenido.Text != "")
            {
                BarcodeWriter br = new BarcodeWriter();
                br.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = new Bitmap(br.Write(txtContenido.Text), 181, 173);
                pictureBox1.Image = bm;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu forma2 = new Menu(c);
            forma2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
