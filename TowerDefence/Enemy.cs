using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    public class Enemy : Actor
    {
        public static List<Enemy> enemies = new();

        Rectangle sourceRectangle = new Rectangle(0, 0, 48, 48);

        IEnemyBehaviorType behavior;

        int health;
        float speed;

        double animationTimer;
        float animationTime;

        public int Health { get { return health; } set { health = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public float AnimationTime { get { return animationTime; } set { animationTime = value; } }

        // Default Enemy
        public Enemy()
        {
            this.texture = TextureManager.enemySpriteSheet;
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, 36, 42);
            this.position = DetermineEnemyStartPosition();

            this.speed = 25f;

            this.behavior = new BasicEnemy();

            this.velocity = speed * Vector2.Normalize((new Vector2(Game1.windowSize.X / 2, Game1.windowSize.Y / 2) - this.position));
            this.animationTime = speed * 10;
        }
        
        public Enemy(IEnemyBehaviorType behavior)
        {
            this.texture = TextureManager.enemySpriteSheet;
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, 36, 42);
            this.position = DetermineEnemyStartPosition();
            this.behavior = behavior;

            this.speed = 25f;

            behavior.Initialize(this);

            this.velocity = speed * Vector2.Normalize((new Vector2(Game1.windowSize.X / 2, Game1.windowSize.Y / 2) - this.position));
            this.animationTime = ((25*25)/speed) * 10;
        }

        public override void Update(GameTime gameTime)
        {
            HandleCollision();

            hitbox = new Rectangle((int)position.X, (int)position.Y, 36, 42);
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Animate(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, HitboxPosition, sourceRectangle, color, 0f, new Vector2((texture.Width/3 - hitbox.Width) / 2, (texture.Height - hitbox.Height) / 2), 1f, SpriteEffects.None, 1f);
            //DrawHitbox(spriteBatch);
        }

        public void HandleCollision()
        {
            foreach (Bullet bullet in Bullet.bullets.ToList())
            {
                if (bullet.Hitbox.Intersects(this.hitbox))
                {
                    Bullet.bullets.Remove(bullet);
                    health -= bullet.Damage;
                    if (health == 1)
                        texture = TextureManager.enemyHurtSpriteSheet;

                    behavior.OnDamage(this);
                }
            }

            // Remove all enemies that return a health value less than or equal to 0
            foreach (Enemy enemy in enemies)
            {
                if (enemy.health <= 0)
                    Game1.player.Wealth += 3;
            }

            enemies.RemoveAll(enemy => enemy.health <= 0);
        }

        public void Animate(GameTime gameTime)
        {
            animationTimer += gameTime.ElapsedGameTime.Milliseconds;

            if(animationTimer > animationTime) 
            { 
                animationTimer = 0;

                NewFrame();
            }
        }

        public void NewFrame()
        {
            if (sourceRectangle.X == 48)
                sourceRectangle.X = 96;
            else
                sourceRectangle.X = 48;
        }

        public Vector2 DetermineEnemyStartPosition()
        {
            int startPosition = Game1.random.Next(4);
            Vector2 defaultStartPosition = new Vector2(-texture.Width/3, (Game1.windowSize.Y - texture.Height) / 2);

            switch (startPosition)
            {
                case 0:
                    return new Vector2((Game1.windowSize.X - texture.Width/3) / 2, -texture.Height);
                case 1:
                    return new Vector2((Game1.windowSize.X - texture.Width/3) / 2, Game1.windowSize.Y);
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

    public interface IEnemyBehaviorType
    {
        void Initialize(Enemy enemy);

        void OnDamage(Enemy enemy)
        {
            
        }
    }

    public class FastEnemy : IEnemyBehaviorType
    {
        public void Initialize(Enemy enemy)
        {
            enemy.Speed *= 2.5f;
            enemy.Health = 1;
            enemy.Color = Color.CornflowerBlue;
        }
    }

    public class SlowEnemy : IEnemyBehaviorType
    {
        public void Initialize(Enemy enemy)
        {
            enemy.Speed /= 2;
            enemy.Health = 3;
            enemy.Color = Color.DarkOliveGreen;
        }

        public void OnDamage(Enemy enemy)
        {
            if (enemy.Health == 2)
                enemy.Color = Color.YellowGreen;
        }
    }

    public class AngryEnemy : IEnemyBehaviorType
    {
        public void Initialize(Enemy enemy)
        {
            enemy.Health = 2;
            enemy.Color = Color.LightCoral;
        }

        public void OnDamage(Enemy enemy)
        {
            enemy.Velocity *= 2;
            enemy.AnimationTime /= 2;
        }
    }

    public class BasicEnemy : IEnemyBehaviorType
    {
        public void Initialize(Enemy enemy)
        {
            enemy.Health = 2;
            enemy.Color = Color.Coral;
        }
    }
}
