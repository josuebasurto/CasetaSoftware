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
    public partial class Config : Form
    {
        public INIHelper inihelper;

        public Config()
        {
            InitializeComponent();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fbdRuta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtNombre.Text = fbdRuta.SelectedPath;
                inihelper.IniWriteValue("General", "Path", fbdRuta.SelectedPath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtNombre.Text))
                inihelper.IniWriteValue(Constantes.Seccion, Constantes.Llave, txtNombre.Text);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
