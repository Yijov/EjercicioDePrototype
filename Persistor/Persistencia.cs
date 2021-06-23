using Ejercicio_de__Prototype.Personas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Ejercicio_de__Prototype.Persistor
{
    class Persistencia
    {
        

        private static Persistencia Instancia;
        private StreamWriter sw;
        private string path = @"..\..\..\Persistor\test.txt";
        private Persistencia()
        {
        
            

        }

        public static Persistencia getPersistencia() {
            if(Instancia== null)
            {
                Instancia = new Persistencia();
            }
            return Instancia;
        }
       public async Task guardar (Alumno persona)
        {

            string[] lineas =
              {
                "Tipo: " + persona.GetType().Name,
                "Nombre: " + persona.Nombre,
                "Apellido: " + persona.Apellido,
                "Edad: " + persona.Edad,
                "Sexo: " + persona.Sexo,
                "Teléfono: " + persona.Telefono
              };
           

            await Persistir(lineas);

        }

        public async Task guardar(Padre persona)
        {

            string[] lineas =
            {
                "Tipo: " + persona.GetType().Name,
                "Nombre: " + persona.Nombre,
                "Apellido: " + persona.Apellido,
                "Edad: " + persona.Edad,
                "Sexo: " + persona.Sexo,
                "Teléfono: " + persona.Telefono,
                "Hijo: " + persona.Hijo.Nombre + " " +  persona.Hijo.Apellido
              };
            await Persistir(lineas);

        }

        private async Task Persistir(string[] lineas)
        {
            using (this.sw = new StreamWriter(this.path, true))
            {

                await this.sw.WriteLineAsync("******************************");
                foreach (string linea in lineas)
                 {

                    await this.sw.WriteLineAsync(linea);
                 }
            }
        } 


    }
}
