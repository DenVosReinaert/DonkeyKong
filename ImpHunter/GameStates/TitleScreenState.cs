using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpHunter.GameStates;
using DonkeyKong;
using Microsoft.Xna.Framework;
using ImpHunter.GameObjects;

namespace ImpHunter.GameStates
{
    class TitleScreenState : GameObjectList
    {

        GameObjectList ornaments;
        private TextGameObject pressToContinue;

        public TitleScreenState()
        {
            Add(new SpriteGameObject("MaliciousCompliance-temp"));
            Add(pressToContinue = new TextGameObject("GameFont"));
            pressToContinue.Text = "Press any key to continue";
            pressToContinue.Position = new Vector2(GameEnvironment.Screen.X/2 - pressToContinue.Size.X/2, GameEnvironment.Screen.Y/2 + 200);
            

            Add(ornaments = new GameObjectList());

            ornaments.Add(new SpriteGameObject("player-temp"));
            ornaments.Children[0].Position = new Vector2(GameEnvironment.Screen.X/2 - (ornaments.Children[0] as SpriteGameObject).Sprite.Width/2, GameEnvironment.Screen.Y/2 - (ornaments.Children[0] as SpriteGameObject).Sprite.Height);

            for (int i = 0; i < 4; i++)
            {
                ornaments.Add(new SpriteGameObject("platform-temp"));
                ornaments.Children[i + 1].Position = new Vector2(ornaments.Children[0].Position.X + (ornaments.Children[0] as SpriteGameObject).Sprite.Width/2 - (ornaments.Children[i] as SpriteGameObject).Sprite.Width*2.5f + (ornaments.Children[i] as SpriteGameObject).Sprite.Width*i, GameEnvironment.Screen.Y / 2);
            }

            ornaments.Add(new Projectile());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ornaments.Children[5].Position = new Vector2(ornaments.Children[0].Position.X + 90, GameEnvironment.Screen.Y/2 - (ornaments.Children[5] as Projectile).Sprite.Height / 2);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if(inputHelper.AnyKeyPressed)
            {
                GameEnvironment.GameStateManager.SwitchTo("Level1");
            }
        }

    }
}
