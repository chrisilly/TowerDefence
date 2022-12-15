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
        float fireRate;
        bool autoFire;

        public Tower(Texture2D texture) : base(texture)
        {

        }
    }
}
