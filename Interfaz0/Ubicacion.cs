using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interfaz0
{
    public partial class Ubicacion : Form
    {
        private Conexion c;
        public Ubicacion(Conexion c)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.c = c;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ciudad = txtContenido.Text;
            StringBuilder add = new StringBuilder("https://maps.google.com/maps?q=");
            add.Append(ciudad);
            webBrowser1.Navigate(add.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            qrCodeImgControl1.Text = txtContenido.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Generar generar = new Generar(c);
            generar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Image img = (Image) qrCodeImgControl1.Image.Clone();
            // Obtener la imagen del codigo qr

            // Guardar la imagen en un archivo .jpg
            SaveFileDialog sv = new SaveFileDialog();
            sv.AddExtension = true;
            sv.Filter = "Image JPG (*.jpg)|*.jpg";
            sv.ShowDialog();
            if (!string.IsNullOrEmpty(sv.FileName))
            {
                img.Save(sv.FileName);
            }
            img.Dispose();
            c.InsertarHistorial("Ubicación", txtContenido.Text);
        }
    }
}
