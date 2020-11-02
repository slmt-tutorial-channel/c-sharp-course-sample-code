using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Worker
    {
        private String name;

        public Worker(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            return "辦公人士 " + name;
        }
    }
}
