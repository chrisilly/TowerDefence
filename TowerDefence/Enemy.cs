using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    enum EnemyType { Simple, Heavy, Sneaky, Speedy }

    internal class Enemy : Actor
    {
        public static List<Enemy> enemies = new();

        int health;
        float speed;

        public Enemy()
        {
            this.texture = TextureManager.enemyTexture;
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, 36, 42);
            this.position = DetermineEnemyStartPosition();
            this.health = 1;
            this.color = Color.Red;

            this.speed = 25f;
            this.velocity = speed * Vector2.Normalize((new Vector2(Game1.windowSize.X / 2, Game1.windowSize.Y / 2) - this.position));
        }

        public Enemy(Vector2 startPosition)
        {
            this.texture = TextureManager.enemyTexture;
            this.position = startPosition;
            this.health = 1;
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, 36, 42);
            this.color = Color.Red;
        }

        public override void Update(GameTime gameTime)
        {
            HandleCollision();

            hitbox = new Rectangle((int)position.X, (int)position.Y, 36, 42);
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, HitboxPosition, null, color, 0f, new Vector2((texture.Width - hitbox.Width) / 2, (texture.Height - hitbox.Height) / 2), 1f, SpriteEffects.None, 1f);
            DrawHitbox(spriteBatch);
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

        public Vector2 DetermineEnemyStartPosition()
        {
            int startPosition = Game1.random.Next(4);
            Vector2 defaultStartPosition = new Vector2(-texture.Width, (Game1.windowSize.Y - texture.Height) / 2);

            switch (startPosition)
            {
                case 0:
                    return new Vector2((Game1.windowSize.X - texture.Width) / 2, -texture.Height);
                case 1:
                    return new Vector2((Game1.windowSize.X - texture.Width) / 2, Game1.windowSize.Y);
                case 2:
                    return defaultStartPosition;
                case 3:
                    return new Vector2(Game1.windowSize.X, (Game1.windowSize.Y - texture.Height) / 2);
                default:
                    Debug.WriteLine("Invalid Spawn Request: Enemy.cs 'DetermineStartPosition()'");
                    break;
            }

            return defaultStartPosition;
        }
    }
}
