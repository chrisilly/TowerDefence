using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Bullet : Actor
    {
        public static List<Bullet> bullets = new();

        public Bullet(Vector2 startPosition, float speed, Vector2 direction)
        {
            this.texture = TextureManager.bulletTexture;
            this.position = startPosition;
            this.velocity = speed * direction;
        }

        public override void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
