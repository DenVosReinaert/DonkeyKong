using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameStates
{
    public class WinState : GameObjectList
    {
        public static int currentLevel = 1;
        public static int score;

        private TextGameObject scoreText, tryAgainText;

        private Queue<RotatingSpriteGameObject> confettiQueue = new Queue<RotatingSpriteGameObject>();
        private GameObjectList confettiList;
        private int frameCount;
        private int confettiCount = 50;
        public WinState()
        {
            Add(new SpriteGameObject("MaliciousCompliance-temp"));

            Add(scoreText = new TextGameObject("GameFont", 1));
            Add(confettiList = new GameObjectList());
            for (int i = 0; i < confettiCount; i++)
            {
                confettiList.Add(new RotatingSpriteGameObject("confetti" + GameEnvironment.Random.Next(6) + "-temp")); 
                
            }
            foreach (RotatingSpriteGameObject confetti in confettiList.Children)
            {

                confetti.Origin = confetti.Center;
                confetti.Degrees += GameEnvironment.Random.Next(-20, 20);
                confetti.Velocity = new Vector2(GameEnvironment.Random.Next(-10, 10), 20);
                confetti.Position = new Vector2(GameEnvironment.Random.Next(0, GameEnvironment.Screen.X), GameEnvironment.Random.Next(-50, -20));
                confettiQueue.Enqueue(confetti);
            }

            scoreText.Text = "SCORE: " + PlayingState.finalScore.ToString();
            scoreText.Position = new Vector2(GameEnvironment.Screen.X / 2 - scoreText.Size.X / 2f, GameEnvironment.Screen.Y / 2);

            Add(tryAgainText = new TextGameObject("GameFont", 1));


            tryAgainText.Text = "Press any key to continue.";
            tryAgainText.Position = new Vector2(GameEnvironment.Screen.X / 2 - scoreText.Size.X * 1.5f, scoreText.Position.Y + 200);



        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            scoreText.Text = "SCORE: " + PlayingState.finalScore.ToString();
            scoreText.Position = new Vector2(GameEnvironment.Screen.X / 2 - scoreText.Size.X / 2f, GameEnvironment.Screen.Y / 2);



            frameCount++;

            if(frameCount > 60)
            {
                SpawnConfetti();
                frameCount = 0;
            }

            foreach(RotatingSpriteGameObject confetti in confettiList.Children)
            {
                confetti.Degrees += 2;
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.AnyKeyPressed)
                NextLevel();
        }


        public static void NextLevel()
        {
            if (currentLevel < 2)
            {
                currentLevel++;
                GameEnvironment.GameStateManager.SwitchTo("Level" + currentLevel.ToString());
            }
            else GameEnvironment.GameStateManager.SwitchTo("Thank You For Playing");
        }


        public void SpawnConfetti()
        {
            RotatingSpriteGameObject confetti = confettiQueue.Dequeue();
            confetti.Position = new Vector2(GameEnvironment.Random.Next(0, GameEnvironment.Screen.X), GameEnvironment.Random.Next(-50, 0));
            confetti.Degrees = GameEnvironment.Random.Next(180);
            confetti.Velocity = new Vector2(GameEnvironment.Random.Next(-10, 10), 20);
            confettiQueue.Enqueue(confetti);
        }


    }
}
