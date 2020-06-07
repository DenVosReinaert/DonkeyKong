using Microsoft.Xna.Framework;

namespace ImpHunter.GameObjects
{
    class Platform : SpriteGameObject
    {
        public Platform(Vector2 position) : base("platform-temp")
        {
            this.position = position;
        }

    }
}
