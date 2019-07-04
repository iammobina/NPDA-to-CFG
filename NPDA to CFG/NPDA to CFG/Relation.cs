using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDA_to_CFG
{
    class Relation
    {
        private string State1;
        private string InputElement;
        private string PopElement;
        private string PushElement;
        private string State2;

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

        }



    }
}
