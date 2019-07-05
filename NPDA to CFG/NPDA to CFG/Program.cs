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
            List<Relation> RelationsList = new List<Relation>();
            Relation relation = new Relation();
            int states;
            string[] alphabets;
            string[] symboles;
            string initial_symbol;
            string relations;

            using (StreamReader reader = new StreamReader(@"C:\Users\Asus\Desktop\Input.txt"))
            {
                
                states = int.Parse(reader.ReadLine());
                alphabets = reader.ReadLine().Split(new char[] { ',' });
                symboles = reader.ReadLine().Split(new char[] { ',' });
                initial_symbol = reader.ReadLine();
               
                    relations = reader.ReadLine();
                    relation = relation.Make(relations);
                    RelationsList.Add(relation);
            }

            using (StreamWriter writer = new StreamWriter(@"C:\Users\Asus\Desktop\Output.txt)"))
            {
                foreach (var r in RelationsList)
                {
                    if (relation.PushElement.Length == 1)
                    {
                        {
                            writer.WriteLine($"({relation.State1.ToString()}{relation.PopElement.ToString()}{relation.State2.ToString()})->{relation.InputElement.ToString()}");
                        }
                    }

                    else
                    {
                        for (int i = 0; i < states; i++)
                        {
                            for (int j = 0; j < states; j++)
                            {
                                writer.WriteLine($"({relation.State1.ToString()}{relation.PopElement.ToString()}q{i})->" +
                                    $"{relation.InputElement.ToString()}({relation.State2.ToString()}{relation.PushElement[0].ToString()}{j})({j}{relation.PushElement[1].ToString()}{i})");
                            }

                        }

                    }
                }
            }
        }
    }
}
