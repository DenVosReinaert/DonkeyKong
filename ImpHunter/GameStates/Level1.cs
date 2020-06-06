using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameStates
{
    class Level1 : PlayingState
    {

        private int frameCount;

        public Level1()
        {

            for(int i = 0; i < 16; i++)
            {
                basePlatformRow.Add(new Platform(new Vector2(50 * i, 780)));
            }

            for(int j = 0; j < 10; j++)
            {
                finishPlatformRow.Add(new Platform(new Vector2(50 * j, 160)));
            }

            for(int k = 0; k < 13; k++)
            {
                platformRows.Add(new Platform(new Vector2(50 * k, 640 + k*2)));
                platformRows.Add(new Platform(new Vector2(800 - 50 * k, 520 + k * 2)));
                platformRows.Add(new Platform(new Vector2(50 * k, 420 - k * 2)));
                platformRows.Add(new Platform(new Vector2(800 - 50 * k, 260 + k * 2)));
            }

            Add(player = new Player(new Vector2(0, 500)));

            projectiles.Add(projectile = new Projectile(new Vector2(20,100)));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); 
        }
    }
}
