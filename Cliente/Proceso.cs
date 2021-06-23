using Ejercicio_de__Prototype.Personas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_de__Prototype.Cliente
{
    class Proceso
    {
        private IO pantalla = IO.getIO();
        public enum Personas
        {
            PADRE = 1,
            ALUMNO = 2
        }

        public void saludar()
        {
            this.pantalla.emitir("Bienbenido");
        } 
       
        public void asignarValoresBase(Persona persona)
        {
            persona.Nombre = this.pantalla.preguntar("indique el numbre del " + persona.GetType().Name);
            persona.Apellido = this.pantalla.preguntar("Bien, ¿Cual es el apellido de " + persona.Nombre + "?");
            persona.Sexo = this.pantalla.preguntar("Por favor indica el sexo de " + persona.Nombre + " " + persona.Apellido + " (M ó F)");
            persona.Edad = int.Parse( this.pantalla.preguntar("¿Cual es la edad  de " + persona.Nombre + " " + persona.Apellido + "?"));
            persona.Telefono= this.pantalla.preguntar("Ahora indica el teléfono de " + persona.Nombre + " " + persona.Apellido);  
        }


        public void asignarHijo(Padre padre)
        {
            this.pantalla.emitir(" ");
            this.pantalla.emitir("Asignemos un hijo a " + padre.Nombre + " " + padre.Apellido);
            this.pantalla.emitir(" ");
            padre.Hijo.Nombre = this.pantalla.preguntar("indique el numbre del hijo de " + padre.Nombre + "?");
            padre.Hijo.Apellido = (padre.Sexo=="M") ?   padre.Apellido: this.pantalla.preguntar("Bien, ¿Cual es el apellido de " + padre.Hijo.Nombre + "?");
            padre.Hijo.Sexo = this.pantalla.preguntar("Por favor indica el sexo de " + padre.Hijo.Nombre + " " + padre.Hijo.Apellido).ToUpper();
            padre.Hijo.Edad = int.Parse(this.pantalla.preguntar("¿Cual es la edad  de " + padre.Hijo.Nombre + " " + padre.Hijo.Apellido + "?"));
            padre.Hijo.Telefono = padre.Telefono;
        }


        public Persona CrearPersona(Personas tipoDePersona)
        {
            string Nombre = this.pantalla.preguntar("Por favor indique el nombre");
            string Apellido = this.pantalla.preguntar("Bien, ¿Cual es el apellido de " + Nombre + "?");
            int Edad = int.Parse(this.pantalla.preguntar("¿Cual es la edad  de " + Nombre + " " + Apellido + "?"));
            string Sexo = this.pantalla.preguntar("Por favor indica el sexo de " + Nombre + " " + Apellido + " (M ó F)");
            string Telefono = this.pantalla.preguntar("Ahora indica el teléfono de " + Nombre + " " + Apellido);
            if (tipoDePersona == Personas.ALUMNO)
            {

                return new Alumno(Nombre, Apellido, Edad, Sexo.ToUpper(), Telefono);

            }
            else
            {
                Padre padre= new Padre(Nombre, Apellido, Edad, Sexo.ToUpper(), Telefono);
                this.asignarHijo(padre);
                return padre;

            }

        }


        public Persona clonarPersona(Persona Original)
        {

            if (Original.GetType().Name == "Padre") {
                Padre clon = (Padre)Original.clonar();
                this.asignarValoresBase(clon);
                this.asignarHijo(clon);// el hijo viene vacio desde el metofo clonar. solo hay que asignar los valores
                return clon;
            }
            else
            {
                Alumno clon = (Alumno)Original.clonar();
                this.asignarValoresBase(clon);
                return clon;
            }
           
            
        }


    }
}
