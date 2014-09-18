using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tablice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NeuralNetworkOperations net = new NeuralNetworkOperations(63 * 69);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
