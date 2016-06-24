using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_4
{
    class Persona
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
            string resultado = "";

            resultado = nombre + " " + apellidos + "\n" + cédula + "\n" + nacionalidad;

            return resultado; 
        }
    }
}
