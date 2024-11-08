using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] bemComportadas = new string[n];
        string[] malComportadas = new string[n];
        int countBem = 0;
        int countMal = 0;

        for (int i = 0; i < n; i++)
        {
            string entrada = Console.ReadLine();
            char comportamento = entrada[0];
            string nome = entrada.Substring(2);

            if (comportamento == '+')
            {
                bemComportadas[countBem++] = nome;
            }
            else if (comportamento == '-')
            {
                malComportadas[countMal++] = nome;
            }
        }

        Array.Resize(ref bemComportadas, countBem);
        Array.Resize(ref malComportadas, countMal);

        Ordenar(bemComportadas);
        Ordenar(malComportadas);

        foreach (var nome in bemComportadas)
        {
            Console.WriteLine(nome);
        }

        foreach (var nome in malComportadas)
        {
            Console.WriteLine(nome);
        }

        Console.WriteLine($"Se comportaram: {countBem} | Nao se comportaram: {countMal}");
    }

    static void Ordenar(string[] lista)
    {
        for (int i = 0; i < lista.Length - 1; i++)
        {
            for (int j = 0; j < lista.Length - 1 - i; j++)
            {
                if (string.Compare(lista[j], lista[j + 1], StringComparison.Ordinal) > 0)
                {
                    string temp = lista[j];
                    lista[j] = lista[j + 1];
                    lista[j + 1] = temp;
                }
            }
        }
    }
}
