using Ejercicio_de__Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_de__Prototype.Personas
{
    class Alumno : Persona
    {
        public Alumno()
        {

        }
        public Alumno(string nombre, string apellido, int edad, string sexo, string telefono) : base(nombre, apellido, edad, sexo, telefono)
        {
           
        }

        public override IClonable clonar()
        {
            return (Alumno)MemberwiseClone();
        }
    }
}
