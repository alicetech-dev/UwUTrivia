using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsK
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //permitir que solo se ejecute una instancia de la aplicacion 
            if (PrimeraInstancia)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new titulo());
            }
            else
            {
                MessageBox.Show("La aplicacion ya se está ejecutando");
                Application.Exit();
            }
        }

        private static bool PrimeraInstancia

        {
            get
            {
                //verifica si ya existe una instancia de la aplicacion
                System.Threading.Mutex exmut;
                string nombre_exmut = "AsK";
                bool nueva;
                exmut = new System.Threading.Mutex(true, nombre_exmut, out nueva);
                return nueva;
            }
        }

    }
}
