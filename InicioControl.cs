using System;
using System.Windows.Forms;

namespace LookScan
{
    public partial class InicioControl : UserControl
    {
        public event EventHandler IniciarClick;

        public InicioControl()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e) => IniciarClick?.Invoke(this, EventArgs.Empty);

        private void btnPortalEducativo_Click_1(object sender, EventArgs e) => Abrir("https://youtube.com/@incognitax-r3i?si=kaaM_JCgDI-LEHuQ");

        private void btnComingSoon_Click(object sender, EventArgs e) => Abrir("https://rodriguezj-eng.github.io/LookScan_Help/");

        private static void Abrir(string url) =>
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
    }
}
