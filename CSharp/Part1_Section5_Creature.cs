using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public enum CretureType
    {
        None,
        Player = 1,
        Monster = 2
    }

    class Part1_Section5_Creature
    {
        CretureType type;

        protected int hp = 0;
        protected int attack = 0;

        protected Part1_Section5_Creature(CretureType yupe)
        {
            this.type = type;
        }

        public void Setinfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }

        public int GetHP() { return hp; }
        public int GetAttack() { return attack; }
        public bool IsDead() { return hp <= 0; }
        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }
    }
}
