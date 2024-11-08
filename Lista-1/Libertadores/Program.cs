using System;

class Program
{
    static void Main(){
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++){
            string[] partida1 = Console.ReadLine().Split('x');
            int time1part1 = int.Parse(partida1[0].Trim()); 
            int time2part1 = int.Parse(partida1[1].Trim());

            string[] partida2 = Console.ReadLine().Split('x');
            int time2part2 = int.Parse(partida2[0].Trim());
            int time1part2 = int.Parse(partida2[1].Trim());

            int time1 = 0, time2 = 0;

            if (time1part1 > time2part1)
                time1 += 3; 
            else if (time1part1 < time2part1)
                time2 += 3; 
            else{
                time1 += 1; 
                time2 += 1;
            }

            if (time2part2 > time1part2)
                time2 += 3; 
            else if (time2part2 < time1part2)
                time1 += 3; 
            else{
                time1 += 1;
                time2 += 1;
            }


            if (time1 > time2){
                Console.WriteLine("Time 1");
            }
            else if (time2 > time1){
                Console.WriteLine("Time 2");
            }
            else{
                int total1 = (time1part1 + time1part2) - (time2part1 + time2part2);
                int total2 = (time2part1 + time2part2) - (time1part1 + time1part2);

                if (total1 > total2){
                    Console.WriteLine("Time 1");
                }
                else if (total2 > total1){
                    Console.WriteLine("Time 2");
                }
                else{
                    int fora1 = time1part2;
                    int fora2 = time2part1; 

                    if (fora1 > fora2){
                        Console.WriteLine("Time 1");
                    }
                    else if (fora2 > fora1){
                        Console.WriteLine("Time 2");
                    }
                    else{

                        Console.WriteLine("Penaltis");
                    }
                }
            }
        }
    }
}