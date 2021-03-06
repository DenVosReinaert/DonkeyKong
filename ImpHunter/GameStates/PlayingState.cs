﻿using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace ImpHunter.GameStates
{

    public class PlayingState : GameObjectList
    {
        #region GameObjectLists

        #region Public
        public GameObjectList basePlatformRow;
        public GameObjectList platformRows;
        public GameObjectList finishPlatformRow;

        public GameObjectList barrels;

        public GameObjectList ladders;

        public GameObjectList projectileList;
        #endregion

        #region Private
        private GameObjectList lives;
        #endregion

        #endregion

        public Player player;
        public Vector2 resetPoint = new Vector2();

        public Projectile projectile;
        public Queue<Projectile> projectileQueue = new Queue<Projectile>();
        public int projectileQueueSize = 60;

        public SpriteGameObject victory;

        public SpriteGameObject barrel0;
        public SpriteGameObject barrel1;

        public SpriteGameObject timeUp;

        public int frameCount;
        public int baseFrameCount;

        public int startTimeScore;
        public int timeScore;
        private int scoreFramecount;
        private TextGameObject scoreText;

        public static int finalScore = new int();





        public PlayingState()
        {
            Add(new SpriteGameObject("MaliciousCompliance-temp"));
            Add(scoreText = new TextGameObject("GameFont", 1));
            scoreText.Position = new Vector2(710, 0);

            #region GameObjectLists
            Add(basePlatformRow = new GameObjectList());
            Add(platformRows = new GameObjectList());
            Add(finishPlatformRow = new GameObjectList());

            Add(barrels = new GameObjectList());
            
            barrels.Add(barrel0 = new SpriteGameObject("barrel-temp"));
            barrels.Add(barrel1 = new SpriteGameObject("barrel-temp"));

            Add(victory = new SpriteGameObject("victory-temp"));

            Add(ladders = new GameObjectList());

            Add(projectileList = new GameObjectList());

            Add(lives = new GameObjectList());

            Add(player = new Player());
            Add(timeUp = new SpriteGameObject("timeup-temp"));


            #endregion

            for (int i = 0; i < projectileQueueSize; i++)
            {
                projectileList.Add(new Projectile());
            }

            foreach (Projectile projectile in projectileList.Children)
            {
                projectile.Visible = false;
                projectileQueue.Enqueue(projectile);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            scoreFramecount++;
            if (scoreFramecount >= 60)
            {
                timeScore--;
                scoreFramecount = 0;
            }
            if (timeScore <= 0)
            {
                Die();
            }

            scoreText.Text = timeScore.ToString();

            #region Player & Projectile Platfrom Collision
            if (CollidesWithPlatform(player, out float collidedY) || player.climbingUp || player.climbingDown)
            {
                player.grounded = true;
            }
            else player.grounded = false;

            if(player.CollidesWith(timeUp) && timeUp.Visible)
            {
                timeScore += 200;
                timeUp.Visible = false;
            }


            foreach (Projectile projectile in projectileList.Children)
            {
                if (CollidesWithPlatform(projectile, out float collidedY2))
                {
                    projectile.grounded = true;
                }
                else projectile.grounded = false;


                if (projectile.CollidesWith(player))
                {
                    Damage();
                }

                foreach(SpriteGameObject barrel in barrels.Children)
                if (projectile.CollidesWith(barrel))
                {
                    projectile.Visible = false;
                    projectile.Position = new Vector2(0, 0);
                    projectileQueue.Enqueue(projectile);
                }
            }


            foreach (Platform platform in basePlatformRow.Children.Concat(finishPlatformRow.Children).Concat(platformRows.Children))
            {
                if (!player.climbingUp && !player.climbingDown)
                    if (player.CollidesWith(platform) && player.Position.Y + player.Sprite.Height > platform.Position.Y && player.Position.Y + player.Sprite.Height < platform.Position.Y + platform.Sprite.Height)
                    {
                        player.Position = new Vector2(player.Position.X, platform.Position.Y - player.Sprite.Height + 1);
                        player.grounded = true;
                    }

                foreach (Projectile projectile in projectileList.Children)
                    if (projectile.CollidesWith(platform) && projectile.Position.Y + projectile.Sprite.Height / 2 > platform.Position.Y && projectile.Position.Y + (projectile as RotatingSpriteGameObject).Sprite.Height / 2 < platform.Position.Y + platform.Sprite.Height)
                    {
                        projectile.Position = new Vector2(projectile.Position.X, platform.Position.Y - projectile.Sprite.Height / 2 + 1);
                        projectile.grounded = true;
                    }

            }

            #endregion

            finalScore = timeScore;

            if (player.CollidesWith(victory))
                GameEnvironment.GameStateManager.SwitchTo("WinState");


            if(player.Position.Y > GameEnvironment.Screen.Y)
            {
                Damage();
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


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            foreach (Ladder ladder in ladders.Children)
            {


                if (player.CollidesWith(ladder))
                {


                    if (inputHelper.IsKeyDown(Keys.W))
                    {
                        player.climbingDown = false;
                        player.climbingUp = true;
                        ladder.beingClimbed = true;
                    }
                    else if (inputHelper.IsKeyDown(Keys.S))
                    {
                        player.climbingUp = false;
                        player.climbingDown = true;
                        ladder.beingClimbed = true;
                    }
                    else
                    {
                        player.climbingDown = false;
                        player.climbingUp = false;
                    }
                }
                else ladder.beingClimbed = false;

                if (ladder.beingClimbed)
                    return;
                else if (!ladder.beingClimbed && (player.climbingUp || player.climbingDown))
                {
                    player.climbingDown = false;
                    player.climbingUp = false;
                }
            }
        }

        public void SpawnProjectile(Vector2 spawnPosition)
        {
            Projectile projectile;
            if (projectileQueue.Count != 0)
            {
                projectile = projectileQueue.Dequeue();
                projectile.grounded = true;
                projectile.Visible = true;
                projectile.Position = spawnPosition;
            }

        }

        public void Die()
        {
            Reset();
            GameEnvironment.GameStateManager.SwitchTo("GameOverState");
        }

        public void Damage()
        {
            player.Position = resetPoint;
            if (lives.Children.Count != 0)
                lives.Children.Remove(lives.Children[lives.Children.Count - 1]);

            if (lives.Children.Count == 0)
            {
                Die();
            }
        }

        public void Win()
        {

            GameEnvironment.GameStateManager.SwitchTo("WinState");
        }

        public override void Reset()
        {
            base.Reset();

            lives.Children.Clear();
            for (int i = 0; i < 3; i++)
            {
                lives.Add(new RotatingSpriteGameObject("life-temp"));
                (lives.Children[i] as RotatingSpriteGameObject).Degrees = 45;
                lives.Children[i].Position = new Vector2(30 + (lives.Children[i] as RotatingSpriteGameObject).Sprite.Width * i, 0);
            }

            timeScore = startTimeScore;

            timeUp.Visible = true;

            player.Position = resetPoint;

            foreach (Projectile projectile in projectileList.Children)
            {
                projectileQueue.Enqueue(projectile);
                projectile.Position = new Vector2(-1000, -1000);
            }

            frameCount = baseFrameCount;
        }
    }
}
