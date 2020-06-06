using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    public class Projectile : RotatingSpriteGameObject
    {
        private float moveSpeed;

        public Projectile(Vector2 startPosition) : base("projectile-temp")
        {
            position = startPosition;

            origin = Sprite.Center;

            moveSpeed = 200;

            velocity.X = moveSpeed;

 
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Degrees += 360f/moveSpeed * 2;

            if (position.X + Sprite.Width/2 > GameEnvironment.Screen.X || position.X - Sprite.Width / 2 < 0)
            {
                velocity.X = -velocity.X;
                moveSpeed = -moveSpeed;
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
