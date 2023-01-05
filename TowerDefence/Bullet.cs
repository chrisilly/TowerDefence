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
            this.hitbox = new Rectangle((int)startPosition.X, (int)startPosition.Y, 6, 6);
            this.color = Color.Yellow;
        }

        public override void Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, 6, 6);
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Remove out of bounds bullets
            bullets.RemoveAll(bullet => bullet.position.X <= 0 || bullet.position.X >= Game1.windowSize.X || bullet.position.Y <= 0 || bullet.position.Y >= Game1.windowSize.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, HitboxPosition, null, color, 0f, new Vector2((texture.Width-hitbox.Width)/2, (texture.Height-hitbox.Height)/2), 1f, SpriteEffects.None, 1f);
            //DrawHitbox(spriteBatch);
        }
    }
}
