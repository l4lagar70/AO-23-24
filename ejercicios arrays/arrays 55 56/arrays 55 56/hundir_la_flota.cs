using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace arrays_55_56
{
    internal class hundir_la_flota
    {
       

        //INFORMACION

        //   X = IMPACTO A UN BARCO
        //   * = IMPACTO AL AGUA
        //   O = BARCOS
        //   # = CASILLA OCULTA

        
        // -------------------- FUNCIONES -------------------- FUNCIONES -------------------- FUNCIONES -------------------- FUNCIONES -------------------- 

        //Crear los tableros del jugador 1 y el jugador 2

        static int tamañoTablero = 5;
        static char[,] tableroJugador1 = new char[tamañoTablero, tamañoTablero];
        static char[,] tableroJugador2 = new char[tamañoTablero, tamañoTablero];

        

        //Inicializar el tablero
        static void InicializarTablero(char[,] tablero)
        {
            for (int i = 0; i < tamañoTablero; i++)
            {
                for (int j = 0; j < tamañoTablero; j++)
                {
                    tablero[i, j] = '#'; 
                }
            }
        }

        //Mostrar el tablero
        static void MostrarTablero(char[,] tablero, bool ocultarBarcos)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  | A B C D E");
            Console.WriteLine("--|----------");

            for (int i = 0; i < tamañoTablero; i++)
            {
                Console.Write($"{i + 1} |");

                for (int j = 0; j < tamañoTablero; j++)
                {
                    char contenido = tablero[i, j];
                    if (ocultarBarcos && contenido == 'O') 
                    {
                        contenido = '#';
                    }

                    Console.Write($" {contenido}");
                }

                Console.WriteLine();
                
            }
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine();
        }


        //Colocar los barcos aleatoriamente
        static void ColocarBarcos(char[,] tablero)
        {
            Random random = new Random();

            for (int barco = 0; barco < 3; barco++) 
            {
                int fila, columna;


                do
                {
                    fila = random.Next(tamañoTablero);
                    columna = random.Next(tamañoTablero);
                } while (tablero[fila, columna] == 'O'); 

                tablero[fila, columna] = 'O'; 
            }
        }


        //ATACAR
        static void RealizarAtaque(char[,] tablero)
        {
            bool ataqueValido = false;

            while (!ataqueValido)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Introduzca coordenada del ataque (A1): ");
                Console.ForegroundColor = ConsoleColor.White;
                string coordenada = Console.ReadLine().ToUpper();
                Console.WriteLine();
                if (coordenada.Length == 2 && char.IsLetter(coordenada[0]) && char.IsDigit(coordenada[1]))
                {
                    int fila = coordenada[1] - '1';
                    int columna = coordenada[0] - 'A';

                    if (fila >= 0 && fila < tamañoTablero && columna >= 0 && columna < tamañoTablero)
                    {
                        if (tablero[fila, columna] == 'O')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Impacto!");
                            tablero[fila, columna] = 'X'; 
                        }
                        else if (tablero[fila, columna] == '#')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Agua.");
                            tablero[fila, columna] = '*'; 
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ya has atacado esta posición.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                        }

                        ataqueValido = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Coordenada fuera de rango");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada no válida. Inténtalo de nuevo.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
            }
            Thread.Sleep(3000);
            
        }

        //Comprueba si todos los barcos se han undido
        static bool JuegoTerminado(char[,] tablero)
        {
            foreach (char c in tablero)
            {
                if (c == 'O')
                {
                    return false; 
                }
            }

            return true; 
        }


        // ------------------- PROGRAMA  ------------------- PROGRAMA  ------------------- PROGRAMA  ------------------- PROGRAMA  -------------------
        static void Main()
        {
            InicializarTablero(tableroJugador1);
            InicializarTablero(tableroJugador2);

            ColocarBarcos(tableroJugador1);
            ColocarBarcos(tableroJugador2);

            bool juegoTerminado = false;

            while (!juegoTerminado)
            {
                Console.Clear();
                MostrarTablero(tableroJugador1, true);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Turno del jugador 1");
                Console.ForegroundColor = ConsoleColor.White;
                RealizarAtaque(tableroJugador2);

                Console.Clear();
                MostrarTablero(tableroJugador2, false);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Turno del jugador 2");
                Console.ForegroundColor = ConsoleColor.White;
                RealizarAtaque(tableroJugador1);

                juegoTerminado = JuegoTerminado(tableroJugador1) || JuegoTerminado(tableroJugador2);
            }

            Console.WriteLine("¡Juego terminado!");
        }


    }
}
