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
        public List<Relation> relations;

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
            relations = new List<Relation>();
        }

        public void Make(string relation)
        {
            Relation r;
            string[] newrelation;
            for (int i = 0; ; i++)
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
               
                newrelation = relation.Split(new char[] { ',' });
                this.State1 = newrelation[0];
                this.InputElement = newrelation[1];
                this.PopElement = newrelation[2];
                this.PushElement = newrelation[3];
                this.State2 = newrelation[4];
                r = new Relation(State1, InputElement, PopElement, PushElement, State2);
                relations.Add(r);
               
            }
        }

        public void SaveToFile()
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\Asus\Desktop\Output.txt)");
            foreach (Relation r in relations)
            {
                if(PushElement.Length == 1)
                {
                    {
                        writer.WriteLine($"({this.State1}{this.PopElement}{this.State2})->{this.InputElement}");
                    }
                }

                else
                {
                    for(int i=0; i<States; i++)
                    {
                        for(int j=0; j<States; j++)
                        {
                            writer.WriteLine($"({this.State1}{this.PopElement}q{i})->{this.InputElement}({this.State2}{this.PushElement[0]}{j})({j}{this.PushElement[1]}{i})");
                        }
                       
                    }
                    
                }
            }
            writer.Close();
              
        }



    }
}
