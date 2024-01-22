using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_55_56
{
    internal class FuncFlota
    {
        public void InicializarTablero(char[,] tablero)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tablero[i, j] = '#'; 
                }
            }
        }
    }
}
