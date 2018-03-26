using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie2();
            Zadanie3();
            Zadanie4();            
        }

        public static void Zadanie2()
        {
            Console.WriteLine("ZADANIE 2");
            Int32.TryParse(Console.ReadLine(), out int N);
            IEnumerable<int> squares = Enumerable.Range(1, N).Where(x => (x % 2 == 1 || x % 7 == 0)).Where(x => x != 5 && x != 9).Select(x => x * x);
            Console.WriteLine(squares.Sum());
            Console.WriteLine(squares.Count());
            Console.WriteLine(squares.First());
            Console.WriteLine(squares.Last());
            Console.WriteLine(squares.ElementAt(2));
        }

        public static void Zadanie3()
        {
            Console.WriteLine("ZADANIE 3");

            Console.WriteLine("podaj x:");
            Int32.TryParse(Console.ReadLine(), out int m);
            Console.WriteLine("podaj y:");
            Int32.TryParse(Console.ReadLine(), out int n);
            
            Random rnd = new Random();
            IEnumerable<IEnumerable<int>> list = Enumerable.Range(1, n).Select(x => Enumerable.Range(1, m).Select(s => rnd.Next(0,2)));
            List<int> ints = list.SelectMany(x => x).ToList();
            string tab = string.Join(",", ints);
            Console.WriteLine("nowa tabl: " + tab);
            int sum = ints.Sum();
            Console.WriteLine("Suma: " + sum);
        }

        public static void Zadanie4()
        {
            Console.WriteLine("ZADANIE 4");
            Console.WriteLine("Podaj miasta:");
            List<String> cityList2 = new List<string>();
            String currLine = "";
            while (true)
            {
                currLine = Console.ReadLine();
                if(currLine == "X")
                {
                    break;
                }
                else
                {
                     cityList2.Add(currLine);
                }
            }
            Console.WriteLine("Podaj literę(wielkość ma znaczenie):");
            Dictionary<char, List<String>> dictionary = cityList2.GroupBy(x => x[0]).ToDictionary(g => g.Key, g => g.ToList());
            ConsoleKeyInfo startWith;
            do
            {
                startWith = Console.ReadKey();
                String all = "PUSTE";
                if (dictionary.TryGetValue(startWith.KeyChar, out List<string> tmpList))
                {
                    all = String.Join(",", tmpList.OrderBy(q => q).ToList());
                }
                Console.WriteLine(all);
            } while (startWith.Key != ConsoleKey.Escape);

        }

       
    }
}
