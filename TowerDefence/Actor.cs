using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    internal class Actor
    {
        protected Texture2D texture;
        protected Vector2 position;

        public Actor(Texture2D texture)
        {
            this.texture = texture;
        }
    }
}
