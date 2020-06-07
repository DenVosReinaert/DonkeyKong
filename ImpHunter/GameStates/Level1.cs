using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;

namespace ImpHunter.GameStates
{
    class Level1 : PlayingState
    {

        public Level1()
        {
            baseFrameCount = 120;

            startTimeScore = 120;

            barrel.Position = new Vector2(100, 780 - barrel.Sprite.Height);
            for (int i = 0; i < 16; i++)
            {
                basePlatformRow.Add(new Platform(new Vector2(50 * i, 780)));


                if (i < 3)
                {

                    ladders.Add(new Ladder(new Vector2(300, 615 - 41 * i)));
                    ladders.Add(new Ladder(new Vector2(800 - 50, 160 + 41 * i)));

                }
                ladders.Add(new Ladder(new Vector2(600, 740 - 41 * 2)));
                ladders.Add(new Ladder(new Vector2(600, 520 - 41 * 3)));
                ladders.Add(new Ladder(new Vector2(0, 286)));




                if (i < 10)
                    finishPlatformRow.Add(new Platform(new Vector2(50 * i, 160)));
                finishPlatformRow.Add(new Platform(new Vector2(800 - 50, 160)));
                finishPlatformRow.Add(new Platform(new Vector2(800 - 50 * 3, 160)));


                if (i < 13)
                {
                    platformRows.Add(new Platform(new Vector2(50 * i, 640 + i * 2)));
                    platformRows.Add(new Platform(new Vector2(800 - 50 * i, 520 + i * 2)));
                    platformRows.Add(new Platform(new Vector2(50 * i, 420 - i * 2)));
                    platformRows.Add(new Platform(new Vector2(800 - 50 * i, 260 + i * 2)));
                }
                platformRows.Add(new Platform(new Vector2(0, 286)));

            }

            resetPoint = new Vector2(0, 780 - player.Sprite.Height);

            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            frameCount++;

            if (projectileQueue.Count != 0)
            {
                if (frameCount > 120)
                {
                    SpawnProjectile(new Vector2(20, 130));
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
