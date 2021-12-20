using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioWebService
{
    public class Estudiante
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RH { get; set; }
        public int Semestre { get; set; }
        public string Carrera { get; set; }

        public bool ValidarEstudiante()
        {
            return this.Codigo.Length >= 6 &&
                (this.Semestre >= 1 && this.Semestre <= 10);
        }
    }
}