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
        int health;
        float speed;

        public Enemy(Texture2D texture) : base(texture)
        {

        }
    }
}
