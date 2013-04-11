using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Caseta
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            InicializaControles();
        }

        WebCam w;

        string path = @"c:\temp\";

        string filepath = @"accesos.csv";

        const string K_PIPE = "K_PIPE";

        private void InicializaControles()
        {
            try
            {
                w = new WebCam();
                w.InitializeWebCam(ref pictureBox1);
                w.Start();
                w.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de la webcam Reinice la aplicacion: " + ex.Message);
            }
            
        }

        private void tmrHorarioEntrada_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            w.Stop();
            txtNombre.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            w.Continue();
        }

        public string Ruta { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Visitante v = new Visitante();
            v.imagen = pictureBox1.Image;
            v.Nombre = txtNombre.Text;
            v.Apellido = txtApellido.Text;
            v.EmpresaOrigen = txtOrg.Text;
            
            v.Persona = txtVisitado.Text;
            v.Empresa = txtEmpresa.Text;
            v.Motivo = txtMotivo.Text;

            v.Ruta = Ruta;

            v.Guarda();

            LimpiaCampos();

            MessageBox.Show("¡Bienvenido! " + Environment.NewLine + txtNombre.Text + " ya has sido registrado.");
        }

        private void LimpiaCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmpresa.Clear();
            txtMotivo.Clear();
            txtOrg.Clear();
            txtVisitado.Clear();
            pictureBox1.InitialImage = null;
        }
    }
}
