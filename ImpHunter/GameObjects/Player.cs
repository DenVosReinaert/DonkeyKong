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

        public bool climbing = false;
        public bool grounded = false;
        public Player() : base("player-temp")
        {
            moveSpeed = 2;
            jumpForce = 4;

            position = new Vector2(0, 500);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X - Sprite.Width);

            position += moveDir * moveSpeed;

            if(grounded)
            {
                gravity = 0;
            }

            if (!climbing && !grounded)
            {
                gravity += 0.1f;
                position.Y += gravity;
            }
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

            #region Climbing controls
            if (climbing && inputHelper.IsKeyDown(Keys.W))
                moveDir.Y = -1;
            else if (climbing && inputHelper.IsKeyDown(Keys.S))
                moveDir.Y = 1;
            else moveDir.Y = 0;
            #endregion
            #endregion

            if (inputHelper.KeyPressed(Keys.Space) && grounded)
            {
                grounded = false;
                gravity = -jumpForce;
            }

        }
    }
}
