using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ImpHunter.GameObjects
{
    public class Player : SpriteGameObject
    {
        Vector2 moveDir;
        private float moveSpeed;
        private float jumpForce;

        public bool climbingUp, climbingDown;
        public Player() : base("player-temp")
        {
            moveSpeed = 2.5f;
            jumpForce = 4;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X - Sprite.Width);

            position += moveDir * moveSpeed;

            if (grounded)
            {
                gravity = 0;
            }

            if ((!climbingUp || !climbingDown) && !grounded)
            {
                gravity += 0.12f;
                position.Y += gravity;
            }

            #region Climbing controls
            if (climbingUp)
            {
                Console.WriteLine("Look ma! no hands!");
                moveDir.Y = -1;
            }
            else if (climbingDown)
            {
                Console.WriteLine("Look ma! no hands!");
                moveDir.Y = 1;
            }
            else moveDir.Y = 0;
            #endregion
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
