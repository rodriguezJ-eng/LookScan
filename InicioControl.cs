using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LookScan
{
    public partial class InicioControl : UserControl
    {
        public event EventHandler IniciarClick;

        public InicioControl()
        {
            InitializeComponent();
            lblHistoria.Text = "LookScan surgió tras detectar la enorme cantidad de horas dedicadas a procesar " +
                         "estados financieros de forma manual en hojas de cálculo propensas a errores. Concebido " +
                         "inicialmente como una herramienta interna para agilizar la integración de datos contables, " +
                         "evolucionó hasta convertirse en un sistema automatizado capaz de vincular de inmediato " +
                         "la captura de datos con el análisis multiperiodo, razones y proyecciones estratégicas.";

            lblPorqueLookScan.Text = "LookScan elimina la fragmentación del análisis financiero al conectar la captura " +
                        "de datos base con el cálculo automático de variaciones, razones y proyecciones en una sola " +
                        "interfaz fluida. Transforma horas de trabajo manual en resultados instantáneos, reduciendo " +
                        "el margen de error y facilitando la interpretación estratégica.";

            lblMision.Text = "Proveer a cualquier persona una plataforma intuitiva y " +
                 "automatizada que simplifique el procesamiento de datos contables, transformando " +
                 "la información financiera en análisis multiperiodo, indicadores y proyecciones " +
                 "precisas para una toma de decisiones eficiente.";
        
            lblVision.Text = "Ser la herramienta referente en análisis financiero automatizado, " +
                "reconocida por su simplicidad, precisión y capacidad para transformar " +
                "datos en decisiones estratégicas.";

            lblValores.Text = "Transparencia en los resultados, rigor en la lógica contable " +
                     "y respeto por el tiempo del usuario al automatizar las tareas repetitivas.";

            lblObjetivos.Text = "1. Automatizar el procesamiento contable reduciendo el tiempo de cálculo manual.\n" +
                    "2. Garantizar la precisión mediante algoritmos validados de análisis multiperiodo.\n" +
                    "3. Optimizar la toma de decisiones transformando datos en reportes e indicadores claros.\n" +
                    "4. Facilitar el aprendizaje y la gestión en entornos académicos y profesionales.";

          

        }

        private static void Abrir(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede abrir el enlace en este momento: " + ex.Message, "LookScan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            IniciarClick?.Invoke(this, EventArgs.Empty);

        }

        private void btnPortalEducativo_Click(object sender, EventArgs e)
        {
            Abrir("https://youtube.com/@incognitax-r3i?si=kaaM_JCgDI-LEHuQ");
        }

        private void btnComingSoon_Click_1(object sender, EventArgs e)
        {
            Abrir("https://rodriguezj-eng.github.io/LookScan_Help/");
        }
    }
}
