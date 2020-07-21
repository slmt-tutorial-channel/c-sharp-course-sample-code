using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class48
{
    abstract class Creature
    {
        protected int hp = 100;

        public virtual string say()
        {
            return "Hi~ 我是 " + getName() + "，我有 " + hp + " 滴血";
        }

        public void injured(int damage)
        {
            hp -= damage;
        }

        public abstract string getName();
    }
}
