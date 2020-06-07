using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;

namespace ImpHunter.GameStates
{
    class Level1 : PlayingState
    {

        private int frameCount;

        public Level1()
        {



            for (int i = 0; i < 16; i++)
            {
                basePlatformRow.Add(new Platform(new Vector2(50 * i, 780)));


                if (i < 3)
                {
                    ladders.Add(new Ladder(new Vector2(600, 740 - 41 * i)));
                    ladders.Add(new Ladder(new Vector2(300, 615 - 41 * i)));
                    ladders.Add(new Ladder(new Vector2(200, 520 - 41 * i)));
                }



                if (i < 10)
                    finishPlatformRow.Add(new Platform(new Vector2(50 * i, 160)));

                if (i < 13)
                {
                    platformRows.Add(new Platform(new Vector2(50 * i, 640 + i * 2)));
                    platformRows.Add(new Platform(new Vector2(800 - 50 * i, 520 + i * 2)));
                    platformRows.Add(new Platform(new Vector2(50 * i, 420 - i * 2)));
                    platformRows.Add(new Platform(new Vector2(800 - 50 * i, 260 + i * 2)));
                }
            }



            Add(player = new Player(new Vector2(0, 500)));

            projectiles.Add(projectile = new Projectile(new Vector2(20, 100)));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
