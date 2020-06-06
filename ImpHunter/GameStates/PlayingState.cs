using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;
using System.Linq;

namespace ImpHunter.GameStates
{

    public class PlayingState : GameObjectList
    {
        public GameObjectList basePlatformRow;
        public GameObjectList platformRows;
        public GameObjectList finishPlatformRow;

        Player player;

        public PlayingState()
        {
            Add(basePlatformRow = new GameObjectList());
            Add(platformRows = new GameObjectList());
            Add(finishPlatformRow = new GameObjectList());

            Add(player = new Player());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            if (CollidesWithPlatform(player, out float collidedY))
            {
                player.grounded = true;
            }
            else player.grounded = false;



            foreach (Platform platform in basePlatformRow.Children.Concat(finishPlatformRow.Children).Concat(platformRows.Children))
                if (player.CollidesWith(platform) && player.Position.Y + player.Sprite.Height > platform.Position.Y && player.Position.Y + player.Sprite.Height < platform.Position.Y + platform.Sprite.Height)
                {
                    player.Position = new Vector2(player.Position.X, platform.Position.Y - player.Sprite.Height + 1);
                    player.grounded = true;
                }

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
