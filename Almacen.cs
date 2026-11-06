using System;
using System.Collections.Generic;
using System.Linq;

namespace LookScan
{
    public static class Almacen
    {
        private static readonly List<Periodo> Periodos = new List<Periodo>();
        private static Periodo _activo;

        public static event Action PeriodosCambiaron;
        public static event Action ActivoCambio;
        public static event Action DatosCambiaron;

        static Almacen()
        {
            Periodos.Add(new Periodo("2023"));
            Periodos.Add(new Periodo("2024"));
            Periodos.Add(new Periodo("2025"));
            _activo = Periodos[Periodos.Count - 1];
        }

        public static string Empresa { get; set; }

        public static IEnumerable<string> Nombres
        {
            get { return Periodos.Select(p => p.Nombre).ToList(); }
        }

        public static Periodo Activo
        {
            get { return _activo; }
            set
            {
                if (ReferenceEquals(_activo, value)) return;
                _activo = value;

                Action handler = ActivoCambio;
                if (handler != null) handler();
            }
        }

        public static bool HayDatos
        {
            get { return Periodos.Any(p => p.TieneDatos); }
        }

        public static Periodo Buscar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;

            string buscado = nombre.Trim();
            return Periodos.FirstOrDefault(p => Util.Igual(p.Nombre, buscado));
        }

        public static void AgregarPeriodo(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return;

            Periodo existente = Buscar(nombre);
            if (existente != null)
            {
                Activo = existente;
                return;
            }

            var nuevo = new Periodo(nombre.Trim());
            Periodos.Add(nuevo);
            Ordenar();
            _activo = nuevo;

            Action periodos = PeriodosCambiaron;
            if (periodos != null) periodos();

            Action activo = ActivoCambio;
            if (activo != null) activo();
        }

        public static void AgregarCuenta(Periodo periodo, Cuenta cuenta)
        {
            if (periodo == null || cuenta == null) return;

            periodo.Cuentas.Add(cuenta);

            Action handler = DatosCambiaron;
            if (handler != null) handler();
        }

        public static void EliminarCuenta(Periodo periodo, Cuenta cuenta)
        {
            if (periodo == null || cuenta == null) return;
            if (!periodo.Cuentas.Remove(cuenta)) return;

            Action handler = DatosCambiaron;
            if (handler != null) handler();
        }

        public static void CargarDemo()
        {
            Periodo p2023 = AsegurarPeriodo("2023");
            Periodo p2024 = AsegurarPeriodo("2024");
            Periodo p2025 = AsegurarPeriodo("2025");

            p2023.Cuentas.Clear();
            p2024.Cuentas.Clear();
            p2025.Cuentas.Clear();

            CargarDemoPeriodo(p2023, 0.78m, 0.74m);
            CargarDemoPeriodo(p2024, 0.89m, 0.87m);
            CargarDemoPeriodo(p2025, 1.00m, 1.00m);

            Periodo activoDemo = Buscar("2025");
            if (activoDemo != null) _activo = activoDemo;

            Action periodos = PeriodosCambiaron;
            if (periodos != null) periodos();

            Action datos = DatosCambiaron;
            if (datos != null) datos();

            Action activo = ActivoCambio;
            if (activo != null) activo();
        }

        private static Periodo AsegurarPeriodo(string nombre)
        {
            Periodo existente = Buscar(nombre);
            if (existente != null) return existente;

            var nuevo = new Periodo(nombre);
            Periodos.Add(nuevo);
            Ordenar();
            return nuevo;
        }

        private static void Ordenar()
        {
            Periodos.Sort(delegate (Periodo a, Periodo b)
            {
                int numeroA;
                int numeroB;
                bool esNumeroA = int.TryParse(a.Nombre, out numeroA);
                bool esNumeroB = int.TryParse(b.Nombre, out numeroB);

                if (esNumeroA && esNumeroB) return numeroA.CompareTo(numeroB);
                if (esNumeroA) return -1;
                if (esNumeroB) return 1;

                return string.Compare(a.Nombre, b.Nombre, StringComparison.OrdinalIgnoreCase);
            });
        }

        private static void CargarDemoPeriodo(Periodo periodo, decimal factorBG, decimal factorER)
        {
            AgregarBG(periodo, "Efectivo y equivalentes", Clasif.ActivoCorriente, true, 150000m * factorBG);
            AgregarBG(periodo, "Cuentas por cobrar", Clasif.ActivoCorriente, true, 220000m * factorBG);
            AgregarBG(periodo, "Inventarios", Clasif.ActivoCorriente, true, 180000m * factorBG);
            AgregarBG(periodo, "Otros activos corrientes", Clasif.ActivoCorriente, true, 50000m * factorBG);
            AgregarBG(periodo, "Propiedad, planta y equipo", Clasif.ActivoNoCorriente, true, 600000m * factorBG);
            AgregarBG(periodo, "Activos intangibles", Clasif.ActivoNoCorriente, false, 100000m * factorBG);

            AgregarBG(periodo, "Cuentas por pagar", Clasif.PasivoCorriente, true, 170000m * factorBG);
            AgregarBG(periodo, "Obligaciones financieras de corto plazo", Clasif.PasivoCorriente, false, 130000m * factorBG);
            AgregarBG(periodo, "Otros pasivos corrientes", Clasif.PasivoCorriente, true, 50000m * factorBG);
            AgregarBG(periodo, "Deuda de largo plazo", Clasif.PasivoNoCorriente, false, 250000m * factorBG);

            AgregarBG(periodo, "Capital social", Clasif.Patrimonio, false, 500000m * factorBG);
            AgregarBG(periodo, "Utilidades retenidas", Clasif.Patrimonio, false, 200000m * factorBG);

            AgregarER(periodo, "Ventas", Clasif.Ventas, true, 1800000m * factorER);
            AgregarER(periodo, "Costo de ventas", Clasif.CostoVentas, true, 1080000m * factorER);
            AgregarER(periodo, "Gastos operativos", Clasif.GastosOperativos, true, 350000m * factorER);
            AgregarER(periodo, "Gastos financieros", Clasif.OtrosIngresosGastos, true, -30000m * factorER);
            AgregarER(periodo, "Otros ingresos", Clasif.OtrosIngresosGastos, true, 10000m * factorER);
            AgregarER(periodo, "Impuestos", Clasif.Impuestos, true, 105000m * factorER);
        }

        private static void AgregarBG(Periodo periodo, string nombre, string clasificacion,
                                      bool operativa, decimal monto)
        {
            periodo.Cuentas.Add(new Cuenta
            {
                Tipo = TipoEstado.BG,
                Nombre = nombre,
                Clasificacion = clasificacion,
                Operativa = operativa,
                Monto = monto
            });
        }

        private static void AgregarER(Periodo periodo, string nombre, string clasificacion,
                                      bool operativa, decimal monto)
        {
            periodo.Cuentas.Add(new Cuenta
            {
                Tipo = TipoEstado.ER,
                Nombre = nombre,
                Clasificacion = clasificacion,
                Operativa = operativa,
                Monto = monto
            });
        }
    }
}
