using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpHunter.GameStates;
using DonkeyKong;
namespace ImpHunter.GameStates
{
    class TitleScreenState : GameObjectList
    {

        public TitleScreenState()
        {
            Add(new SpriteGameObject("MaliciousCompliance-temp"));
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if(inputHelper.AnyKeyPressed)
            {
                GameEnvironment.GameStateManager.SwitchTo("Level1");
            }
        }

    }
}
