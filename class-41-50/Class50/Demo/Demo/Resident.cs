using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Resident
    {
        private String name;

        public Resident(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            return "住戶 " + name;
        }
    }
}
