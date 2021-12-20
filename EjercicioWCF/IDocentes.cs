using EjercicioWCF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EjercicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IDocentes" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IDocentes
    {
        [OperationContract]
        //void AgregarDocente(ModeloDocente docente); //Modelo Estatico
        void AgregarDocente(Docente docente);
        [OperationContract]
       // List<ModeloDocente> ListarDocentes(); //Modelo Estatico
        List<Docente> ListarDocentes();
        [OperationContract]
        void ActualizarDocente(Docente docente);
        [OperationContract]
        bool EliminarDocente(String cedula);
    }
}
