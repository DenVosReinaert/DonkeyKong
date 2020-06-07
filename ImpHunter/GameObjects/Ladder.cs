using Microsoft.Xna.Framework;

namespace ImpHunter.GameObjects
{
    class Ladder : SpriteGameObject
    {
        public bool beingClimbed = false;
        public Ladder(Vector2 position) : base("ladder-temp")
        {
            Position = position;
        }

    }
}
