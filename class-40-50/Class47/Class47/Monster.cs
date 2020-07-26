using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class47
{
    class Monster
    {
        public void attack(Creature c)
        {
            c.injured(10);
        }
    }
}
