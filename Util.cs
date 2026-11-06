using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace LookScan
{
    public static class Util
    {
        private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("es-PE");

        public static bool EnDiseno
        {
            get
            {
                try
                {
                    if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return true;

                    string proceso = Process.GetCurrentProcess().ProcessName;
                    return string.Equals(proceso, "devenv", StringComparison.OrdinalIgnoreCase) ||
                           string.Equals(proceso, "XDesProc", StringComparison.OrdinalIgnoreCase);
                }
                catch
                {
                    return false;
                }
            }
        }

        // Normaliza un texto para comparar nombres sin distinguir mayúsculas,
        // tildes ni espacios repetidos.
        public static string Clave(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;

            string descompuesto = texto.Trim().Normalize(NormalizationForm.FormD);
            var resultado = new StringBuilder(descompuesto.Length);
            bool ultimoEspacio = false;

            foreach (char caracter in descompuesto)
            {
                UnicodeCategory categoria = CharUnicodeInfo.GetUnicodeCategory(caracter);
                if (categoria == UnicodeCategory.NonSpacingMark) continue;

                char letra = char.ToLowerInvariant(caracter);
                if (char.IsWhiteSpace(letra))
                {
                    if (!ultimoEspacio && resultado.Length > 0)
                    {
                        resultado.Append(' ');
                        ultimoEspacio = true;
                    }
                    continue;
                }

                resultado.Append(letra);
                ultimoEspacio = false;
            }

            return resultado.ToString().Trim();
        }

        public static bool Igual(string a, string b)
        {
            return string.Equals(Clave(a), Clave(b), StringComparison.Ordinal);
        }

        public static string Monto(decimal valor)
        {
            return valor.ToString("N2", Cultura);
        }

        public static string Numero(decimal valor, int decimales)
        {
            return valor.ToString("N" + decimales.ToString(CultureInfo.InvariantCulture), Cultura);
        }

        // Recibe una proporción (0.35 = 35 %) y la muestra como porcentaje.
        public static string Pct(decimal? valor)
        {
            return valor.HasValue
                ? (valor.Value * 100m).ToString("N1", Cultura) + "%"
                : "N/D";
        }

        public static string Veces(decimal? valor)
        {
            return valor.HasValue
                ? valor.Value.ToString("N2", Cultura) + "x"
                : "N/D";
        }

        public static string Dias(decimal? valor)
        {
            return valor.HasValue
                ? valor.Value.ToString("N0", Cultura) + " días"
                : "N/D";
        }
    }
}
