using System;
using System.Collections.Generic;

namespace LookScan
{
    // Documento neutral que alimenta la IA, los reportes y todos los formatos
    // de exportación. Las secciones se agregan en el orden solicitado.
    public class DocumentoInforme
    {
        public DocumentoInforme()
        {
            Secciones = new List<SeccionInforme>();
            Graficos = new List<GraficoInforme>();
        }

        public string Titulo { get; set; }
        public string Empresa { get; set; }
        public string Generado { get; set; }
        public string PeriodoActivo { get; set; }
        public List<SeccionInforme> Secciones { get; private set; }
        public List<GraficoInforme> Graficos { get; private set; }

        public GraficoInforme AgregarGrafico(string titulo, params string[] series)
        {
            var grafico = new GraficoInforme(titulo, series);
            Graficos.Add(grafico);
            return grafico;
        }

        public SeccionInforme AgregarSeccion(string titulo)
        {
            var seccion = new SeccionInforme(titulo);
            Secciones.Add(seccion);
            return seccion;
        }
    }

    // Datos neutrales de un gráfico: los exportadores los convierten a SVG/HTML o a hojas de Excel.
    public class GraficoInforme
    {
        public GraficoInforme(string titulo, params string[] series)
        {
            Titulo = titulo;
            Series = new List<string>(series ?? new string[0]);
            Puntos = new List<PuntoGraficoInforme>();
        }

        public string Titulo { get; private set; }
        public List<string> Series { get; private set; }
        public List<PuntoGraficoInforme> Puntos { get; private set; }

        public void AgregarPunto(string etiqueta, params decimal[] valores)
        {
            Puntos.Add(new PuntoGraficoInforme { Etiqueta = etiqueta ?? string.Empty, Valores = new List<decimal>(valores ?? new decimal[0]) });
        }
    }

    public class PuntoGraficoInforme
    {
        public string Etiqueta { get; set; }
        public List<decimal> Valores { get; set; }
    }

    public class SeccionInforme
    {
        public SeccionInforme(string titulo)
        {
            Titulo = titulo;
            Tablas = new List<TablaInforme>();
            Notas = new List<string>();
        }

        public string Titulo { get; private set; }
        public List<TablaInforme> Tablas { get; private set; }
        public List<string> Notas { get; private set; }

        public TablaInforme AgregarTabla(string titulo, params string[] columnas)
        {
            var tabla = new TablaInforme(titulo, columnas);
            Tablas.Add(tabla);
            return tabla;
        }

        public void AgregarNota(string nota)
        {
            if (!string.IsNullOrEmpty(nota)) Notas.Add(nota);
        }
    }

    public class TablaInforme
    {
        public TablaInforme(string titulo, params string[] columnas)
        {
            Titulo = titulo;
            Columnas = new List<string>();
            Filas = new List<FilaInforme>();

            if (columnas != null)
            {
                foreach (string columna in columnas)
                    Columnas.Add(columna);
            }
        }

        public string Titulo { get; private set; }
        public List<string> Columnas { get; private set; }
        public List<FilaInforme> Filas { get; private set; }

        public FilaInforme AgregarFila(params object[] valores)
        {
            var fila = new FilaInforme();

            if (valores != null)
            {
                foreach (object valor in valores)
                    fila.Celdas.Add(CeldaInforme.Convertir(valor));
            }

            Filas.Add(fila);
            return fila;
        }

        public FilaInforme AgregarTotal(params object[] valores)
        {
            FilaInforme fila = AgregarFila(valores);
            fila.Total = true;
            return fila;
        }

        public FilaInforme AgregarEncabezado(string texto)
        {
            var fila = new FilaInforme();
            fila.Celdas.Add(CeldaInforme.DeTexto(texto));
            fila.Encabezado = true;
            Filas.Add(fila);
            return fila;
        }
    }

    public class FilaInforme
    {
        public FilaInforme()
        {
            Celdas = new List<CeldaInforme>();
        }

        public List<CeldaInforme> Celdas { get; private set; }
        public bool Total { get; set; }
        public bool Encabezado { get; set; }
    }

    public class CeldaInforme
    {
        public string Texto { get; set; }
        public decimal? Numero { get; set; }
        public string Formato { get; set; }

        public static CeldaInforme DeTexto(string texto)
        {
            return new CeldaInforme
            {
                Texto = texto ?? string.Empty,
                Numero = null,
                Formato = "texto"
            };
        }

        public static CeldaInforme Monto(decimal valor)
        {
            return new CeldaInforme
            {
                Texto = Util.Monto(valor),
                Numero = valor,
                Formato = "monto"
            };
        }

        public static CeldaInforme Porcentaje(decimal? proporcion)
        {
            return new CeldaInforme
            {
                Texto = Util.Pct(proporcion),
                Numero = proporcion,
                Formato = "porcentaje"
            };
        }

        public static CeldaInforme Veces(decimal? valor)
        {
            return new CeldaInforme
            {
                Texto = Util.Veces(valor),
                Numero = valor,
                Formato = "veces"
            };
        }

        public static CeldaInforme Dias(decimal? valor)
        {
            return new CeldaInforme
            {
                Texto = Util.Dias(valor),
                Numero = valor,
                Formato = "dias"
            };
        }

        public static CeldaInforme NumeroCon(decimal valor, int decimales)
        {
            return new CeldaInforme
            {
                Texto = Util.Numero(valor, decimales),
                Numero = valor,
                Formato = "numero" + decimales.ToString()
            };
        }

        public static CeldaInforme Convertir(object valor)
        {
            if (valor == null) return DeTexto(string.Empty);
            if (valor is CeldaInforme) return (CeldaInforme)valor;
            if (valor is string) return DeTexto((string)valor);
            if (valor is decimal) return Monto((decimal)valor);
            if (valor is bool) return DeTexto((bool)valor ? "Sí" : "No");
            if (valor is DateTime) return DeTexto(((DateTime)valor).ToString("dd/MM/yyyy HH:mm"));

            if (valor is int || valor is long || valor is double || valor is float)
                return Monto(Convert.ToDecimal(valor));

            return DeTexto(valor.ToString());
        }
    }
}
