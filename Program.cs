using System;
using System.Windows.Forms;

namespace LookScan
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>
            {
                string msg = e.Exception != null ? e.Exception.Message : "No se puede completar la operación solicitada.";
                MessageBox.Show("No se puede completar la acción: " + msg, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Exception ex = e.ExceptionObject as Exception;
                string msg = ex != null ? ex.Message : "No se puede completar la operación solicitada.";
                MessageBox.Show("No se puede completar la acción: " + msg, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };

            Application.Run(new MainForm());
        }
    }
}
