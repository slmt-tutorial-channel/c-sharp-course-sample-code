using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class47
{
    class Creature
    {
        protected int hp;
        protected string name;

        public Creature(string name)
        {
            this.name = name;
            this.hp = 100;
        }

        public void injured(int damage)
        {
            if (damage > hp)
            {
                this.hp = 0;
            } else
            {
                this.hp -= damage;
            }
        }

        public virtual string say()
        {
            return "我是 " + name + "，我有 " + hp + " 滴血";
        }
    }
}
