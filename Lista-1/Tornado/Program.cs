using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            int N = int.Parse(Console.ReadLine());
            if (N == 0) break;

            int[] estados = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int postesDeMadeira = 0;
            int distancia = 0;
            bool dentroDaLacuna = false;

            for (int i = 0; i < N; i++)
            {
                if (estados[i] == 1)
                {
                    if (dentroDaLacuna)
                    {
                        if (distancia > 4)
                        {
                            postesDeMadeira++;
                        }
                        distancia = 0;
                        dentroDaLacuna = false;
                    }
                }
                else
                {
                    if (!dentroDaLacuna)
                    {
                        dentroDaLacuna = true;
                    }
                    distancia++;
                }
            }

            if (dentroDaLacuna)
            {
                if (distancia > 4)
                {
                    postesDeMadeira++;
                }
            }

            int distanciaCircular = 0;
            int iCircular = 0;
            while (iCircular < N && estados[iCircular] == 0)
            {
                distanciaCircular++;
                iCircular++;
            }
            if (distanciaCircular > 0 && distanciaCircular + distancia > 4)
            {
                postesDeMadeira++;
            }

            Console.WriteLine(postesDeMadeira);
        }
    }
}
