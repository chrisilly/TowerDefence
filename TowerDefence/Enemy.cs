using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    internal class Enemy : Actor
    {
        public static List<Enemy> enemies = new();

        int health;
        float speed;

        public Enemy()
        {
            this.texture = TextureManager.enemyTexture;
            this.hitbox = new Rectangle(0, 0, 40, 72);
        }

        public Enemy(Vector2 startPosition)
        {
            this.texture = TextureManager.enemyTexture;
            this.position = startPosition;
            this.health = 1;
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, 40, 72);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            HandleCollision();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, HitboxPosition, null, Color.White, 0f, new Vector2((texture.Width - hitbox.Width) / 2, (texture.Height - hitbox.Height) / 2), 1f, SpriteEffects.None, 1f);
            //DrawHitbox(spriteBatch);
        }

        public void HandleCollision()
        {
            foreach (Bullet bullet in Bullet.bullets.ToList())
            {
                if (bullet.Hitbox.Intersects(this.hitbox))
                {
                    Bullet.bullets.Remove(bullet);
                    health--;
                }
            }

            // Remove all enemies that return a health value less than or equal to 0
            enemies.RemoveAll(enemy => enemy.health <= 0);
        }
    }
}
