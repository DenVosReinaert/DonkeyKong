using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameStates
{
    class Level2 : PlayingState
    {

        public Level2()
        {
            baseFrameCount = 120;

            startTimeScore = 120;

            barrel0.Position = new Vector2(150, 780 - barrel0.Sprite.Height);
            barrel1.Position = new Vector2(GameEnvironment.Screen.X - 150 - barrel1.Sprite.Width, 780 - barrel1.Sprite.Height);

            timeUp.Position = new Vector2(GameEnvironment.Screen.X - timeUp.Sprite.Width, 400);


            for (int i = 0; i < 16; i++)
            {
                if(i < 5)
                {
                    platformRows.Add(new Platform(new Vector2((GameEnvironment.Screen.X/5 + 29)*i, 320)));
                    platformRows.Add(new Platform(new Vector2((GameEnvironment.Screen.X / 5 + 29) * i, 600)));
                }

                if (i < 4)
                {
                    basePlatformRow.Add(new Platform(new Vector2(50 * i, 780)));
                    basePlatformRow.Add(new Platform(new Vector2(GameEnvironment.Screen.X - 50 - 50*i, 780)));

                    finishPlatformRow.Add(new Platform(new Vector2(0 + 50 * i, 160)));
                    finishPlatformRow.Add(new Platform(new Vector2(GameEnvironment.Screen.X - 50 - 50 * i, 160)));

                    for (int j = 0; j < 9; j++)
                    {
                        ladders.Add(new Ladder(new Vector2(82 + 200 * i, GameEnvironment.Screen.Y - 150 - 41 * j)));
                    }

                    ladders.Add(new Ladder(new Vector2(GameEnvironment.Screen.X / 2 - 17, 280 - 41 * i)));
                }

                if (i < 3)
                {

                    finishPlatformRow.Add(new Platform(new Vector2(GameEnvironment.Screen.X/2 - 72 + 50 * i, 160)));

                }

                if(i < 2)
                {
                    platformRows.Add(new Platform(new Vector2(GameEnvironment.Screen.X/2 - 75 + 105*i, 320)));
                }
            }

            victory.Position = new Vector2(GameEnvironment.Screen.X/2 + 5 - victory.Sprite.Width/2, 160 - victory.Sprite.Height);





            resetPoint = new Vector2(0, 780 - player.Sprite.Height);

            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            frameCount++;

            if (projectileQueue.Count != 0)
            {
                if (frameCount > 90)
                {
                    SpawnProjectile(new Vector2(20, 130));
                    SpawnProjectile(new Vector2(GameEnvironment.Screen.X - 20, 130));
                    frameCount = 0;
                }
            }
            else
            {
                SpawnProjectile(new Vector2(20, 130));
                frameCount = 0;
            }
        }
    }
}
