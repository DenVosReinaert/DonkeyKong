using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameStates
{
    class WinState : GameObjectList
    {
        public static int currentLevel = 1;

        private TextGameObject scoreText, tryAgainText;
        public WinState()
        {
            Add(new SpriteGameObject("MaliciousCompliance-temp"));

            Add(scoreText = new TextGameObject("GameFont", 1));
            scoreText.Text = "SCORE: " + PlayingState.finalScore.ToString();

            scoreText.Position = new Vector2(GameEnvironment.Screen.X/2 - scoreText.Size.X/2, GameEnvironment.Screen.Y/2);



            Add(tryAgainText = new TextGameObject("GameFont", 1));
            tryAgainText.Position = new Vector2(scoreText.Position.X, scoreText.Position.Y - 200);



        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.AnyKeyPressed)
                NextLevel();
        }


        public static void NextLevel()
        {
            currentLevel++;
            GameEnvironment.GameStateManager.SwitchTo("Level" + currentLevel.ToString());
        }



    }
}
