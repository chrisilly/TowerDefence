using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    internal class Tower : Actor
    {
        public static List<Tower> towers = new();

        float bulletSpeed;
        float fireRate;
        double fireCooldownTimer;
        bool autoFire;

        bool preview;

        MouseState mouseState;
        MouseState previousMouseState;
        KeyboardState keyboardState;
        KeyboardState previousKeyboardState;

        public Tower()
        {
            this.texture = TextureManager.towerTexture;
            this.bulletSpeed = 200f;
            this.fireRate = 3f;
            this.fireCooldownTimer = fireRate;
            this.preview = true;
        }

        public override void Update(GameTime gameTime)
        {
            GetInputState();

            CreateTower();

            if(preview)
                HandlePreview();
            else
                AutoFire(gameTime);
        }

        public void Shoot()
        {
            Vector2 direction = GetShortestTrajectory();
            Bullet bullet = new Bullet(position, bulletSpeed, direction);
            Bullet.bullets.Add(bullet);
        }

        // Aim for the nearest enemy
        public Vector2 GetShortestTrajectory()
        {
            Vector2 shortestPath = Vector2.Zero;

            foreach (Enemy enemy in Enemy.enemies)
            {
                Vector2 pathToEnemy = enemy.Position - this.position;
                if(shortestPath == Vector2.Zero)
                {
                    shortestPath = pathToEnemy;
                }
                else if(pathToEnemy.Length() < shortestPath.Length())
                {
                    shortestPath = pathToEnemy;
                }
            }

            return Vector2.Normalize(shortestPath);
        }

        // Fire a bullet every couple of seconds
        public void AutoFire(GameTime gameTime)
        {
            fireCooldownTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(fireCooldownTimer >= fireRate && Enemy.enemies.Count != 0)
            {
                fireCooldownTimer = 0;
                Shoot();
            }
        }

        public void HandlePreview()
        {
            this.position = new Vector2(mouseState.Position.X, mouseState.Position.Y);
            if(mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                preview = !preview;
        }

        public bool CanCreate()
        {
            foreach (Tower tower in towers)
                if (tower.preview || !(keyboardState.IsKeyDown(Keys.N) && previousKeyboardState.IsKeyUp(Keys.N)))
                    return false;

            return true;
        }

        public void CreateTower()
        {
            if (CanCreate())
            {
                Tower tower = new Tower();
                towers.Add(tower);
                Debug.WriteLine("Tower Created.");
            }
        }

        public void GetInputState()
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
        }
    }
}
