using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace arrays_55_56
{
    internal class Program
    {
        static int[,] a55 = new int[5, 5];
        static void Main(string[] args)
        {
            // ------------ EJERCICIO 55 ------------
            // ------------ EJERCICIO 55 ------------
            // ------------ EJERCICIO 55 ------------
            // ------------ EJERCICIO 55 ------------

            //matriz aqui
            
            char[,] a55Cop = new char[5, 5]; 
            //random aqui
            Random random = new Random();

            //rellenar toda la matriz de numeros aleatorios
            int nRandom;
            for (int y = 0; y < a55.GetLength(1); y++)
            {
                for (int x = 0; x < a55.GetLength(0); x++)
                {
                    //valor random
                    nRandom = random.Next(1, 9);

                    //valor al array
                    a55[y,x] = nRandom;
                }
            }

            //Relleno matriz2 
            for (int y = 0; y < a55Cop.GetLength(1); y++)
            {
                for (int x = 0; x < a55Cop.GetLength(0); x++)
                {
                    a55Cop[y, x] = '#';
                }
            }

            //generacion de los ceros

            int randomX, randomY;
            for (int i = 0;  i < 3; i++)
            {
                //generar los randoms
                randomX = random.Next(0, a55.GetLength(0));
                randomY = random.Next(0, a55.GetLength(1));

                //valor al array
                a55[randomX, randomY] = 0;
            }



            
            



            //bucle para los 6 intentos y el resto del ejercicio
            int contIntentos = 6;
            int columna = 0; int fila = 0;
            bool rangoCorrecto = false;
            int contIncorrectos = 0;
            int contDe0 = 0;
            for (int i = 0; i < 6;)
            {
                mostrarTodo(a55Cop);
                
                // PREGUNTA COLUMNAS
                do
                {
                    if (contIncorrectos > 0)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Valor fuera de rango");
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Introduzca la columna (0 - 4) (Eje X)");
                    Console.ForegroundColor = ConsoleColor.White;
                    columna = int.Parse(Console.ReadLine());

                    if (columna < 5 && columna >= 0)
                    {
                        rangoCorrecto = true;
                    }
                    else
                    {
                        contIncorrectos++;
                    }

                } while (rangoCorrecto == false);
                rangoCorrecto = false;
                contIncorrectos = 0;
                Console.WriteLine();

                // PREGUNTA FILAS
                do
                {
                    if (contIncorrectos > 0)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Valor fuera de rango");
                        Console.WriteLine() ;
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Introduzca la fila (0 - 4) (Eje Y)");
                    Console.ForegroundColor = ConsoleColor.White;
                    fila = int.Parse(Console.ReadLine());

                    if (fila < 5 && fila >= 0)
                    {
                        rangoCorrecto = true;
                    }
                    else
                    {
                        contIncorrectos++;
                    }

                } while (rangoCorrecto == false);
                rangoCorrecto = false;
                contIncorrectos = 0;
                Console.WriteLine();

                //COMPROBAR SI ES 0
                if (a55[fila,columna] == 0)
                {
                    
                    contDe0++;
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("ENHORABUENA! has encontrado " + contDe0 + " de 3 ceros");
                    if (contDe0 != 3)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Te quedan " + contIntentos + " intentos");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Has encontrado todos los ceros!");
                        break;
                    }
                    a55Cop[fila,columna] = 'o';

                }
                else if (a55[fila, columna] != 100)
                {
                    contIntentos--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Esta posicion no es un 0, es un " + a55[fila, columna]);
                    i++;
                    a55Cop[fila,columna] = 'x';
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Te quedan " + contIntentos + " intentos");
                    
                }
                
                //COMPROBAR SI YA SE HA PROBADO
                if (a55[fila,columna] == 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ya has probado este numero.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Te quedan " + contIntentos + " intentos");
                }
                

                a55[fila, columna] = 100;

                Thread.Sleep(5000);
                Console.Clear();
            }













            Console.ReadLine();
        }



        static void mostrarTodo(char[,] a55Cop)
        {

            // MOSTRAR LA MATRIZ ---------------------------------------------

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    X     COLUMNAS");
            Console.WriteLine("--|---|------------------");
            Console.WriteLine("Y |   |  0  1  2  3  4 ");
            Console.WriteLine("--|---|------------------");
            Console.ForegroundColor = ConsoleColor.White;

            int contTabla = 0;
            for (int y = 0; y < a55.GetLength(1); y++)
            {
                if (contTabla == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("F | 0 |  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (contTabla == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("I | 1 |  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (contTabla == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("L | 2 |  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (contTabla == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("A | 3 |  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (contTabla == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("S | 4 |  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                contTabla++;

                for (int x = 0; x < a55.GetLength(0); x++)
                {
                    if (a55[y, x] == 0)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(a55Cop[y, x] + "  ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(a55Cop[y, x] + "  ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // MOSTRAR LA MATRIZ ---------------------------------------------

        }

    }
}
