using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDA_to_CFG
{
    public class Relation
    {
        public int States;
        public string State1;
        public string InputElement;
        public string PopElement;
        public string PushElement;
        public string State2;
        public List<Relation> RelationsList;

        public Relation()
        {

        }

        public Relation(string s1, string input, string pop, string push, string s2)
        {
            this.State1 = s1;
            this.InputElement = input;
            this.PopElement = pop;
            this.PushElement = push;
            this.State2 = s2;

        }

        public Relation Make(string relation)
        {
            string[] initialstate = new string[1];
            string[] finalstate = new string[1];

            if (relation[0] == '-' && relation[1] == '>')
            {
                initialstate[0] = relation.Substring(2, 2);
                relation = relation.Remove(0, 2);
            }

            if (relation[relation.Length - 3] == '*')
                finalstate[0] = relation.Substring(relation.Length - 2, 2);

            string[] newrelations = relation.Split(new char[] { ',' });
            this.State1 = newrelations[0];
            this.InputElement = newrelations[1];
            this.PopElement = newrelations[2];
            this.PushElement = newrelations[3];
            this.State2 = newrelations[4];

            return new Relation(State1, InputElement, PopElement, PushElement, State2);

        }

        public void savetofile(List<Relation> RelationsList)
        { 
            using (StreamWriter writer = new StreamWriter(@"E:\Project2\Project2\output.txt"))
            {
                foreach (var relation in RelationsList)
                {
                    if (relation.PushElement.Length == 1)
                    {
                        {
                            writer.WriteLine($"({relation.State1.ToString()}{relation.PopElement.ToString()}{relation.State2.ToString()})->{relation.InputElement.ToString()}");
                        }
                    }

                    else
                    {
                        for (int i = 0; i<States; i++)
                        {
                            for (int j = 0; j<States; j++)
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