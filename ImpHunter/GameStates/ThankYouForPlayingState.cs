using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameStates
{
    class ThankYouForPlayingState : GameObjectList
    {
        private TextGameObject thankYouForPlayingText;
        public ThankYouForPlayingState()
        {
            Add(new SpriteGameObject("MaliciousCompliance-temp"));
            Add(thankYouForPlayingText = new TextGameObject("GameFont", 1));

            thankYouForPlayingText.Text = "THANK YOU FOR PLAYING! :)";
            thankYouForPlayingText.Position = new Vector2(GameEnvironment.Screen.X/2 - thankYouForPlayingText.Size.X/2, GameEnvironment.Screen.Y/2);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.AnyKeyPressed)
                GameEnvironment.GameStateManager.SwitchTo("TitleScreenState");
        }


    }
}
