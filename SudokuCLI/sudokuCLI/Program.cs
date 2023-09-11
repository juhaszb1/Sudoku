using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace sudokuCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("feladvanyok.txt");
            List<Feladvany> list = new List<Feladvany>();
            while (!reader.EndOfStream) 
            {
                string line = reader.ReadLine();
                list.Add(new Feladvany(line));
            }

            Console.WriteLine($"3. feladat: Beolvasva {list.Count} feladvány");

            int x = 0;
            while (x < 4 || x > 9)
            {
                Console.Write("4. feladat: Kérem a feladvány méretét [4..9]: ");
                x = int.Parse(Console.ReadLine());
            }
            int db = 0;
            foreach (var item in list)
            {
                if (item.Meret == x)
                {
                    db++;
                }
            }
            Console.WriteLine($"{x}x{x} méretű feladványból {db} darab van tárolva");

            Console.WriteLine("5. feladat: A kiválasztott feladvány: ");
            Random r = new Random();
            int kivalasztott = r.Next(0, list.Count);
            Console.WriteLine(list[kivalasztott].Kezdo);

            int notnullDb = 0;
            int hossz = list[kivalasztott].Kezdo.Length;
            for (int i = 0; i < hossz; i++)
            {
                if (list[kivalasztott].Kezdo[i] != '0')
                {
                    notnullDb++;
                }
            }
            double kitoltottseg = (double)notnullDb / hossz * 100;
            Console.WriteLine($"6. feladat: A feladavány kitöltöttsége: {kitoltottseg}%");

            Console.WriteLine("7. feladat: A feladvány kirajzolva: ");
            list[kivalasztott].Kirajzol();

            Console.ReadKey();
        }
    }
}
