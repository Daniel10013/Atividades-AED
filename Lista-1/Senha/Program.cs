using System;

class Program {
    public static void Main()
    {
        int caso = 1;
        int n;

        do
        {
            n = int.Parse(Console.ReadLine());

            if (n == 0)
                break;

            double[] oleosidade = new double[10];
            string[] entrada = Console.ReadLine().Split(' ');

            for (int i = 0; i < 10; i++)
            {
                oleosidade[i] = double.Parse(entrada[i]);
            }

            int[] digitos = new int[10];
            for (int i = 0; i < 10; i++)
            {
                digitos[i] = i;
            }

            for (int i = 0; i < 10 - 1; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    if (oleosidade[digitos[j]] > oleosidade[digitos[i]] || 
                        (oleosidade[digitos[j]] == oleosidade[digitos[i]] && digitos[j] < digitos[i]))
                    {
                        int temp = digitos[i];
                        digitos[i] = digitos[j];
                        digitos[j] = temp;
                    }
                }
            }

            string senha = "";
            for (int i = 0; i < n; i++)
            {
                senha += digitos[i];
            }

            Console.WriteLine($"Caso {caso}: {senha}");
            caso++;
        } while (n != 0);
    }
  }