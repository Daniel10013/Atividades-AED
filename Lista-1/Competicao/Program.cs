using System;

class Program
{
    static void Main()
    {
        for (;;)
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            if (N == 0 && M == 0)
                break;

            int[,] solutions = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                input = Console.ReadLine().Split();
                for (int j = 0; j < M; j++)
                {
                    solutions[i, j] = int.Parse(input[j]);
                }
            }

            bool characteristic1 = true;
            bool characteristic2 = true;
            bool characteristic3 = true;
            bool characteristic4 = true;

            for (int i = 0; i < N; i++)
            {
                bool solvedAll = true;
                for (int j = 0; j < M; j++)
                {
                    if (solutions[i, j] == 0)
                    {
                        solvedAll = false;
                        break;
                    }
                }
                if (solvedAll)
                {
                    characteristic1 = false;
                    break;
                }
            }

            for (int j = 0; j < M; j++)
            {
                bool solvedBySomeone = false;
                for (int i = 0; i < N; i++)
                {
                    if (solutions[i, j] == 1)
                    {
                        solvedBySomeone = true;
                        break;
                    }
                }
                if (!solvedBySomeone)
                {
                    characteristic2 = false;
                    break;
                }
            }

            for (int j = 0; j < M; j++)
            {
                bool solvedByAll = true;
                for (int i = 0; i < N; i++)
                {
                    if (solutions[i, j] == 0)
                    {
                        solvedByAll = false;
                        break;
                    }
                }
                if (solvedByAll)
                {
                    characteristic3 = false;
                    break;
                }
            }

            for (int i = 0; i < N; i++)
            {
                bool solvedAtLeastOne = false;
                for (int j = 0; j < M; j++)
                {
                    if (solutions[i, j] == 1)
                    {
                        solvedAtLeastOne = true;
                        break;
                    }
                }
                if (!solvedAtLeastOne)
                {
                    characteristic4 = false;
                    break;
                }
            }

            int count = 0;
            if (characteristic1) count++;
            if (characteristic2) count++;
            if (characteristic3) count++;
            if (characteristic4) count++;

            Console.WriteLine(count);
        }
    }
}
