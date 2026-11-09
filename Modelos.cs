using System.Collections.Generic;
using System.Linq;

namespace LookScan
{
    public enum TipoEstado
    {
        BG,
        ER
    }

    public class Cuenta
    {
        public TipoEstado Tipo { get; set; }
        public string Nombre { get; set; }
        public string Clasificacion { get; set; }
        public bool Operativa { get; set; }
        public decimal Monto { get; set; }
    }

    public class Periodo
    {
        public Periodo(string nombre)
        {
            Nombre = nombre;
            Cuentas = new List<Cuenta>();
        }

        public string Nombre { get; private set; }
        public List<Cuenta> Cuentas { get; private set; }

        // Marca los periodos que provienen de una proyección y no de datos reales.
        public bool EsProforma { get; set; }

        public IEnumerable<Cuenta> BG
        {
            get { return Cuentas.Where(c => c.Tipo == TipoEstado.BG); }
        }

        public IEnumerable<Cuenta> ER
        {
            get { return Cuentas.Where(c => c.Tipo == TipoEstado.ER); }
        }

        public bool TieneDatos
        {
            get { return Cuentas.Count > 0; }
        }
    }

    public class FilaComparativa
    {
        public bool Total { get; set; }
        public string Cuenta { get; set; }
        public decimal Base { get; set; }
        public decimal Comparado { get; set; }
        public decimal Delta { get; set; }
        public decimal? Pct { get; set; }
    }

    public class FilaVertical
    {
        public bool Total { get; set; }
        public string Cuenta { get; set; }
        public string Clasificacion { get; set; }
        public decimal Monto { get; set; }
        public decimal? Pct { get; set; }
    }

    public class Razon
    {
        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public string ValorTexto { get; set; }
        public string Interpretacion { get; set; }
    }

    public class FilaEoaf
    {
        public string Cuenta { get; set; }
        public string Clasificacion { get; set; }
        public decimal MontoBase { get; set; }
        public decimal MontoComparado { get; set; }
        public decimal Cambio { get; set; }
        public decimal Origen { get; set; }
        public decimal Aplicacion { get; set; }
    }

    public class ResultadoEoaf
    {
        public ResultadoEoaf()
        {
            Filas = new List<FilaEoaf>();
        }

        public string PeriodoBase { get; set; }
        public string PeriodoComparado { get; set; }
        public List<FilaEoaf> Filas { get; private set; }
        public decimal TotalOrigen { get; set; }
        public decimal TotalAplicacion { get; set; }

        public decimal Diferencia
        {
            get { return TotalOrigen - TotalAplicacion; }
        }
    }

    public class FilaEfe
    {
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public bool Total { get; set; }
        public bool Encabezado { get; set; }
    }

    public class ResultadoEfe
    {
        public ResultadoEfe()
        {
            Filas = new List<FilaEfe>();
        }

        public string PeriodoBase { get; set; }
        public string PeriodoComparado { get; set; }
        public bool MetodoIndirecto { get; set; }
        public List<FilaEfe> Filas { get; private set; }
        public decimal EfectivoInicial { get; set; }
        public decimal EfectivoFinalBalance { get; set; }
        public decimal EfectivoCalculado { get; set; }

        public decimal Diferencia
        {
            get { return EfectivoCalculado - EfectivoFinalBalance; }
        }
    }
}
