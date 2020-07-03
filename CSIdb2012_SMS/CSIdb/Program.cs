using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CSIdb
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int iflags = args.Length;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (iflags == 1)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new FormMain());
            }
        }
    }
}
