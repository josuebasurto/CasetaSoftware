using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Caseta
{
    public class INIHelper
    {
        #region Variables y constantes
        public string path;
        private const int K_TAMANO = 255;
        #endregion

        #region Llamadas a kernel32
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,string key, string def, StringBuilder retVal,int size, string filePath);
        #endregion

        #region Constructor
        public INIHelper(string PathArchivo)
        {
            path = PathArchivo;
        }
        #endregion

        #region Metodos Expuestos
        public void IniWriteValue(string Seccion, string Llave, string Valor)
        {
            WritePrivateProfileString(Seccion, Llave, Valor, this.path);
        }

        public string IniReadValue(string Seccion, string Llave)
        {
            StringBuilder stringTemporal = new StringBuilder(255);
            int i = GetPrivateProfileString(Seccion, Llave, "", stringTemporal, K_TAMANO, this.path);
            return stringTemporal.ToString();
        }
        #endregion
    }

}
