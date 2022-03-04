using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Security.Permissions;

namespace Explorador_Web
{
    public partial class Form1 : Form
    {
        List<URL> url = new List<URL>(); 
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
                if (!(comboBoxDirecciones.Items.Contains(comboBoxDirecciones.Text)))
                {
                    URL urls = new URL();
                    urls.Enlace = comboBoxDirecciones.Text;
                    urls.Veces_visitada = 1;
                    urls.Fecha_ultimo_acceso = DateTime.Now;
                    comboBoxDirecciones.Items.Add(comboBoxDirecciones.Text);
                    DROPBOXELIMINAR.Items.Add(comboBoxDirecciones.Text);
                    url.Add(urls);
                }
                else
                {
                    foreach (var busqueda in url)
                    {
                        if (busqueda.Enlace == comboBoxDirecciones.Text)
                        {
                            busqueda.Veces_visitada = busqueda.Veces_visitada + 1;
                            busqueda.Fecha_ultimo_acceso = DateTime.Now;
                        }
                    }
                }
            }
            if (!comboBoxDirecciones.Text.Contains("https://"))
            {
                if (comboBoxDirecciones.Text.Contains(".com"))
                {
                    webBrowser1.Navigate(new Uri("https://" + comboBoxDirecciones.Text.ToString()));
                    if (!(comboBoxDirecciones.Items.Contains("https://" + comboBoxDirecciones.Text)))
                    {
                        URL urls = new URL();
                        urls.Enlace = "https://" + comboBoxDirecciones.Text;
                        urls.Veces_visitada = 1;
                        urls.Fecha_ultimo_acceso = DateTime.Now;
                        comboBoxDirecciones.Items.Add("https://" + comboBoxDirecciones.Text);
                        DROPBOXELIMINAR.Items.Add("https://" + comboBoxDirecciones.Text);
                        url.Add(urls);
                    }
                    else
                    {
                        foreach (var busqueda in url)
                        {
                            if (busqueda.Enlace == "https://" + comboBoxDirecciones.Text)
                            {
                                busqueda.Veces_visitada = busqueda.Veces_visitada + 1;
                                busqueda.Fecha_ultimo_acceso = DateTime.Now;
                            }
                        }
                    }
                }
            }
            if (!comboBoxDirecciones.Text.Contains("https://"))
            {
                if (!comboBoxDirecciones.Text.Contains(".com"))
                {
                    webBrowser1.Navigate(new Uri("https://www.bing.com/search?q=" + comboBoxDirecciones.Text.ToString()));
                    if (!(comboBoxDirecciones.Items.Contains("https://www.bing.com/search?q="+comboBoxDirecciones.Text)))
                    {
                        URL urls = new URL();
                        urls.Enlace = "https://www.bing.com/search?q=" + comboBoxDirecciones.Text;
                        urls.Veces_visitada = 1;
                        urls.Fecha_ultimo_acceso = DateTime.Now;
                        comboBoxDirecciones.Items.Add("https://www.bing.com/search?q=" + comboBoxDirecciones.Text);
                        DROPBOXELIMINAR.Items.Add("https://www.bing.com/search?q=" + comboBoxDirecciones.Text);
                        url.Add(urls);
                    }
                    else
                    {
                        foreach (var busqueda in url)
                        {
                            if (busqueda.Enlace == "https://www.bing.com/search?q=" + comboBoxDirecciones.Text)
                            {
                                busqueda.Veces_visitada = busqueda.Veces_visitada + 1;
                                busqueda.Fecha_ultimo_acceso = DateTime.Now;
                            }
                        }
                    }

                }
            }
            Guardar(nombreArchivo);
            comboBoxDirecciones.Text = "";
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
            Leer(nombreArchivo);
            foreach(var nombre in url)
            {
                if (!(comboBoxDirecciones.Items.Contains(nombre.Enlace)))
                {
                    comboBoxDirecciones.Items.Add(nombre.Enlace);
                    DROPBOXELIMINAR.Items.Add(nombre.Enlace);
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var urls in url)
            {
                writer.WriteLine(urls.Enlace);
                writer.WriteLine(urls.Veces_visitada);
                writer.WriteLine(urls.Fecha_ultimo_acceso);
            }

            writer.Close();
        }

        private void Leer(string Filename)
        {
            FileStream stream = new FileStream(Filename, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                URL urls = new URL();

                urls.Enlace = reader.ReadLine();
                urls.Veces_visitada = Convert.ToInt32(reader.ReadLine());
                urls.Fecha_ultimo_acceso = Convert.ToDateTime(reader.ReadLine());
                url.Add(urls);
            }

            reader.Close();
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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void masRecientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            url = url.OrderByDescending(p => p.Fecha_ultimo_acceso).ToList();
            Leer(nombreArchivo);
            comboBoxDirecciones.Items.Clear();
            DROPBOXELIMINAR.Items.Clear();
            foreach (var nombre in url)
            {
                if (!(comboBoxDirecciones.Items.Contains(nombre.Enlace)))
                {
                    comboBoxDirecciones.Items.Add(nombre.Enlace);
                    DROPBOXELIMINAR.Items.Add(nombre.Enlace);
                }
            }
            MessageBox.Show("El historial se ha ordenado por la fecha de ultimo acceso");
        }

        private void masVisitadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            url = url.OrderByDescending(p => p.Veces_visitada).ToList();
            Leer(nombreArchivo);
            comboBoxDirecciones.Items.Clear();
            DROPBOXELIMINAR.Items.Clear();
            foreach (var nombre in url)
            {
                if (!(comboBoxDirecciones.Items.Contains(nombre.Enlace)))
                {
                    comboBoxDirecciones.Items.Add(nombre.Enlace);
                    DROPBOXELIMINAR.Items.Add(nombre.Enlace);
                }
            }
            MessageBox.Show("El historial se ha ordenado por la veces que ha visitado la pagina");
        }

        private void objetosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            string direccion = DROPBOXELIMINAR.Text;
            url.RemoveAll(p => p.Enlace == DROPBOXELIMINAR.Text);
            comboBoxDirecciones.Items.Clear();
            DROPBOXELIMINAR.Items.Clear();
            Guardar("historial.txt");
            foreach (var nombre in url)
            {
                if (!(comboBoxDirecciones.Items.Contains(nombre.Enlace)))
                {
                    comboBoxDirecciones.Items.Add(nombre.Enlace);
                    DROPBOXELIMINAR.Items.Add(nombre.Enlace);
                }
            }
            MessageBox.Show("La pagina Web ha sido eliminada del historial");
            DROPBOXELIMINAR.Text = "";
            comboBoxDirecciones.Text = "";
            buttonEliminar.Enabled = false;
        }

        private void DROPBOXELIMINAR_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEliminar.Enabled = true;
        }
    }
}
