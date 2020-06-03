using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameStates
{

     public class PlayingState : GameObjectList
    {
        public GameObjectList basePlatformRow;
        public GameObjectList platformRows;
        public GameObjectList finishPlatformRow;

        Player player;

        public PlayingState()
        {
            Add(basePlatformRow = new GameObjectList());
            Add(platformRows = new GameObjectList());
            Add(finishPlatformRow = new GameObjectList());

            Add(player = new Player());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach(Platform platform in basePlatformRow.Children.Concat(finishPlatformRow.Children).Concat(platformRows.Children))
            {
                if (platform.CollidesWith(player))
                {
                    player.grounded = true;
                }
                else 
                    player.grounded = false;
            }

        }

    }
}
