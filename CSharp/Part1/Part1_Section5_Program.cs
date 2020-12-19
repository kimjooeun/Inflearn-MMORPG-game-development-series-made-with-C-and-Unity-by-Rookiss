using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{ 

    class Part1_Section5_Program
    {
        static void Main (string[] args)
        {
            //Part1_Section5_Player player = new Knight();
            //Part1_Section5_Player player2 = new Archer();
            //Monster monster = new Orc();

            //int damage = player.GetAttack();
            //monster.OnDamaged(damage);
            //player2.OnDamaged(damage);

            Part1_Section5_Game game = new Part1_Section5_Game();
            while (true)
            {
                game.Process();
            }
        }
    }
}
