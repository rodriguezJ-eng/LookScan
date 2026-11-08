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
                Operacion,
                Inversion,
                Financiacion,
                NoAfecta
            }

            public static CategoriaEfe ObtenerCategoria(string nombreCuenta)
            {
                if (string.IsNullOrEmpty(nombreCuenta)) return CategoriaEfe.NoAfecta;

                // Normalizamos a minúsculas para que las mayúsculas no afecten en nada
                string nombre = nombreCuenta.ToLower().Trim();

                // 1. ACTIVIDADES DE OPERACIÓN (Clientes, Inventarios, Proveedores, Corto Plazo)
                if (ContieneAlguna(nombre, "cobrar", "cliente", "deudor", "inventario", "mercancia", "Cobros a clientes", "Pagos a proveedores", "Pago de salarios", "Pago de alquiler", 
                                           "Pago de servicios básico", "Pago de publicidad", "Pago de gastos administrativos", "Pago de gastos operativos", "Cobro por prestación de servicios",
                                           "existencia", "proveedor", "acreedor","Cobro", "Cliente","Salario","renta","agua","luz","publicidad","pagar","pasivo",
                                           "anticipado", "gastos pagados", "otros activos corrientes", "otros pasivos corrientes"))
                {
                    return CategoriaEfe.Operacion;
                }

                // 2. ACTIVIDADES DE INVERSIÓN (Activos Fijos, Propiedades, Maquinaria, Intangibles)
                if (ContieneAlguna(nombre, "propiedad", "planta", "equipo", "maquinaria", "mobiliario", "Compra de terreno", "Compra de edificio", "Compra de maquinaria", "Compra de mobiliario y equipo",
                                           "Compra de vehículo", "Compra de equipos de computación", "Venta de terrenos","Venta de inmuebles","Adquisicion de acciones","Documento por pagar largo plazo",
                                           "edificio", "terreno", "vehiculo", "intangible", "patente", "marca", "compara de maquinaria y Equipo", "inversiones temporales",
                                           "inversion a largo plazo"))
                {
                    return CategoriaEfe.Inversion;
                }

                // 3. ACTIVIDADES DE FINANCIACIÓN (Préstamos, Bancos, Deudas LP, Capital, Utilidades)
                if (ContieneAlguna(nombre, "prestamo", "banco", "obligacion", "deuda", "financiera", "amortizacion de deuda","Emision de acciones","pago de bonos","pago de prestamos bancarios",
                                           "capital", "acciones", "social", "utilidades retenidas","Emision de bonos", "capital social","pago de dividendos","Aporte de capital de los socios",
                                           "resultados acumulados", "dividendo"))
                {
                    return CategoriaEfe.Financiacion;
                }

                return CategoriaEfe.NoAfecta;
            }

            // Método auxiliar para buscar si el texto contiene CUALQUIERA de las palabras clave
            private static bool ContieneAlguna(string texto, params string[] palabrasClave)
            {
                foreach (var palabra in palabrasClave)
                {
                    if (texto.Contains(palabra)) return true;
                }
                return false;
            }
        }
    }
}
