using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class48
{
    class Villager : Creature, ITalkable
    {
        public override string getName()
        {
            return "村民";
        }

        public string talkTo(Creature target)
        {
            return "Hi~" + target.getName() + "！我是村民！";
        }
    }
}
