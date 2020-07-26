using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class48
{
    class Monster : Creature, IAttackable
    {
        public override string say()
        {
            return "吼吼吼~ (有 " + hp + " 滴血)";
        }

        public override string getName()
        {
            return "怪物";
        }

        public void attack(Creature target)
        {
            target.injured(5);
        }
    }
}
