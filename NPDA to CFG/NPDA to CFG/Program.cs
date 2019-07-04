using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDA_to_CFG
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (StreamReader reader = new StreamReader())
            //{
            //    string states = reader.ReadLine().s;
            //    string alphabets = reader.ReadLine();
            //    string symboles = reader.ReadLine();
            //    string initial_symbol = reader.ReadLine();
            //    string[] relations = reader.ReadLine();

            //}
            string[] a = Console.ReadLine().Split(new char[] {','});
            Console.WriteLine(a[1]);
            Console.ReadKey();
        }
    }
}
