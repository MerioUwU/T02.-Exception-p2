
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Errores
{
    class Program
    {
        static void Main(string[] args)
        {
            var estudiantes = new List<Estudiante>();//creacion de lista
            var agregar = true;//variable para seguir ciclo
            while (agregar) //while para seguir llenando lista
            {
                try//trycatch para mandar excepcion
                {
                    var e = new Estudiante();//creas tu objeto
                    int nc;//creas variable para atributo
                    Console.WriteLine("Ingrese un numero de control: ");//pides informacion
                    bool result = int.TryParse(Console.ReadLine(), out nc);//creas un bool para identificar cuando se requere excepcion
                    if (result == false)//evaluas cuando fueun dato incorrecto, asi funciona el catch del tryparse
                    {
                        Console.WriteLine("Se han detectado caracteres invalidos en la matricula");//dices que no fue seguro
                        Console.WriteLine("Ingresa la matricula de nuevo (Solo numeros): ");
                        nc=int.Parse(Console.ReadLine());//aqui usamos int.parse para poder acceder al catch en caso de repetir error
                    }
                    e.NControl = nc;//al evadir el error, capturas el dato
                    Console.WriteLine("Ingresar nombre: ");//pides nombre
                    e.Nombre = Console.ReadLine();//capturas y adjuntas nombre al objeto
                    Console.WriteLine("Ingrese el semestre en curso: ");//pides semestre
                    e.Semestre = Console.ReadLine();//capturas y adjuntas semestre al objeto
                    Console.WriteLine("Ingrese la carrera que se esta cursando: ");//pides carrera
                    e.Carrera = Console.ReadLine();//capturas ya djuntas carrera al objeto
                    estudiantes.Add(e);//agregas objeto lleno a la lista
                    Console.WriteLine("Si desea agregar otro presione 1, si desea salir presione 2");//el 1 es el unico que importa, si das 1 agregar se queda en true
                    if (int.Parse(Console.ReadLine()) != 1)//en caso de ser diferente de uno
                    {
                        agregar = false;//haces a agregar false
                    }
                    Console.Clear();//limpias y te vas
                }
                catch(Exception ex)//catch que trabaja con el try en caso de volver a arruinarlo
                {
                    Console.WriteLine("Error: {0}\nProcura usar solo numeros!",ex.Message);//dices que no se pudo capturar al estudiante y dices cual fue el error
                    Console.ReadKey();//mantienes agregar en true
                    Console.Clear();//limpias aqui antes de reiniciar el ciclo
                }
            }
        }
    }
}
//las exccepciones son un elemento super util para delimitar huecos en el programa, evitar que queden vacios o que el usuario salga del codigo
//en momentos donde no es necesario, es decir generar un desarrollo de programas fluidos, si cada que hay algo mal el programa se cirra entonces
//el programa no tiene control de excepciones, lo cual estamos aprendiendo a liberar, a decirle al usuario "si te equivocaste, pero siguele aqui"
//mantener la continuidad y fluidez del programa es comodo y en mi opinion, algo genial, algo que ponia nervioso al inicio, el que el usuario dejara
//elementos vacios y que el programa cierre por esa excepcion, ahora es sencillo de solucionar con cualquiera de las dos versiones, donde el trycatch 
//es el que te dice con ayuda del tipo de dato exception a ver cual fue el error, y el tryparse es el indicador de excepciones mas veloz, el breakpoint 
//es la inversa de estos, interrumpe el programa cuando lo necesitemos y sin necesidad de tener excepciones, para ir leyendo objetos y listas