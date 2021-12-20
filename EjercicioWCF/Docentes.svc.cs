using EjercicioWCF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EjercicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Docentes" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Docentes.svc o Docentes.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Docentes : IDocentes
    {
        //static List<ModeloDocente> docentes = new List<ModeloDocente>(); //lista estatica
        DocentesBDEntities contexto = new DocentesBDEntities();

        public void ActualizarDocente(Docente docente)
        {
            var docenteExiste = contexto.Docente.Find(docente.Id);
            if(docenteExiste != null) 
            {
                docenteExiste.Apellido = docente.Apellido;
                docenteExiste.Nombre = docente.Nombre;
                docenteExiste.Cedula = docente.Cedula;
                docenteExiste.Experiencia = docente.Experiencia;
                docenteExiste.FechaNacimiento = docente.FechaNacimiento;
                contexto.SaveChanges();
            }
        }

        //public void AgregarDocente(ModeloDocente docente) //Modelo Estatico
        //{
        //    docentes.Add(docente);
        //}

        public void AgregarDocente(Docente docente)
        {
            contexto.Docente.Add(docente);
            contexto.SaveChanges();
        }

        public bool EliminarDocente(string cedula)
        {
            var result = false;
            var docenteEliminar = contexto.Docente.FirstOrDefault(d => d.Cedula.Equals(cedula));
            if(docenteEliminar != null) 
            {
                contexto.Docente.Remove(docenteEliminar);
                contexto.SaveChanges();
                result = true;
            }
            return result;
        }

        //public List<ModeloDocente> ListarDocentes() //Modelo Estatico
        //{
        //    return docentes;
        //}

        List<Docente> IDocentes.ListarDocentes()
        {
            //Linq, linq por extensiones, expresiones lambda
            return contexto.Docente.ToList();
        }
    }
}
