using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_de__Prototype.Cliente
{
    class IO//input output. Permite establecer dialogos con el cliente
    {
        private static IO instancia;
        private IO(){}
        public static IO getIO()
        {
            if(instancia== null)
            {
                instancia = new IO();
            }
            return instancia;
        }

        public string preguntar( string mensaje)
        {   Console.WriteLine(mensaje);
            return Console.ReadLine();
        }
        public void emitir(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
