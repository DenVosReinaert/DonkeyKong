using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    class Platform : SpriteGameObject
    {
        public Platform(Vector2 position) : base("platform-temp")
        {
            this.position = position;
        }

    }
}
