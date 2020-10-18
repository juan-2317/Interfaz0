using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz0
{
    public partial class SMS : Form
    {
        private Conexion c;

        public SMS(Conexion c)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.c = c;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            qrCodeImgControl1.Text = txtContenido.Text;

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
            c.InsertarHistorial("SMS", txtContenido.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            qrCodeImgControl1.BackColor = colorDialog1.Color;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Generar gen = new Generar(c);
            gen.Show();
        }
    }
}
