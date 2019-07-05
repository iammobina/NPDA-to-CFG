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

            states = int.Parse(lines[0]);
            alphabets = lines[1].Split(new char[] { ',' });
            symboles = lines[2].Split(new char[] { ',' });
            initial_symbol = lines[3];

            for (int i = 4; i < lines.Length; i++)
            {
                relations = lines[i];
                RelationsList.Add(relation.Make(relations));
            }



            StreamWriter writer = new StreamWriter(@"C:\Users\Asus\Desktop\Output.txt");
            for(int a=0; a<RelationsList.Count; a++)
            {
                if (RelationsList[a].PushElement.Length <=1 )
                {
                    {
                        writer.WriteLine($"({RelationsList[a].State1}{RelationsList[a].PopElement}{RelationsList[a].State2})->{RelationsList[a].InputElement}");
                    }
                }

                else
                {
                    for (int i = 0; i < states; i++)
                    {
                        for (int j = 0; j < states; j++)
                        {
                            writer.WriteLine($"({RelationsList[a].State1}{RelationsList[a].PopElement}q{i})->" +
                                $"{RelationsList[a].InputElement}({RelationsList[a].State2}{RelationsList[a].PushElement[0]}q{j})(q{j}{RelationsList[a].PushElement[1]}q{i})");
                        }

                    }

                }
            }
            writer.Close();

        }
    }
}

