using Ejercicio_de__Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_de__Prototype.Personas
{
    abstract class Persona : IClonable
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public  int Edad { get; set; }
        public Persona()
        {
         
        }
        public Persona(string nombre, string apellido, int edad, string sexo, string telefono)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Sexo = sexo;
            this.Telefono = telefono;
        }
        public abstract IClonable clonar();

       
    }
}
