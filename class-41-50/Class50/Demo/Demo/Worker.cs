using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Worker : Person
    {
        private String name;

        public Worker(String name)
        {
            this.name = name;
        }

        public override String WhoAreYou()
        {
            return "辦公人士 " + name;
        }
    }
}
