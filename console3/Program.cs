using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace console3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("file1.txt"))
            {
                string file = File.ReadAllText("file1.txt");
                if (!string.IsNullOrEmpty(file)) {
                    string[] fromfile = file.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

                    double[] numbers = fromfile.Select(double.Parse).ToArray();
                    var f = numbers.GroupBy(n => n)
                        .Select(g => new
                        {
                            num = g.Key,
                            period = g.Count()
                        });
                    Console.WriteLine("Число Номер Частота");
                    Console.WriteLine("------------------------------------------------");
                    foreach (var v in f)
                    {
                        Console.WriteLine($"{v.num} \t {v.period}");
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("Число Частота");
                    Console.WriteLine("------------------------------------------------");

                    foreach (var v in f)
                        {                            
                            Console.WriteLine($"{v.num * v.period} \t {v.period}");                          
                        }  
                }
                else Console.WriteLine("Файл пустой!");
            }
            else Console.WriteLine("Файл не найден!");

            Console.ReadKey();
        }
    }
}
