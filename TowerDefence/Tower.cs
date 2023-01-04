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
    enum TowerType { Auto, Manual, Special }

    internal class Tower : Actor
    {
        public static List<Tower> towers = new();

        float bulletSpeed;
        float fireRate;
        double fireCooldownTimer;
        bool autoFire;

        bool preview;

        public Tower()
        {
            this.texture = TextureManager.towerTexture;
            this.position = Player.GetMousePosition();

            this.bulletSpeed = 200f;
            this.fireRate = 3f;
            this.fireCooldownTimer = fireRate;

            this.preview = true;
            this.color = Color.DarkGray * 0.5f;
        }

        public override void Update(GameTime gameTime)
        {
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
            this.position = Player.GetMousePosition();

            if (Player.InputPressed(2))
                towers.Remove(this);

            if(Player.InputPressed(1) && CanPlace())
            {
                preview = false;
                color = Color.DarkGray;
            }
        }

        public bool CanPlace()
        {
            return true;
        }

        public static bool GetPreview(Tower tower)
        {
            return tower.preview;
        }
    }
}
