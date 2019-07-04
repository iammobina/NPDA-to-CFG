using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDA_to_CFG
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Relation relation = new Relation();

            using (StreamReader reader = new StreamReader(@"C:\Users\Asus\Desktop\Input.txt"))
            {
                int states = int.Parse(reader.ReadLine());
                string[] alphabets = reader.ReadLine().Split(new char[] { ',' });
                string[] symboles = reader.ReadLine().Split(new char[] { ',' });
                string initial_symbol = reader.ReadLine();
                relation.Make(reader.ReadLine());
                relation.States = states;
            }
           
        }
    }
}
