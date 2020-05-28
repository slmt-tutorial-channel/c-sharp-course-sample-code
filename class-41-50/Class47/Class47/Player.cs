using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class47
{
    class Player : Creature
    {
        public Player(string name) : base(name)
        {

        }

        public override string say()
        {
            return "哈哈！我是玩家 " + name + "，我有 " + hp + " 滴血";
        }
    }
}
