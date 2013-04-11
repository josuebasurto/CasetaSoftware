using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace Caseta
{
    public class Visitante
    {
        string _GUID = null;
        public string GUID {
            get
            {
                if (_GUID == null)
                {
                    _GUID = Guid.NewGuid().ToString();
                    return _GUID;
                }
                else return _GUID;
            }
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string EmpresaOrigen { get; set; }
        public string Persona { get; set; }
        public string Empresa { get; set; }
        public string Motivo { get; set; }
        public Image imagen { get; set; }

        public void Guarda()
        {
            try
            {
                GuardaRegistro();
                GuardaImagen();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message);
            }
        }

        public string Ruta { get; set; }

        private void GuardaImagen()
        {
            imagen.Save(Ruta + @"\" + _GUID + ".jpg");
        }

        private void GuardaRegistro()
        {
            using (StreamWriter sw = File.AppendText(Ruta + @"\" + DateTime.Today.ToString("yyyyMMdd") + ".csv"))
            {
                string renglon = "{0},{1},{2},{3},{4},{5},{6},{7}";
                renglon = string.Format(renglon, GUID, Nombre, Apellido, EmpresaOrigen, Persona, Empresa, Motivo, DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                sw.WriteLine(renglon);
                sw.Close();
            }
        }
    }
}
