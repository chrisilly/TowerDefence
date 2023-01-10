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
    public class Player : Actor
    {
        int health;
        int wealth;
        int specialEnemyChance = 16;

        public int Health { get { return health; } set { health = value; } }
        public int Wealth { get { return wealth; } set { wealth = value; } }

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
            
            this.spawnCooldown = 4f;
            this.spawnCooldownTimer = spawnCooldown;
        }

        public override void Update(GameTime gameTime)
        {
            GetInputState();

            UpdateDisplayedGold();

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
            //if (!InputPressed(Keys.N))
            //    return false;

            if (Tower.CreatingTower())
                return false;

            if (!Game1.userInterfaceForm.buyTowerPressed)
                return false;

            if (wealth < 10)
                return false;

            Game1.userInterfaceForm.buyTowerPressed = false;

            return true;
        }

        public void CreateTower()
        {
            Tower tower = new Tower();
            Tower.towers.Add(tower);
            Debug.WriteLine("Tower Created.");
            wealth -= 10;
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

        public void UpdateDisplayedGold()
        {
            Game1.userInterfaceForm.wealthAmountLabel.Text = wealth.ToString();
        }

        public void Reset()
        {
            health = 2;
            wealth = 10;
            color = Color.Red;
            specialEnemyChance = 16;
            spawnCooldown = 4f;
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

        public static bool MouseWithinBounds()
        {
            if (GetMousePosition().X < 0 || GetMousePosition().X > Game1.windowSize.X)
                return false;
            else if (GetMousePosition().Y < 0 || GetMousePosition().Y > Game1.windowSize.Y)
                return false;

            return true;
        }

        public static bool IsMouseHovering(Rectangle hitbox)
        {
            if (GetMousePosition().X < hitbox.X || GetMousePosition().X > (hitbox.X + hitbox.Width))
                return false;

            else if (GetMousePosition().Y < hitbox.Y || GetMousePosition().Y > (hitbox.Y + hitbox.Height))
                return false;

            return true;
        }

        public static bool ClickedOn(Rectangle hitbox, int mouseButton)
        {
            if (IsMouseHovering(hitbox))
                if (InputPressed(mouseButton))
                    return true;

            return false;
        }
    }
}
