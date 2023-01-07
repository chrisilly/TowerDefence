using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public enum UpgradeType { FireRate, Damage, BulletSpeed }

    internal class Upgrade : Actor
    {
        public static Upgrade[] upgrades;
        Rectangle sourceRectangle;

        UpgradeType upgradeType;
        bool choosingUpgrade;

        public Upgrade(UpgradeType upgradeType)
        {
            this.texture = TextureManager.towerUpgradeSpriteSheet;
            this.sourceRectangle = new Rectangle(0, 0, 12, 16);
            this.hitbox = new Rectangle(0, 0, 12, 16);
            this.upgradeType = upgradeType;
        }

        public void ChooseNewUpgrade()
        {
            int margin = 16;

            Upgrade fireRate = new(UpgradeType.FireRate);
            Upgrade damage = new(UpgradeType.Damage);
            Upgrade bulletSpeed = new(UpgradeType.BulletSpeed);

            upgrades = new Upgrade[] { fireRate, damage, bulletSpeed };

            upgrades[0].position = new Vector2(Game1.windowSize.X / 2 - texture.Width / 3 / 2 - (texture.Width/3 + margin), Game1.windowSize.Y / 2 - texture.Height / 2);
            upgrades[1].position = new Vector2(Game1.windowSize.X/2 - texture.Width/3/2, Game1.windowSize.Y/2 - texture.Height/2);
            upgrades[2].position = new Vector2(Game1.windowSize.X / 2 - texture.Width / 3 / 2 + (texture.Width / 3 + margin), Game1.windowSize.Y / 2 - texture.Height / 2);

            choosingUpgrade = true;

            while (choosingUpgrade)
            {
                ChooseUpgrade();
            }
        }

        public void ChooseUpgrade()
        {
            if (Player.IsMouseHovering(this.hitbox))
            {
                if (Player.InputPressed(1))
                {
                    // Apply effect to tower
                    choosingUpgrade = false;
                }
                else if (Player.InputPressed(2))
                {
                    // Cancel upgrade action
                    choosingUpgrade = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (choosingUpgrade)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}
