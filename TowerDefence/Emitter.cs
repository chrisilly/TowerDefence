using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class Emitter
    {
        private Random random;
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        List<Particle> particles;

        public Emitter(Texture2D texture, Vector2 position)
        {
            Position = position;
            this.Texture = texture;
            this.particles = new List<Particle>();
            random = new Random();    
            
        }

        public void Update()
        {
            int total = 1;

            for (int i = 0; i < total; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TimeToLive <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch);
            }
        }

        public Particle GenerateNewParticle()
        {
            Texture2D texture = Texture;
            Vector2 position = Position;
            Vector2 velocity = new Vector2(
                1f * (float)(random.NextDouble() * 2-1),
                1f * (float)(random.NextDouble() * 2 - 1));
            Color color = Color.Orange;
            int timeToLive = 20 + random.Next(10);

            return new Particle(texture, position, velocity, color, timeToLive);
        }
    }
}
