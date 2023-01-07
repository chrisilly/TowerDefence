using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    internal class Player : Actor
    {
        int health;
        int wealth;
        int specialEnemyChance = 16;

        static MouseState mouseState, previousMouseState;
        static KeyboardState keyboardState, previousKeyboardState;

        double spawnCooldownTimer;
        float spawnCooldown;

        public Player()
        {
            this.texture = TextureManager.heartTexture;
            this.color = Color.Red;
            this.health = 2;
            this.position = new Vector2((Game1.windowSize.X - texture.Width) / 2, (Game1.windowSize.Y - texture.Height) / 2);
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, 54, 48);
            spawnCooldown = 4f;
            spawnCooldownTimer = spawnCooldown;
        }

        public override void Update(GameTime gameTime)
        {
            GetInputState();

            switch (Game1.gameState)
            {
                case GameStates.Menu:
                    break;
                case GameStates.Play:
                    SpawnEnemies(gameTime);

                    if (CanCreate())
                        CreateTower();

                    if (Collision())
                    {
                        health--;
                        if (health == 1)
                            StartSecondWave();
                        if (health <= 0)
                            Game1.gameState = GameStates.End;
                    }
                    break;
                case GameStates.End:
                    break;
                default:
                    break;
            }
        }

        public bool Collision()
        {
            foreach(Enemy enemy in Enemy.enemies)
            {
                if (enemy.Hitbox.Intersects(this.hitbox))
                {
                    return true;
                }
            }

            return false;
        }

        public void StartSecondWave()
        {
            Enemy.enemies.Clear();
            Bullet.bullets.Clear();
            color = Color.Blue;
            specialEnemyChance -= 4;
            spawnCooldown = 2.75f;
        }

        public bool CanCreate()
        {
            if (!InputPressed(Keys.N))
                return false;

            foreach (Tower tower in Tower.towers)
                if (Tower.GetPreview(tower))
                    return false;

            return true;
        }

        public void CreateTower()
        {
            Tower tower = new Tower();
            Tower.towers.Add(tower);
            Debug.WriteLine("Tower Created.");
        }

        public void SpawnEnemies(GameTime gameTime)
        {
            spawnCooldownTimer -= gameTime.ElapsedGameTime.TotalSeconds;

            if(spawnCooldownTimer <= 0)
            {
                spawnCooldownTimer = spawnCooldown;
                CreateEnemy();
            }
        }

        public void CreateEnemy()
        {
            IEnemyBehaviorType enemyType;
            int chance = Game1.random.Next(specialEnemyChance);

            switch (chance)
            {
                case 0:
                    enemyType = new FastEnemy();
                    break;
                case 1:
                    enemyType = new SlowEnemy();
                    break;
                case 2:
                    enemyType = new AngryEnemy();
                    break;
                default:
                    enemyType = new BasicEnemy();
                    break;
            }

            Enemy enemy = new Enemy(enemyType);
            Enemy.enemies.Add(enemy);
        }

        public void GetInputState()
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
        }

        public static bool InputPressed(Keys key)
        {
            if(keyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key))
                return true;

            return false;
        }
        
        public static bool InputPressed(int mouseButton)
        {
            switch (mouseButton)
            {
                case 1: 
                    if(mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                        return true;
                    break;
                case 2:
                    if (mouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
                        return true;
                    break;
                default:
                    Debug.WriteLine("Invalid Mouse Button Requested.");
                    break;
            }

            return false;
        }

        public static Vector2 GetMousePosition()
        {
            return new Vector2(mouseState.Position.X, mouseState.Position.Y);
        }
    }
}
