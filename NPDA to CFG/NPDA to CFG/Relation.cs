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

        public Relation()
        {
        }

        public Relation(string state1, string inputElement, string popElement, string pushElement, string state2)
        {
            State1 = state1;
            InputElement = inputElement;
            PopElement = popElement;
            PushElement = pushElement;
            State2 = state2;
        }

        public List<Relation> Make(List<string> relation)
        {
            List<Relation> relations=new List<Relation>();
            Relation r;
            string[] newrelation;
            string[] initialstate = new string[1];
            string[] finalstate = new string[1];
            foreach (var element in relation)
            {
                if (element[0] == '-' && element[1] == '>')
                {
                    initialstate[0] = element.Substring(2, 2);
                    element.Remove(0, 2);
                }

                if (element[element.Length - 3] == '*')
                    finalstate[0] = element.Substring(element.Length - 2, 2);

                newrelation = element.Split(new char[] { ',' });
                this.State1 = newrelation[0];
                this.InputElement = newrelation[1];
                this.PopElement = newrelation[2];
                this.PushElement = newrelation[3];
                this.State2 = newrelation[4];
                r = new Relation(State1, InputElement, PopElement, PushElement, State2);
                relations.Add(r);
            }
            return relations;
        }

        public void SaveToFile(List<Relation> relations)
        {
            StreamWriter writer = new StreamWriter(@"E:\Project2\Project2\Output.txt");
            for (int j = 0; j < relations.Count(); j++)
            {
                for (int m = 0; m < 5; m++)
                {
                    if (PushElement.Length == 1)
                    {
                        writer.WriteLine($"({this.State1[m]}{this.PopElement[m]}{this.State2[m]})->{this.InputElement[m]}");
                    }
                }
            
                    for (int i = 0; i < States; i++)
                    {
                        for (int k = 0; k < States; k++)
                        {
                            writer.WriteLine($"({this.State1}{this.PopElement}q{i})->{this.InputElement}({this.State2}{this.PushElement[0]}{j})({j}{this.PushElement[1]}{i})");
                        }

                    }

                }
            
            writer.Close();
              
        }



    }
}
