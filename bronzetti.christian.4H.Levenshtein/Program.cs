using System;

namespace bronzetti.christian._4H.Levenshtein
{
    class Program
    {
        //riempoi la prima riga e la prima colonna
        static int [,] PopolaMatrice(int [,] matrice, int n, int m)
        {
            //riempio prima colonna
            for (int i = 0; i < n+1; i++)
                matrice[0, i] = i;

            //riempio prima riga
            for (int j = 0; j < m+1; j++)
                matrice[j, 0] = j;

            return matrice;
        }

        static int TrovaValoreMinimo(int x, int y, int z)
        {
            int min = x;

            if (y < min)
                min = y;

            if (z < min)
                min = z;

            return min;
        }
        static int CalcolaDL(string parola1, string parola2)
        {
            int n = parola1.Length;
            int m = parola2.Length;

            if (n == 0)
                return m;

            if (m == 0)
                return n;

            int[,] matriceSalvataggi = new int[m + 1, n + 1];

            matriceSalvataggi = PopolaMatrice(matriceSalvataggi, n, m);
           
            //ciclo controllo
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    int costo = (parola2[j] == parola1[i]) ? 0 : 1;
                   

                    matriceSalvataggi[j + 1, i + 1] = TrovaValoreMinimo
                                                      (
                                                        matriceSalvataggi[j + 1, i] + 1, 
                                                        matriceSalvataggi[j, i + 1] + 1,
                                                        matriceSalvataggi[j, i] + costo
                                                       );
                }

            }

            return matriceSalvataggi[m, n];
        }
        static void Main(string[] args)
        {
            string parola1 = "saturday";
            string parola2 = "sunday";
            Console.WriteLine(CalcolaDL(parola1, parola2));
        }
    }
}
