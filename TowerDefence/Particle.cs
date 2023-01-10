using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class Particle
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Color Color { get; set; }
        public int TimeToLive { get; set; }

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, Color color, int timeToLive)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Color = color;
            TimeToLive = timeToLive;
        }

        public void Update()
        {
            TimeToLive--;
            Position += Velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color);
        }
    }
}
