using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace ImpHunter.GameStates
{

    public class PlayingState : GameObjectList
    {
        public GameObjectList basePlatformRow;
        public GameObjectList platformRows;
        public GameObjectList finishPlatformRow;

        public GameObjectList ladders;



        public Player player;
        public Projectile projectile;

        public ObjectPool objectPooler;



        public PlayingState()
        {
            objectPooler = new ObjectPool();



            #region GameObjectLists
            Add(basePlatformRow = new GameObjectList());
            Add(platformRows = new GameObjectList());
            Add(finishPlatformRow = new GameObjectList());

            Add(ladders = new GameObjectList());

            #endregion
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            #region Player & Projectile Platfrom Collision
            if (CollidesWithPlatform(player, out float collidedY))
            {
                player.grounded = true;
            }
            else player.grounded = false;



            foreach (GameObject projectile in objectPooler.projectiles.objectPool)
            {
                if (CollidesWithPlatform(projectile as RotatingSpriteGameObject, out float collidedY2))
                {
                    projectile.grounded = true;
                }
                else projectile.grounded = false;


                if((projectile as RotatingSpriteGameObject).CollidesWith(player))
                {
                    Console.WriteLine("Get Fucked!");
                }
            }



            foreach (Platform platform in basePlatformRow.Children.Concat(finishPlatformRow.Children).Concat(platformRows.Children))
            {
                if (player.CollidesWith(platform) && player.Position.Y + player.Sprite.Height > platform.Position.Y && player.Position.Y + player.Sprite.Height < platform.Position.Y + platform.Sprite.Height)
                {
                    player.Position = new Vector2(player.Position.X, platform.Position.Y - player.Sprite.Height + 1);
                    player.grounded = true;
                }

                foreach (GameObject projectile in objectPooler.projectiles.objectPool)
                    if ((projectile as RotatingSpriteGameObject).CollidesWith(platform) && projectile.Position.Y + (projectile as RotatingSpriteGameObject).Sprite.Height/2 > platform.Position.Y && projectile.Position.Y + (projectile as RotatingSpriteGameObject).Sprite.Height/2 < platform.Position.Y + platform.Sprite.Height)
                    {
                        projectile.Position = new Vector2(projectile.Position.X, platform.Position.Y - (projectile as RotatingSpriteGameObject).Sprite.Height/2 + 1);
                        projectile.grounded = true;
                    }

            }

            #endregion
        }

        private bool CollidesWithPlatform(SpriteGameObject obj, out float collidedY)
        {

            bool collided = false;

            collidedY = 0;

            foreach (Platform platform in basePlatformRow.Children.Concat(finishPlatformRow.Children).Concat(platformRows.Children))
            {
                if (obj.CollidesWith(platform) && obj.Position.Y + obj.Sprite.Height - 10 < platform.Position.Y)
                {
                    collided = true;
                    collidedY = platform.Position.Y;

                    obj.gravity = 0;
                }
            }

            return collided;
        }

    }
}
