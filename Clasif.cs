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
        public const string OtrosIngresos = "Otros ingresos";
        public const string GastosFinancieros = "Gastos financieros";
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
            GastosFinancieros, 
            OtrosIngresos,
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
        public static class ClasificadorEfe
        {
            public enum CategoriaEfe
            {
                Efectivo,
                Operacion,
                Inversion,
                Financiacion,
                NoAfecta
            }

            // Clasifica una cuenta de balance según su naturaleza para el EFE.
            public static CategoriaEfe ObtenerCategoria(Cuenta cuenta)
            {
                if (cuenta == null || cuenta.Tipo != TipoEstado.BG) return CategoriaEfe.NoAfecta;

                string nombre = Util.Clave(cuenta.Nombre);
                bool esActivo = string.IsNullOrEmpty(cuenta.Clasificacion) || Clasif.EsActivo(cuenta.Clasificacion);

                // Efectivo y equivalentes.
                if (esActivo && EsEfectivo(nombre) &&
                    !Contiene(nombre, "prestamo", "obligacion", "por pagar", "deuda"))
                {
                    return CategoriaEfe.Efectivo;
                }

                // Resultados acumulados y déficit ya se explican por la utilidad neta.
                if (Contiene(nombre, "deficit acumulado", "resultados acumulados",
                                     "utilidades retenidas", "perdidas acumuladas"))
                {
                    return CategoriaEfe.NoAfecta;
                }

                // Cambios patrimoniales no monetarios (revaluaciones, ORI).
                if (Contiene(nombre, "superavit por revaluacion", "revaluacion", "otro resultado integral"))
                {
                    return CategoriaEfe.NoAfecta;
                }

                // Deuda financiera: su variación es actividad de financiamiento.
                if (Contiene(nombre, "prestamo", "obligacion financiera", "obligaciones financieras",
                                     "bono", "deuda financiera", "leasing financiero"))
                {
                    return CategoriaEfe.Financiacion;
                }

                // Aportes de capital.
                if (Contiene(nombre, "aporte de capital", "aportes de capital", "capital social",
                                     "emision de acciones", "acciones", "aporte inicial", "aporte por alivio"))
                {
                    return CategoriaEfe.Financiacion;
                }

                // Los intereses por pagar se mantienen en operación para conciliar con el gasto financiero.
                if (Contiene(nombre, "interes")) return CategoriaEfe.Operacion;

                if (Clasif.EsActivo(cuenta.Clasificacion))
                {
                    // Las cuentas no corrientes (activos fijos, intangibles, CxC de largo plazo) son inversión.
                    return Util.Igual(cuenta.Clasificacion, Clasif.ActivoNoCorriente)
                        ? CategoriaEfe.Inversion
                        : CategoriaEfe.Operacion;
                }

                if (Clasif.EsPasivo(cuenta.Clasificacion) || Clasif.EsPatrimonio(cuenta.Clasificacion))
                {
                    return CategoriaEfe.Operacion;
                }

                return CategoriaEfe.NoAfecta;
            }

            // Sobrecarga por nombre para usos puntuales donde no se tiene la cuenta completa.
            public static CategoriaEfe ObtenerCategoria(string nombreCuenta)
            {
                return ObtenerCategoria(new Cuenta
                {
                    Tipo = TipoEstado.BG,
                    Nombre = nombreCuenta
                });
            }

            public static bool EsEfectivo(string nombre)
            {
                string n = Util.Clave(nombre);
                return n.Contains("efectivo") || n.Contains("caja") ||
                       n.Contains("banco") || n.Contains("equivalente");
            }

            public static bool EsCxC(Cuenta cuenta)
            {
                if (cuenta == null || cuenta.Tipo != TipoEstado.BG) return false;
                if (!Util.Igual(cuenta.Clasificacion, Clasif.ActivoCorriente)) return false;

                string n = Util.Clave(cuenta.Nombre);
                return n.Contains("cobrar") || n.Contains("cxc") ||
                       n.Contains("cliente") || n.Contains("deudor");
            }

            public static bool EsInventario(Cuenta cuenta)
            {
                if (cuenta == null || cuenta.Tipo != TipoEstado.BG) return false;
                if (!Util.Igual(cuenta.Clasificacion, Clasif.ActivoCorriente)) return false;

                string n = Util.Clave(cuenta.Nombre);
                return n.Contains("inventario") || n.Contains("mercancia") || n.Contains("existencia");
            }

            public static bool EsGastoAnticipado(Cuenta cuenta)
            {
                if (cuenta == null || cuenta.Tipo != TipoEstado.BG) return false;
                if (!Util.Igual(cuenta.Clasificacion, Clasif.ActivoCorriente)) return false;

                string n = Util.Clave(cuenta.Nombre);
                return n.Contains("anticipado") || n.Contains("gastos pagados") || n.Contains("seguro pagado");
            }

            public static bool EsCxPComercial(Cuenta cuenta)
            {
                if (cuenta == null || cuenta.Tipo != TipoEstado.BG) return false;
                if (!Clasif.EsPasivo(cuenta.Clasificacion)) return false;

                string n = Util.Clave(cuenta.Nombre);

                if (Contiene(n, "prestamo", "interes", "financier", "impuesto",
                                  "tribut", "sunat", "estado", "gastos acumulados"))
                {
                    return false;
                }

                return Contiene(n, "proveedor", "acreedor", "por pagar a", "cuentas por pagar");
            }

            public static bool EsGastoAcumulado(Cuenta cuenta)
            {
                if (cuenta == null || cuenta.Tipo != TipoEstado.BG) return false;
                if (!Clasif.EsPasivo(cuenta.Clasificacion)) return false;

                string n = Util.Clave(cuenta.Nombre);
                return Contiene(n, "gastos acumulados", "gastos por pagar", "acumulados");
            }

            public static bool EsInteresPorPagar(Cuenta cuenta)
            {
                if (cuenta == null || cuenta.Tipo != TipoEstado.BG) return false;
                if (!Clasif.EsPasivo(cuenta.Clasificacion)) return false;

                return Util.Clave(cuenta.Nombre).Contains("interes");
            }

            private static bool Contiene(string texto, params string[] claves)
            {
                foreach (string clave in claves)
                {
                    if (texto.Contains(Util.Clave(clave))) return true;
                }
                return false;
            }
        }
    }
}
