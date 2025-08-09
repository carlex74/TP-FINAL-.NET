using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Abstract Class Persona
    /// Usado como base para Alumnos, Docentes, Usuarios
    /// </summary>
    abstract class Persona
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public int Legajo { get; set; }
        public string Direccion {  get; set; }


        public Persona() { 
        
        }



    }
}
