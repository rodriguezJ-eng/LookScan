using System;
using System.Collections.Generic;
using System.Linq;

namespace LookScan
{
    public static class Almacen
    {
        public static readonly List<Periodo> Periodos = new List<Periodo>();
        private static Periodo _activo;

        public static event Action PeriodosCambiaron;
        public static event Action ActivoCambio;
        public static event Action DatosCambiaron;

        static Almacen()
        {
            Periodos.Add(new Periodo("2018"));
            Periodos.Add(new Periodo("2019"));
            Periodos.Add(new Periodo("2020"));
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
            Periodo p2019 = AsegurarPeriodo("2019");
            Periodo p2020 = AsegurarPeriodo("2020");

            // Limpiamos las cuentas de cada periodo sin eliminar el objeto periodo en sí
            p2019.Cuentas.Clear();
            p2020.Cuentas.Clear();

            // Cargamos los datos nominales y específicos para cada año
            CargarPeriodo2019(p2019);
            CargarPeriodo2020(p2020);
           

            Periodo activoDemo = Buscar("2020");
            if (activoDemo != null) _activo = activoDemo;

            Action periodos = PeriodosCambiaron; // Nota que es 'Cambiaron', sin la 'ion' extra
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

        private static void CargarPeriodo2019(Periodo periodo)
        {
            // ACTIVO CORRIENTE
            AgregarBG(periodo, "Efectivo", Clasif.ActivoCorriente, true, 134746547m);
            AgregarBG(periodo, "Cuentas por cobrar", Clasif.ActivoCorriente, true, 1764165735m);
            AgregarBG(periodo, "Otras cuentas por cobrar", Clasif.ActivoCorriente, true, 88728426m);
            AgregarBG(periodo, "CxC instituciones del Estado", Clasif.ActivoCorriente, true, 48587948m);
            AgregarBG(periodo, "Inventarios", Clasif.ActivoCorriente, true, 52990239m);
            AgregarBG(periodo, "Gastos pagados por anticipado", Clasif.ActivoCorriente, true, 57619652m);

            // ACTIVO NO CORRIENTE
            AgregarBG(periodo, "Cuentas por cobrar", Clasif.ActivoNoCorriente, true, 1975123624m);
            AgregarBG(periodo, "Repuestos para plantas", Clasif.ActivoNoCorriente, true, 496816772m);
            AgregarBG(periodo, "Plantas eléctricas e instalaciones", Clasif.ActivoNoCorriente, true, 6953365196m);
            AgregarBG(periodo, "Activos cedidos en administración", Clasif.ActivoNoCorriente, false, 459955842m);
            AgregarBG(periodo, "Otros activos", Clasif.ActivoNoCorriente, false, 1518259757m);

            // PASIVO CORRIENTE
            AgregarBG(periodo, "Préstamos por pagar (Estado)", Clasif.PasivoCorriente, true, 1142242848m);
            AgregarBG(periodo, "Por pagar a CARUNA", Clasif.PasivoCorriente, true, 3663218855m);
            AgregarBG(periodo, "Cuentas por pagar (Estado)", Clasif.PasivoCorriente, true, 3214000412m);
            AgregarBG(periodo, "Proveedores energéticos", Clasif.PasivoCorriente, true, 299454426m);
            AgregarBG(periodo, "Intereses por pagar", Clasif.PasivoCorriente, true, 1508117766m);
            AgregarBG(periodo, "Cuentas por pagar y gastos acumulados", Clasif.PasivoCorriente, true, 1515624652m);

            // PASIVO NO CORRIENTE
            AgregarBG(periodo, "Préstamos por pagar (Estado)", Clasif.PasivoNoCorriente, false, 3448321435m);
            AgregarBG(periodo, "Provisión indemnización laboral", Clasif.PasivoNoCorriente, false, 75846914m);
            AgregarBG(periodo, "Otros pasivos", Clasif.PasivoNoCorriente, false, 1500729095m);

            // PATRIMONIO
            AgregarBG(periodo, "Aporte inicial del Gobierno", Clasif.Patrimonio, true, 687167065m);
            AgregarBG(periodo, "Aporte por alivio de deuda", Clasif.Patrimonio, true, 1163872828m);
            AgregarBG(periodo, "Superávit por revaluación", Clasif.Patrimonio, true, 937135708m);
            AgregarBG(periodo, "Déficit acumulado", Clasif.Patrimonio, true, -5605372266m);


        // Estado de Resultados - 2019
        AgregarER(periodo, "Energía eléctrica plantas generadoras", Clasif.Ventas, true, 1315068057m);
            AgregarER(periodo, "Energía eléctrica domiciliar", Clasif.Ventas, true, 528970058m);
            AgregarER(periodo, "Ingresos por cesión de activos", Clasif.Ventas, true, 63121494m);
            AgregarER(periodo, "Otras facturaciones", Clasif.Ventas, true, 34471570m);
            AgregarER(periodo, "Compra de energía", Clasif.CostoVentas, true, 1590348772m);
            AgregarER(periodo, "Costo de distribución de energía", Clasif.CostoVentas, true, 810085884m);
            AgregarER(periodo, "Gastos de administración", Clasif.GastosOperativos, true, 536589659m);
            AgregarER(periodo, "Otros ingresos operativos", Clasif.OtrosIngresos, true, 60633283m);
            AgregarER(periodo, "Otros gastos", Clasif.GastosOperativos, true, 6927630m);
            AgregarER(periodo, "Ingresos financieros", Clasif.OtrosIngresos, true, 252246639m);
            AgregarER(periodo, "Gastos financieros", Clasif.GastosFinancieros, true, 403070376m);
            AgregarER(periodo, "Pérdida cambiaria, neta", Clasif.GastosFinancieros, true, 471646609m);
        }
        private static void CargarPeriodo2020(Periodo periodo)
        {
            // ACTIVO CORRIENTE
            AgregarBG(periodo, "Efectivo", Clasif.ActivoCorriente, true, 193270338m);
            AgregarBG(periodo, "Cuentas por cobrar", Clasif.ActivoCorriente, true, 2132116765m);
            AgregarBG(periodo, "Otras cuentas por cobrar", Clasif.ActivoCorriente, true, 88352743m);
            AgregarBG(periodo, "CxC instituciones del Estado", Clasif.ActivoCorriente, true, 64174284m);
            AgregarBG(periodo, "Inventarios", Clasif.ActivoCorriente, true, 38012389m);
            AgregarBG(periodo, "Gastos pagados por anticipado", Clasif.ActivoCorriente, true, 4826346m);

            // ACTIVO NO CORRIENTE
            AgregarBG(periodo, "Cuentas por cobrar", Clasif.ActivoNoCorriente, true, 2224225563m);
            AgregarBG(periodo, "Repuestos para plantas", Clasif.ActivoNoCorriente, true, 419557143m);
            AgregarBG(periodo, "Plantas eléctricas e instalaciones", Clasif.ActivoNoCorriente, true, 6926666163m);
            AgregarBG(periodo, "Activos cedidos en administración", Clasif.ActivoNoCorriente, false, 434071699m);
            AgregarBG(periodo, "Otros activos", Clasif.ActivoNoCorriente, false, 1661807163m);

            // PASIVO CORRIENTE
            AgregarBG(periodo, "Préstamos por pagar (Estado)", Clasif.PasivoCorriente, true, 1540062715m);
            AgregarBG(periodo, "Por pagar a CARUNA", Clasif.PasivoCorriente, true, 3770003784m);
            AgregarBG(periodo, "Cuentas por pagar (Estado)", Clasif.PasivoCorriente, true, 3459410222m);
            AgregarBG(periodo, "Proveedores energéticos", Clasif.PasivoCorriente, true, 370343565m);
            AgregarBG(periodo, "Intereses por pagar", Clasif.PasivoCorriente, true, 1994364239m);
            AgregarBG(periodo, "Cuentas por pagar y gastos acumulados", Clasif.PasivoCorriente, true, 1721706432m);

            // PASIVO NO CORRIENTE
            AgregarBG(periodo, "Préstamos por pagar (Estado)", Clasif.PasivoNoCorriente, false, 3241331100m);
            AgregarBG(periodo, "Provisión indemnización laboral", Clasif.PasivoNoCorriente, false, 77180835m);
            AgregarBG(periodo, "Otros pasivos", Clasif.PasivoNoCorriente, false, 1643009248m);

            // PATRIMONIO
            AgregarBG(periodo, "Aporte inicial del Gobierno", Clasif.Patrimonio, true, 687167065m);
            AgregarBG(periodo, "Aporte por alivio de deuda", Clasif.Patrimonio, true, 1163872828m);
            AgregarBG(periodo, "Superávit por revaluación", Clasif.Patrimonio, true, 935313924m);
            AgregarBG(periodo, "Déficit acumulado", Clasif.Patrimonio, true, -6416685361m);

            // Estado de Resultados - 2020
            AgregarER(periodo, "Energía eléctrica plantas generadoras", Clasif.Ventas, true, 3683449619m);
            AgregarER(periodo, "Energía eléctrica domiciliar", Clasif.Ventas, true, 570053034m);
            AgregarER(periodo, "Ingresos por cesión de activos", Clasif.Ventas, true, 54494252m);
            AgregarER(periodo, "Otras facturaciones", Clasif.Ventas, true, 40864044m);
            AgregarER(periodo, "Compra de energía", Clasif.CostoVentas, true, 3281491782m);
            AgregarER(periodo, "Costo de distribución de energía", Clasif.CostoVentas, true, 668267722m);
            AgregarER(periodo, "Gastos de administración", Clasif.GastosOperativos, true, 554126247m);
            AgregarER(periodo, "Otros ingresos operativos", Clasif.OtrosIngresos, true, 6198683m);
            AgregarER(periodo, "Otros gastos", Clasif.GastosOperativos, true, 58133551m);
            AgregarER(periodo, "Ingresos financieros", Clasif.OtrosIngresos, true, 240026724m);
            AgregarER(periodo, "Gastos financieros", Clasif.GastosFinancieros, true, 493983896m);
            AgregarER(periodo, "Pérdida cambiaria, neta", Clasif.GastosFinancieros, true, 350396253m);
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
