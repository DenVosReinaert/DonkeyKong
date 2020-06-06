using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    class Projectile : RotatingSpriteGameObject
    {
        public Projectile() : base("projectile-temp")
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(position.X + Sprite.Width/2 > GameEnvironment.Screen.X || position.X - Sprite.Width / 2 < 0)
            {
                velocity.X = -velocity.X;
            }

            if (grounded)
            {
                gravity = 0;
            }
            else
            {
                gravity += 0.1f;
                position.Y += gravity;
            }
        }

    }
}
