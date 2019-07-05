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
            int states;
            string[] alphabets;
            string[] symboles;
            string initial_symbol;
            string relations;

            using (StreamReader reader = new StreamReader(@"E:\Project2\Project2\Input.txt"))
            {
                states = int.Parse(reader.ReadLine());
                alphabets = reader.ReadLine().Split(new char[] { ',' });
                symboles = reader.ReadLine().Split(new char[] { ',' });
                initial_symbol = reader.ReadLine();
                relations = reader.ReadLine();
            }
            relation.States = states;
            relation.Make(relations);
            relation.SaveToFile();
           
        }
    }
}
