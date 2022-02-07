using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void BotonIr_Click(object sender, EventArgs e)
        {
            if (comboBoxDirecciones.Text.Contains("https://"))
            {
                webBrowser1.Navigate(new Uri(comboBoxDirecciones.Text.ToString()));
            }
            if (!comboBoxDirecciones.Text.Contains("https://"))
            {
                if (comboBoxDirecciones.Text.Contains(".com"))
                {
                    webBrowser1.Navigate(new Uri("https://" + comboBoxDirecciones.Text.ToString()));
                }
            }
            if (!comboBoxDirecciones.Text.Contains("https://"))
            {
                if (!comboBoxDirecciones.Text.Contains(".com"))
                {
                    webBrowser1.Navigate(new Uri("https://www.bing.com/search?q=" + comboBoxDirecciones.Text.ToString() + "&src=IE-SearchBox&FORM=IESR4S&pc=EUPP_"));
                }
            }

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();   
        }

        private void haciaAtrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxDirecciones.SelectedIndex = 0;
            webBrowser1.GoHome();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
