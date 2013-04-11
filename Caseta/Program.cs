using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Caseta
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config c = new Config();
            c.inihelper = new INIHelper(Directory.GetCurrentDirectory() + @"\Configuracion.ini");
            bool abre = false;
            
            if (c.inihelper.IniReadValue(Constantes.Seccion, Constantes.Llave) == string.Empty)
                abre = true;

            if (args != null)
                if (args.Length > 0)
                    if (args[0] == "/config")
                        abre = true;

            if (abre)
                c.ShowDialog();

            if (c.inihelper.IniReadValue(Constantes.Seccion, Constantes.Llave) != string.Empty)
            {
                Principal p = new Principal();
                p.Ruta = c.inihelper.IniReadValue(Constantes.Seccion, Constantes.Llave);
                Application.Run(p);
            }
        }
    }
}
