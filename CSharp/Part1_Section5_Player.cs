using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
        public enum PlayerType
        {
            None,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        class Player : Part1_Section5_Creature
        {
            protected PlayerType type = PlayerType.None;

            protected Player(PlayerType type) : base(CretureType.Player)
            {
                this.type = type;
            }

            public PlayerType GetPlayerType() { return type; }

        }

        class Knight : Player
        {
            public Knight() : base(PlayerType.Knight)
            {
                //type = PlayerType.Knight;
                Setinfo(100, 10);
            }
        }

        class Archer : Player
        {
            public Archer() : base(PlayerType.Archer)
            {
                //type = PlayerType.Archer;
                Setinfo(75, 12);
            }
        }

        class Mage : Player
        {
            public Mage() : base(PlayerType.Mage)
            {
                //type = PlayerType.Mage;
                Setinfo(50, 15);
            }
        }
}