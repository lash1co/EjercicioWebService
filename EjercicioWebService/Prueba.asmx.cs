using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EjercicioWebService
{
    /// <summary>
    /// Descripción breve de Prueba
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Prueba : System.Web.Services.WebService
    {
        static List<Estudiante> estudiantes = new List<Estudiante>();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public int Sumar(int num1, int num2) 
        {
            return num1 + num2;
        }

        [WebMethod]
        public Estudiante CrearEstudiante(Estudiante estudiante) 
        {
            //if (ValidarEstudiante(estudiante))
            //    return estudiante;
            //else
            //    return null;
            //return ValidarEstudiante(estudiante) ? estudiante : null;
            //return estudiante.ValidarEstudiante() ? estudiante : null;
            if (estudiante.ValidarEstudiante())
                estudiantes.Add(estudiante);
            return estudiante;
        }

        [WebMethod]
        public List<Estudiante> ListarEstudiantes() 
        {
            return estudiantes;
        }
       
    }
}
