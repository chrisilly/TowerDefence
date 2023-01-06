using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    public abstract class Actor
    {
        protected Texture2D texture;
        public Texture2D Texture { get { return texture; } }
        protected Vector2 velocity;

        protected Vector2 position;
        public Vector2 Position { get { return position; } }

        protected Rectangle hitbox;
        public Rectangle Hitbox { get { return hitbox; } }
        public Vector2 HitboxPosition { get { return new Vector2(hitbox.X, hitbox.Y); } }

        protected Color color = Color.White;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, color);
            //DrawHitbox(spriteBatch);
        }

        public void DrawHitbox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.hitboxTexture, hitbox, Color.Green * 0.5f);
        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
