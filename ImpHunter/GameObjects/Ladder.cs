using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    class Ladder : SpriteGameObject
    {
        public bool beingClimbed = false;
        public Ladder(Vector2 position) : base("ladder-temp")
        {
            Position = position;
        }

    }
}
