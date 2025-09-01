using System;
using System.Collections.Generic;

namespace assignment2
{
    internal class Program
    {
        private List<Colony.Prey> preys;
        private List<Colony.Predators> predators;

        static void Main()
        {
            new Program().RunSimulation();
        }

        private void RunSimulation()
        {
            string[] lines = System.IO.File.ReadAllLines("input.txt");
            string[] counts = lines[0].Split(' ');
            int preycnt = int.Parse(counts[0]);
            int predatorcnt = int.Parse(counts[1]);

            preys = new List<Colony.Prey>();
            predators = new List<Colony.Predators>();

            int lineIndex = 1;
            for (int i = 0; i < preycnt; i++)
            {
                string[] parts = lines[lineIndex++].Split(' ');
                string name = parts[0];
                char ch = parts[1][0];

                switch (ch)
                {
                    case 'l':
                        preys.Add(new Colony.Lemming(name, int.Parse(parts[2])));
                        break;
                    case 'h':
                        preys.Add(new Colony.Hare(name, int.Parse(parts[2])));
                        break;
                    case 'g':
                        preys.Add(new Colony.Gopher(name, int.Parse(parts[2])));
                        break;
                }
            }

            for (int i = 0; i < predatorcnt; i++)
            {
                string[] parts = lines[lineIndex++].Split(' ');
                string name = parts[0];
                char ch = parts[1][0];

                switch (ch)
                {
                    case 'o':
                        predators.Add(new Colony.SnowyOwl(name, int.Parse(parts[2])));
                        break;
                    case 'f':
                        predators.Add(new Colony.ArcticFox(name, int.Parse(parts[2])));
                        break;
                    case 'w':
                        predators.Add(new Colony.Wolf(name, int.Parse(parts[2])));
                        break;
                }
            }

            simulate();
        }

        private void simulate()
        {
            bool isExtinct = false;
            bool isQuadrupled = false;
            int daycnt = 1;
            int[] startCount = new int[preys.Count];

            for (int i = 0; i < preys.Count; i++)
            {
                startCount[i] = preys[i].getCount();
            }

            while (!isExtinct && !isQuadrupled)
            {
                Console.WriteLine("Day: " + daycnt);

                Console.WriteLine("Predators:");
                for (int j = 0; j < predators.Count; j++)
                {
                    predators[j].Attack(preys);
                    Console.WriteLine(predators[j].ToString());
                }

                Console.WriteLine("Preys:");
                for (int i = 0; i < preys.Count; i++)
                {
                    preys[i].Turn();
                    Console.WriteLine(preys[i].ToString());

                    if (preys[i].getCount() <= 0)
                    {
                        Console.WriteLine(preys[i].name + " is extinct");
                        isExtinct = true;
                    }

                    if (preys[i].getCount() >= 4 * startCount[i])
                    {
                        Console.WriteLine(preys[i].name + " population has been quadrupled");
                        isQuadrupled = true;
                    }
                }

                if (isExtinct || isQuadrupled) break;

                daycnt++;
            }

            if (isExtinct)
            {
                Console.WriteLine("Simulation ended due to extinction.");
            }
            else if (isQuadrupled)
            {
                Console.WriteLine("Simulation ended due to quadrupled population.");
            }
        }
    }
}
