using Ejercicio_de__Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_de__Prototype.Personas
{
    class Padre: Persona
    {
        private Alumno hijo;
        internal Alumno Hijo { get => hijo; set => hijo = value; }

        public Padre()
        {

        }
        public Padre(string nombre, string apellido, int edad, string sexo, string telefono):base(nombre, apellido, edad, sexo, telefono)
        {
            this.Hijo = new Alumno();
        }

        public Padre(string nombre, string apellido, int edad, string sexo, string telefono, Alumno hijo) : base(nombre, apellido, edad, sexo, telefono)
        {
            this.Hijo = hijo;
        }

        

        public override IClonable clonar()
        {
          Padre clon = new Padre(this.Nombre, this.Apellido, this.Edad, this.Sexo,  this.Telefono);
            clon.Hijo = new Alumno();
            return clon;
        }
    }
}
