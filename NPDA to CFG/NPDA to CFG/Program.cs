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
            //Relation relation = new Relation();
            //int states;
            //string[] alphabets;
            //string[] symboles;
            //string initial_symbol;
            //List<string> relations = new List<string>();

            //string[] lines = File.ReadAllLines(@"E:\Project2\Project2\Input.txt");
            //{
            //    states = int.Parse(lines[0]);
            //    alphabets = lines[1].Split(new char[] { ',' }).ToArray();
            //    symboles = lines[2].Split(new char[] { ',' }).ToArray();
            //    initial_symbol = lines[3];
            //    foreach(var line in lines.Skip(4))
            //    { 
            //        relations.Add(line);
            //    }
            //}
            //relation.States = states;
            //List<Relation> connection = relation.Make(relations);
            //relation.SaveToFile(connection);

            List<Relation> RelationsList = new List<Relation>();
            Relation relation = new Relation();
            int states;
            string[] alphabets;
            string[] symboles;
            string initial_symbol;
            string relations;
            string[] lines = File.ReadAllLines(@"E:\Project2\Project2\Input.txt");
            using (StreamReader reader = new StreamReader(@"E:\Project2\Project2\Input.txt"))
            {
                states = int.Parse(reader.ReadLine());
                alphabets = reader.ReadLine().Split(new char[] { ',' });
                symboles = reader.ReadLine().Split(new char[] { ',' });
                initial_symbol = reader.ReadLine();

                while (lines != null)
                {
                    relations = reader.ReadLine();
                    if (relations == null)
                        break;
                    relation = relation.Make(relations);
                    RelationsList.Add(relation);
                }

            }

        }
    }
}