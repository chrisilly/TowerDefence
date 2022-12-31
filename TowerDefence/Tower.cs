using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    internal class Tower : Actor
    {
        public static List<Tower> towers = new();

        float bulletSpeed;
        float fireRate;
        double fireCooldownTimer;
        bool autoFire;

        public Tower()
        {
            this.texture = TextureManager.towerTexture;
            this.bulletSpeed = 200f;
            this.fireRate = 3f;
            this.fireCooldownTimer = fireRate;
        }

        public override void Update(GameTime gameTime)
        {
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
    }
}
