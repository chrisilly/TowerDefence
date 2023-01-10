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

    public class Tower : Actor
    {
        public static List<Tower> towers = new();
        List<ITowerBehaviour> behaviors;

        float bulletSpeed;
        int bulletDamage;
        float fireRate;
        double fireCooldownTimer;
        bool selected;

        public float BulletSpeed { get { return bulletSpeed; } set { bulletSpeed = value; } }
        public int BulletDamage { get { return bulletDamage; } set { bulletDamage = value; } }
        public float FireRate { get { return fireRate; } set { fireRate = value; } }

        bool preview;

        public Tower()
        {
            this.texture = TextureManager.towerTexture;
            this.position = Player.GetMousePosition();
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            this.bulletSpeed = 200f;
            this.bulletDamage = 1;
            this.fireRate = 3f;
            this.fireCooldownTimer = fireRate;

            this.behaviors = new List<ITowerBehaviour>();

            this.preview = true;
            this.color = Color.DarkGray * 0.5f;
        }
        
        public Tower(List<ITowerBehaviour> behaviors)
        {
            this.texture = TextureManager.towerTexture;
            this.position = Player.GetMousePosition();
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            this.behaviors = new List<ITowerBehaviour> { new DefaultTower() };

            foreach (ITowerBehaviour behavior in behaviors)
                this.behaviors.Add(behavior);

            foreach(ITowerBehaviour behavior in behaviors)
            {
                behavior.Initialize(this);
            }

            this.fireCooldownTimer = fireRate;

            this.preview = true;
            this.color *= 0.5f;
        }

        public override void Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (preview)
                HandlePreview();
            else
            {
                AutoFire(gameTime);
                HandleSelection();
                HandlePurchasing();
            }
        }

        public void Shoot()
        {
            Vector2 direction = GetShortestTrajectory();
            Bullet bullet = new Bullet(position, bulletSpeed, direction, bulletDamage);
            Bullet.bullets.Add(bullet);
        }

        // Aim for the nearest enemy
        public Vector2 GetShortestTrajectory()
        {
            Vector2 shortestPath = Vector2.Zero;

            foreach (Enemy enemy in Enemy.enemies)
            {
                Vector2 pathToEnemy = new Vector2(enemy.Position.X + enemy.Texture.Width/3 / 2, enemy.Position.Y + enemy.Texture.Height / 2) - this.position;
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

            if(CanPlace())
            {
                color = Color.DarkGray * 0.5f;

                if (Player.InputPressed(1))
                {
                    preview = false;
                    color = color * (1/0.5f);
                }
            }
            else
            {
                color = Color.Red * 0.5f;
            }
        }

        public bool CanPlace()
        {
            if (hitbox.Intersects(Game1.EnemyPathX) || hitbox.Intersects(Game1.EnemyPathY))
                return false;

            foreach (Tower tower in towers)
            {
                if (tower == this)
                    continue;

                else if (this.hitbox.Intersects(tower.hitbox))
                    return false;
            }

            if (position.X < 0 || position.X > Game1.windowSize.X - texture.Width)
                return false;
            else if (position.Y < 0 || position.Y > Game1.windowSize.Y - texture.Height)
                return false;

            return true;
        }

        public static bool CreatingTower()
        {
            foreach (Tower tower in towers)
                if (tower.preview)
                    return true;

            return false;
        }

        public void HandlePurchasing()
        {
            SellTower();
            IncreaseFireRate();
            IncreaseDamage();
            IncreaseProjectileSpeed();
        }

        public void SellTower()
        {
            bool sellTowerPressed = Game1.userInterfaceForm.sellTowerPressed;
            Game1.userInterfaceForm.sellTowerPressed = false;

            if (sellTowerPressed)
            {
                towers.RemoveAll(tower => tower.selected);
            }
        }

        public void ApplyModifier(ITowerBehaviour behavior, Tower tower)
        {
            behavior.Initialize(tower);
        }

        public void IncreaseFireRate()
        {
            bool fireRateUpgradePressed = Game1.userInterfaceForm.fireRateUpgradePressed;
            Game1.userInterfaceForm.fireRateUpgradePressed = false;

            if(fireRateUpgradePressed)
            {
                foreach (Tower tower in towers)
                {
                    if (tower.selected)
                    {
                        ApplyModifier(new FastTower(), tower);
                    }
                }
            }
        }

        public void IncreaseDamage()
        {
            bool damageUpgradePressed = Game1.userInterfaceForm.damageUpgradePressed;
            Game1.userInterfaceForm.damageUpgradePressed = false;

            if (damageUpgradePressed)
            {
                foreach (Tower tower in towers)
                {
                    if (tower.selected)
                    {
                        ApplyModifier(new DamagingTower(), tower);
                    }
                }
            }

        }

        public void IncreaseProjectileSpeed()
        {
            bool projectileSpeedUpgradePressed = Game1.userInterfaceForm.projectileSpeedUpgradePressed;
            Game1.userInterfaceForm.projectileSpeedUpgradePressed = false;

            if (projectileSpeedUpgradePressed)
            {
                foreach (Tower tower in towers)
                {
                    if (tower.selected)
                    {
                        ApplyModifier(new FastProjectileTower(), tower);
                    }
                }
            }
        }

        public void HandleSelection()
        {
            if (!Player.ClickedOn(this.hitbox, 1) && Player.InputPressed(1) && Player.MouseWithinBounds())
            {
                color = Color.DarkGray;
                selected = false;
            }
            else if (Player.ClickedOn(this.hitbox, 1))
            {
                color = Color.LightGreen;
                selected = true;
            }
            else if (Player.IsMouseHovering(this.hitbox) && selected == false)
            {
                color = Color.Yellow;
            }
            else if(selected == false)
            {
                color = Color.DarkGray;
            }
        }
    }

    public interface ITowerBehaviour
    {
        void Initialize(Tower tower)
        {

        }
    }

    public class DefaultTower : ITowerBehaviour
    {
        public void Initialize(Tower tower)
        {
            tower.BulletSpeed = 200f;
            tower.BulletDamage = 1;
            tower.FireRate = 3f;
            tower.Color = Color.DarkGray;
        }
    }

    public class FastTower : ITowerBehaviour
    {
        public void Initialize(Tower tower)
        {
            tower.FireRate /= 2;
            //tower.Color = Color.LightBlue;
        }
    }

    public class DamagingTower : ITowerBehaviour
    {
        public void Initialize(Tower tower)
        {
            tower.BulletDamage += 1;
            //tower.Color = Color.Red;
        }
    }

    public class FastProjectileTower : ITowerBehaviour
    {
        public void Initialize(Tower tower)
        {
            tower.BulletSpeed *= 2;
            //tower.Color = Color.Yellow;
        }
    }
}
