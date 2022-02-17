using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorador_Web
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string nombreArchivo = "historial.txt";

        private void BotonIr_Click(object sender, EventArgs e)
        {
            if (comboBoxDirecciones.Text.Contains("https://"))
            {
                webBrowser1.Navigate(new Uri(comboBoxDirecciones.Text.ToString()));
                Guardar(@"historial.txt", comboBoxDirecciones.Text.ToString());
            }
            if (!comboBoxDirecciones.Text.Contains("https://"))
            {
                if (comboBoxDirecciones.Text.Contains(".com"))
                {
                    webBrowser1.Navigate(new Uri("https://" + comboBoxDirecciones.Text.ToString()));
                    Guardar(@"historial.txt", "https://" + comboBoxDirecciones.Text.ToString());
                }
            }
            if (!comboBoxDirecciones.Text.Contains("https://"))
            {
                if (!comboBoxDirecciones.Text.Contains(".com"))
                {
                    webBrowser1.Navigate(new Uri("https://www.bing.com/search?q=" + comboBoxDirecciones.Text.ToString()));
                    Guardar(@"historial.txt", "https://www.bing.com/search?q=" + comboBoxDirecciones.Text.ToString());
                }
            }

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                string texto = reader.ReadLine();
                if (!(comboBoxDirecciones.Items.Contains(texto)))
                {
                    comboBoxDirecciones.Items.Add(texto);
                }

            }

            reader.Close();
        }

        private void haciaAtrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                string texto = reader.ReadLine();
                if (!(comboBoxDirecciones.Items.Contains(texto)))
                {
                    comboBoxDirecciones.Items.Add(texto);
                }

            }

            reader.Close();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                string texto = reader.ReadLine();
                if (!(comboBoxDirecciones.Items.Contains(texto)))
                {
                    comboBoxDirecciones.Items.Add(texto);
                }

            }

            reader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxDirecciones.SelectedIndex = 0;
            webBrowser1.GoHome();

            FileStream stream1 = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);
            StreamWriter writter = new StreamWriter(stream1);
            writter.Close();
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                string texto = reader.ReadLine();
                if (!(comboBoxDirecciones.Items.Contains(texto)))
                {
                    comboBoxDirecciones.Items.Add(texto);
                }
                
            }

            reader.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar(string nombreArchivo, string texto)
        {
            FileStream stream = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);

            StreamWriter writter = new StreamWriter(stream);
            writter.Write(texto + "\n");
            writter.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBoxDirecciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxhisto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
