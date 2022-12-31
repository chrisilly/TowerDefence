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
        }

        public Enemy(Vector2 position)
        {
            this.texture = TextureManager.enemyTexture;
            this.position = position;
        }
    }
}
