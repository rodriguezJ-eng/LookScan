using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace LookScan
{
    // Persistencia local de proyectos en %AppData%\LookScan\proyectos.json.
    // Se usa DataContractJsonSerializer, incluido en .NET Framework, para no
    // depender de paquetes externos.
    public static class Repositorio
    {
        private const string FormatoFecha = "yyyy-MM-dd HH:mm:ss";

        public static string ProyectoActual { get; private set; }

        public static string Carpeta
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "LookScan");
            }
        }

        public static string Ruta
        {
            get { return Path.Combine(Carpeta, "proyectos.json"); }
        }

        public static List<ProyectoDto> Listar()
        {
            ArchivoProyectosDto archivo = Leer();
            return archivo.Proyectos
                .OrderByDescending(p => p.Modificado, StringComparer.Ordinal)
                .ThenBy(p => p.Nombre, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public static ProyectoDto Obtener(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;

            ArchivoProyectosDto archivo = Leer();
            return archivo.Proyectos.FirstOrDefault(p => Util.Igual(p.Nombre, nombre));
        }

        public static bool Existe(string nombre)
        {
            return Obtener(nombre) != null;
        }

        public static void Guardar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new InvalidOperationException("Escriba un nombre para el proyecto.");

            string limpio = nombre.Trim();
            ArchivoProyectosDto archivo = Leer();

            ProyectoDto existente = archivo.Proyectos
                .FirstOrDefault(p => Util.Igual(p.Nombre, limpio));

            if (existente != null)
                archivo.Proyectos.Remove(existente);

            archivo.Proyectos.Add(CrearDto(limpio));
            Escribir(archivo);
            ProyectoActual = limpio;
        }

        public static bool GuardarProyectoActual()
        {
            string nombre = ProyectoActual;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                nombre = string.IsNullOrWhiteSpace(Almacen.Empresa)
                    ? "Proyecto LookScan"
                    : Almacen.Empresa.Trim();
            }

            Guardar(nombre);
            return true;
        }

        public static bool Cargar(string nombre)
        {
            ProyectoDto dto = Obtener(nombre);
            if (dto == null) return false;

            var periodos = new List<Periodo>();

            foreach (PeriodoDto periodoDto in dto.Periodos)
            {
                var periodo = new Periodo(periodoDto.Nombre)
                {
                    EsProforma = periodoDto.EsProforma
                };

                foreach (CuentaDto cuentaDto in periodoDto.Cuentas)
                {
                    periodo.Cuentas.Add(new Cuenta
                    {
                        Tipo = Util.Igual(cuentaDto.Tipo, "ER") ? TipoEstado.ER : TipoEstado.BG,
                        Nombre = cuentaDto.Nombre,
                        Clasificacion = cuentaDto.Clasificacion,
                        Operativa = cuentaDto.Operativa,
                        Monto = cuentaDto.Monto
                    });
                }

                periodos.Add(periodo);
            }

            Almacen.Empresa = dto.Empresa;
            Almacen.ReemplazarPeriodos(periodos);
            ProyectoActual = dto.Nombre;
            return true;
        }

        public static bool Eliminar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return false;

            ArchivoProyectosDto archivo = Leer();
            ProyectoDto existente = archivo.Proyectos
                .FirstOrDefault(p => Util.Igual(p.Nombre, nombre));

            if (existente == null) return false;

            archivo.Proyectos.Remove(existente);
            Escribir(archivo);

            if (Util.Igual(ProyectoActual, nombre))
                ProyectoActual = null;

            return true;
        }

        public static string FormatearFecha(string iso)
        {
            DateTime fecha;

            if (DateTime.TryParseExact(iso, FormatoFecha, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out fecha))
            {
                return fecha.ToString("dd/MM/yyyy HH:mm");
            }

            return iso ?? string.Empty;
        }

        // ── Serialización ────────────────────────────────────────────────────

        private static ProyectoDto CrearDto(string nombre)
        {
            var dto = new ProyectoDto
            {
                Nombre = nombre,
                Empresa = Almacen.Empresa ?? string.Empty,
                Modificado = DateTime.Now.ToString(FormatoFecha, CultureInfo.InvariantCulture)
            };

            foreach (Periodo periodo in Almacen.Periodos)
            {
                var periodoDto = new PeriodoDto
                {
                    Nombre = periodo.Nombre,
                    EsProforma = periodo.EsProforma
                };

                foreach (Cuenta cuenta in periodo.Cuentas)
                {
                    periodoDto.Cuentas.Add(new CuentaDto
                    {
                        Tipo = cuenta.Tipo == TipoEstado.ER ? "ER" : "BG",
                        Nombre = cuenta.Nombre,
                        Clasificacion = cuenta.Clasificacion,
                        Operativa = cuenta.Operativa,
                        Monto = cuenta.Monto
                    });
                }

                dto.Periodos.Add(periodoDto);
            }

            return dto;
        }

        private static ArchivoProyectosDto Leer()
        {
            try
            {
                if (!File.Exists(Ruta)) return new ArchivoProyectosDto();

                using (var flujo = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var serializador = new DataContractJsonSerializer(typeof(ArchivoProyectosDto));
                    var archivo = serializador.ReadObject(flujo) as ArchivoProyectosDto;
                    return archivo ?? new ArchivoProyectosDto();
                }
            }
            catch
            {
                // Si el archivo está corrupto, se empieza con una lista vacía.
                return new ArchivoProyectosDto();
            }
        }

        private static void Escribir(ArchivoProyectosDto archivo)
        {
            Directory.CreateDirectory(Carpeta);

            string temporal = Ruta + ".tmp";

            using (var flujo = new FileStream(temporal, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var serializador = new DataContractJsonSerializer(typeof(ArchivoProyectosDto));
                serializador.WriteObject(flujo, archivo);
            }

            if (File.Exists(Ruta)) File.Delete(Ruta);
            File.Move(temporal, Ruta);
        }
    }

    [DataContract]
    public class ArchivoProyectosDto
    {
        public ArchivoProyectosDto()
        {
            Proyectos = new List<ProyectoDto>();
        }

        [DataMember(Name = "proyectos")]
        public List<ProyectoDto> Proyectos { get; set; }
    }

    [DataContract]
    public class ProyectoDto
    {
        public ProyectoDto()
        {
            Periodos = new List<PeriodoDto>();
        }

        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "empresa")]
        public string Empresa { get; set; }

        [DataMember(Name = "modificado")]
        public string Modificado { get; set; }

        [DataMember(Name = "periodos")]
        public List<PeriodoDto> Periodos { get; set; }
    }

    [DataContract]
    public class PeriodoDto
    {
        public PeriodoDto()
        {
            Cuentas = new List<CuentaDto>();
        }

        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "esProforma")]
        public bool EsProforma { get; set; }

        [DataMember(Name = "cuentas")]
        public List<CuentaDto> Cuentas { get; set; }
    }

    [DataContract]
    public class CuentaDto
    {
        [DataMember(Name = "tipo")]
        public string Tipo { get; set; }

        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "clasificacion")]
        public string Clasificacion { get; set; }

        [DataMember(Name = "operativa")]
        public bool Operativa { get; set; }

        [DataMember(Name = "monto")]
        public decimal Monto { get; set; }
    }
}
