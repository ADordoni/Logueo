using System;
using System.Collections.Generic;
using System.Text;

namespace Logueo
{
    internal class Evaluacion
    {
        int opcion;
        public Evaluacion (string option)
        {
            try
            {
                opcion = int.Parse(option);
            }
            catch (FormatException)
            {                
                opcion = 0;
            }            
        }
        public int Mandar()
        {
            return opcion;
        }
    }
}
