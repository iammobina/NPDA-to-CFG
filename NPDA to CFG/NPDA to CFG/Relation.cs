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
        private string State1;
        private string InputElement;
        private string PopElement;
        private string PushElement;
        private string State2;
        private List<Relation> relations;

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

        public void Make(string relation)
        {
            Relation r;
            for (int i = 0; ; i++)
            {
                string[] initialstate = new string[1];
                string[] finalstate = new string[1];

                if (relation[0] == '-' && relation[1] == '>')
                    initialstate[0] = relation.Substring(2, 2);

                if (relation[relation.Length - 3] == '*')
                    finalstate[0] = relation.Substring(relation.Length-2, 2);

                string[] newrelation = relation.Split(new char[] { '-', '>', ',' });
                State1 = newrelation[0];
                InputElement = newrelation[1];
                PopElement = newrelation[2];
                PushElement = newrelation[3];
                State2 = newrelation[4];
                r = new Relation(State1, InputElement, PopElement, PushElement, State2);
                relations.Add(r);
            }
        }

        public void SaveToFile(List<Relation> relations)
        {
            StreamWriter writer = new StreamWriter(@"C:\git\Nazariye\Project2\Output.txt)");
            foreach (Relation r in relations)
            {
                if(PushElement.Length == 1)
                {
                    {
                        writer.WriteLine($"({State1}{PopElement}{State2})->{InputElement}");
                    }
                }

                else
                {
                    for(int i=0; i<States; i++)
                    {
                        for(int j=0; j<States; j++)
                        {
                            writer.WriteLine($"({State1}{PopElement}q{i})->{InputElement}({State2}{PushElement[0]}{j})({j}{PushElement[1]}{i})");
                        }
                       
                    }
                    
                }
            }
            writer.Close();
              
        }



    }
}
