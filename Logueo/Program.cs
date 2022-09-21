using System;

namespace Logueo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mantenimiento mant = new Mantenimiento();

            Console.WriteLine("¿Desea operar sobre alguna cuenta? S/N");
            string respuesta = Console.ReadLine();
            string respuesta1 = respuesta.ToUpper();
            while (respuesta1 == "S")
            {
                Console.WriteLine("¿Qué desea hacer?\n 1) Ingresar a una cuenta.\n 2) Crear una cuenta.\nMarque el número de la opción deseada:");
                string option = Console.ReadLine();
                Evaluacion ev = new Evaluacion(option);
                int opcion = ev.Mandar();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese nombre de usuario:");
                        string nombre = Console.ReadLine();
                        Usuario user = new Usuario();
                        user = mant.Leer(nombre);
                        string confirm = user.clave;
                        if (confirm != null)
                        {
                            Console.WriteLine("Ingrese la clave:");
                            string clave = Console.ReadLine();
                            int i = 1;
                            while (confirm != clave && i < 3)
                            {                                
                                Console.WriteLine("Clave incorrecta. Reingrese la clave: ");
                                clave = Console.ReadLine();
                                i++;
                            }
                            if (confirm == clave)
                            {
                                Console.WriteLine("Ha accedido a su cuenta.");
                            }
                            else
                            {
                                Console.WriteLine("Se le acabaron los intentos.");
                                respuesta1 = "N";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Usuario inexistente.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Ingrese nombre de usuario:");
                        string nombre2 = Console.ReadLine();                        
                        Usuario user2 = new Usuario();
                        user = mant.Leer(nombre2);
                        string confirm2 = user.nombre;
                        if (confirm2 != null)
                        {
                            Console.WriteLine("Registro ya existente");
                        }
                        else
                        {
                            Console.WriteLine("Ingrese la clave:");
                            string clave2 = Console.ReadLine();
                            Usuario user1 = new Usuario();
                            user1.nombre = nombre2;
                            user1.clave= clave2;
                            mant.Alta(user1);
                        }
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }
                Console.WriteLine("¿Desea operar sobre algún registro? S/N");
                respuesta = Console.ReadLine();
                respuesta1 = respuesta.ToUpper();
            }
            Console.WriteLine("Programa finalizado.");
        }
    }
}
