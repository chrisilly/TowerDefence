using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    public class Actor
    {
        protected Texture2D texture;
        protected Vector2 position;
        public Vector2 Position { get { return position; } }
        protected Vector2 velocity;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
