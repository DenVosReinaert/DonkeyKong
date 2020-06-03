using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    class Player : SpriteGameObject
    {
        Vector2 moveDir;
        private float moveSpeed;
        private float jumpForce;

        public bool grounded;
        public Player() : base("player-temp")
        {
            moveSpeed = 2;
            jumpForce = 4;

            position = new Vector2(0, 100);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            position += moveDir * moveSpeed;

            if (grounded)
                gravity = 0;
            else
            {
                gravity += 0.1f;

            }

            position.Y += gravity;
        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            #region Direction Control
            if (inputHelper.IsKeyDown(Keys.A))
                moveDir.X = -1;
            else if (inputHelper.IsKeyDown(Keys.D))
                moveDir.X = 1;
            else moveDir.X = 0;
            #endregion

            if (inputHelper.KeyPressed(Keys.Space) && grounded)
            {
                grounded = false;
                gravity = -jumpForce;
            }
        }
    }
}
