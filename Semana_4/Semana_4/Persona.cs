using System;
using System.Collections.Generic;
using System.Linq;

namespace Semana_4
{
    public class Persona
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int cédula { get; set; }
        public string nacionalidad { get; set; }

        public Persona()
        {
        }

        public Persona(string nombre, string apellidos, int cédula, string nacionalidad)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.cédula = cédula;
            this.nacionalidad = nacionalidad;
        }

        public string VerPersona()
        {
            return string.Format("{0} {1} (Cédula: {2}) - {3}", nombre, apellidos, cédula, nacionalidad);
        }
    }

    public class PersonaRepository
    {
        private readonly List<Persona> _personas = new List<Persona>();

        public IReadOnlyList<Persona> Personas => _personas.AsReadOnly();

        public bool TryAdd(string nombre, string apellidos, string cedulaTexto, string nacionalidad, out Persona creada, out string error)
        {
            creada = null;
            error = null;

            string n = (nombre ?? string.Empty).Trim();
            string a = (apellidos ?? string.Empty).Trim();
            string nac = (nacionalidad ?? string.Empty).Trim();

            if (string.IsNullOrEmpty(n))
            {
                error = "Debe ingresar el nombre.";
                return false;
            }

            if (string.IsNullOrEmpty(a))
            {
                error = "Debe ingresar los apellidos.";
                return false;
            }

            int cedula;
            if (!int.TryParse((cedulaTexto ?? string.Empty).Trim(), out cedula) || cedula <= 0)
            {
                error = "La cédula debe ser un número entero positivo.";
                return false;
            }

            if (string.IsNullOrEmpty(nac))
            {
                error = "Debe seleccionar una nacionalidad.";
                return false;
            }

            if (_personas.Any(p => p.cédula == cedula))
            {
                error = string.Format("Ya existe una persona registrada con la cédula {0}.", cedula);
                return false;
            }

            creada = new Persona(n, a, cedula, nac);
            _personas.Add(creada);
            return true;
        }

        public bool Update(int cedula, string nombre, string apellidos, string nacionalidad, out string error)
        {
            error = null;
            Persona existing = _personas.FirstOrDefault(p => p.cédula == cedula);
            if (existing == null)
            {
                error = "No se encontró una persona con esa cédula.";
                return false;
            }

            string n = (nombre ?? string.Empty).Trim();
            string a = (apellidos ?? string.Empty).Trim();
            string nac = (nacionalidad ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(n) || string.IsNullOrEmpty(a) || string.IsNullOrEmpty(nac))
            {
                error = "Nombre, apellidos y nacionalidad son obligatorios.";
                return false;
            }

            existing.nombre = n;
            existing.apellidos = a;
            existing.nacionalidad = nac;
            return true;
        }

        public bool Delete(int cedula)
        {
            int removed = _personas.RemoveAll(p => p.cédula == cedula);
            return removed > 0;
        }

        public IEnumerable<Persona> GetByNationality(bool nacional)
        {
            return _personas.Where(p =>
                string.Equals(p.nacionalidad, "Nacional", StringComparison.OrdinalIgnoreCase) == nacional);
        }
    }
}
