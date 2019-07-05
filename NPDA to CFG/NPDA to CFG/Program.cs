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
            string[] lines = File.ReadAllLines(@"C:\Users\Asus\Desktop\Input.txt");
            using (StreamReader reader = new StreamReader(@"C:\Users\Asus\Desktop\Input.txt"))
            {

                states = int.Parse(reader.ReadLine());
                alphabets = reader.ReadLine().Split(new char[] { ',' });
                symboles = reader.ReadLine().Split(new char[] { ',' });
                initial_symbol = reader.ReadLine();

                int i = 4;
                while (i < lines.Length)
                {
                    relations = reader.ReadLine();
                    if (relations == null)
                        break;
                    RelationsList.Add(relation.Make(relations));
                    i++;
                }
            }


            StreamWriter writer = new StreamWriter(@"C:\Users\Asus\Desktop\Output.txt");
            foreach (Relation r in RelationsList)
            {
                if (relation.PushElement.Length == 1)
                {
                    {
                        writer.WriteLine($"({relation.State1}{relation.PopElement}{relation.State2})->{relation.InputElement}");
                    }
                }

                else
                {
                    for (int i = 0; i < states; i++)
                    {
                        for (int j = 0; j < states; j++)
                        {
                            writer.WriteLine($"({relation.State1}{relation.PopElement}q{i})->" +
                                $"{relation.InputElement}({relation.State2}{relation.PushElement[0]}q{j})(q{j}{relation.PushElement[1]}q{i})");
                        }

                    }

                }
            }
            writer.Close();

        }
    }
}

