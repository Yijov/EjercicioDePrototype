using Ejercicio_de__Prototype.Persistor;
using Ejercicio_de__Prototype.Personas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_de__Prototype.Cliente
{
    class CodigoCliente
    {

        Proceso proceso = new Proceso();
        private IO pantalla = IO.getIO();
        private Persistencia DB = Persistencia.getPersistencia();
        public CodigoCliente()
        {
            proceso.saludar();


            //Originales
            pantalla.emitir("Para iniciar, Creemos nuestro primer padre");
            Padre primerPadre = (Padre)proceso.CrearPersona(Proceso.Personas.PADRE);

             separador();

            pantalla.emitir("Bien, Creemos nuestro primer Alumno de forma independiente");
            Alumno primerAlumno = (Alumno)proceso.CrearPersona(Proceso.Personas.ALUMNO);

            separador();

            
            //clones del alumno
            pantalla.emitir("Bien, Ahora vamos con los clones");
            pantalla.emitir("Iniciemos con los 3  clones de "+ primerAlumno.Nombre);

            espacio();
            this.pantalla.emitir("Primer Clon");
            Alumno primerClonAlumno= (Alumno)proceso.clonarPersona(primerAlumno);

            espacio();
            this.pantalla.emitir("Segundo Clon");
            Alumno segundoClonAlumno = (Alumno)proceso.clonarPersona(primerAlumno);

            espacio();
            this.pantalla.emitir("Tercer Clon");
            Alumno tercerClonAlumno = (Alumno)proceso.clonarPersona(primerAlumno);
           
            separador();


            //clones del Padre
            pantalla.emitir("Ahora haremos los 3  clones de " + primerPadre.Nombre);
            espacio();
            this.pantalla.emitir("Primer Clon");
            Padre primerClonPadre = (Padre)proceso.clonarPersona(primerPadre);

            espacio();
            this.pantalla.emitir("Segundo Clon");
            Padre segundoClonPadre = (Padre)proceso.clonarPersona(primerPadre);

            espacio();
            this.pantalla.emitir("Tercer Clon");
            Padre tercerClonPadre = (Padre)proceso.clonarPersona(primerPadre);

            separador();
            Persona [] personas = { primerPadre, primerClonPadre, segundoClonPadre, primerAlumno, tercerClonPadre, primerClonAlumno, segundoClonAlumno, tercerClonAlumno};
             aplicarPersistencia(personas); 
           
            aplicarPersistencia(personas); 
           
            Console.ReadKey();
        }







        public void separador()
        {
            pantalla.emitir("------------------------------------------------");
            pantalla.emitir(" ");
        }
         
        public void espacio()
        {
          this.pantalla.emitir(" ");
        }

        public async void aplicarPersistencia(Persona[] personas)
        {
            string confirmacion = pantalla.preguntar("¿Desea guardar la información? (si/ no)");
            Console.WriteLine(confirmacion.ToUpper());
            if (confirmacion.ToUpper() == "SI")
            {
                
                foreach (Persona persona in personas)
                {
                    if (persona.GetType().Name == "Alumno")
                    {
                        Alumno aPersistir = (Alumno)persona;
                        await DB.guardar(aPersistir);
                    }
                    else
                    {
                        Padre aPersistir = (Padre)persona;
                        await DB.guardar(aPersistir);
                    }
                    

                }
            }
            else if (confirmacion != "NO")
            {
                pantalla.emitir(" Seleccione una Opcion Valida");
                aplicarPersistencia(personas);
            }
        }
    }
}
