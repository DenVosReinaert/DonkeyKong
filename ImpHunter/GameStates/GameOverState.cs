using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameStates
{
    class GameOverState : GameObjectList
    {
        private TextGameObject gameOverText, tryAgainText;


        public GameOverState()
        {
            Add(new SpriteGameObject("MaliciousCompliance-temp"));
            Add(gameOverText = new TextGameObject("GameFont", 1));
            Add(tryAgainText = new TextGameObject("GameFont", 1));

            gameOverText.Text = "GAME OVER";
            gameOverText.Position = new Vector2(GameEnvironment.Screen.X / 2 - gameOverText.Size.X*1.5f, GameEnvironment.Screen.Y / 2);


            tryAgainText.Text = "Press any key to continue.";
            tryAgainText.Position = new Vector2(gameOverText.Position.X, gameOverText.Position.Y - 200);


        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.AnyKeyPressed)
            {
                GameEnvironment.GameStateManager.SwitchTo("TitleScreenState");
                WinState.currentLevel = 1;
            }
        }

    }
}
