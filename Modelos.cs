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
}
