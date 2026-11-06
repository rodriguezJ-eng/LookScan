using System;

namespace LookScan
{
    public static class Clasif
    {
        public const string ActivoCorriente = "Activo corriente";
        public const string ActivoNoCorriente = "Activo no corriente";
        public const string PasivoCorriente = "Pasivo corriente";
        public const string PasivoNoCorriente = "Pasivo no corriente";
        public const string Patrimonio = "Patrimonio";
        public const string Ventas = "Ventas";
        public const string CostoVentas = "Costo de ventas";
        public const string GastosOperativos = "Gastos operativos";
        public const string OtrosIngresosGastos = "Otros ingresos/gastos";
        public const string Impuestos = "Impuestos";

        private static readonly string[] Balance =
        {
            ActivoCorriente,
            ActivoNoCorriente,
            PasivoCorriente,
            PasivoNoCorriente,
            Patrimonio
        };

        private static readonly string[] Resultados =
        {
            Ventas,
            CostoVentas,
            GastosOperativos,
            OtrosIngresosGastos,
            Impuestos
        };

        public static string[] DeBalance
        {
            get { return (string[])Balance.Clone(); }
        }

        public static string[] DeResultados
        {
            get { return (string[])Resultados.Clone(); }
        }

        public static bool EsDeBalance(string clasificacion)
        {
            foreach (string item in Balance)
                if (Util.Igual(item, clasificacion)) return true;
            return false;
        }

        public static bool EsDeResultados(string clasificacion)
        {
            foreach (string item in Resultados)
                if (Util.Igual(item, clasificacion)) return true;
            return false;
        }

        public static bool EsActivo(string clasificacion)
        {
            return Util.Igual(ActivoCorriente, clasificacion) ||
                   Util.Igual(ActivoNoCorriente, clasificacion);
        }

        public static bool EsPasivo(string clasificacion)
        {
            return Util.Igual(PasivoCorriente, clasificacion) ||
                   Util.Igual(PasivoNoCorriente, clasificacion);
        }

        public static bool EsPatrimonio(string clasificacion)
        {
            return Util.Igual(Patrimonio, clasificacion);
        }

        public static int Orden(string clasificacion)
        {
            for (int i = 0; i < Balance.Length; i++)
                if (Util.Igual(Balance[i], clasificacion)) return i;

            for (int i = 0; i < Resultados.Length; i++)
                if (Util.Igual(Resultados[i], clasificacion)) return Balance.Length + i;

            return int.MaxValue;
        }
    }
}
