using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Building<P>
    {
        List<P> people = new List<P>();

        public void Add(P person)
        {
            people.Add(person);
        }

        public String WhoAreIn()
        {
            String output = "這棟大樓裡有：\r\n";

            for (int i = 0; i < people.Count; i++)
            {
                output += people[i].WhoAreYou() + "\r\n";
            }

            return output;
        }
    }
}
