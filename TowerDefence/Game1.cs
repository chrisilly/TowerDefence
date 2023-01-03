using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerDefence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static Point windowSize { get; private set; }

        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            windowSize = new Point(1280, 720);
            graphics.PreferredBackBufferWidth = windowSize.X;
            graphics.PreferredBackBufferHeight = windowSize.Y;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureManager.LoadContent(Content);

            StartGame();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            // ToList() iterates over a copy of the enemies list so as to not cause error when modifying the original list. Bad for large collections => performance hit.
            foreach (Enemy enemy in Enemy.enemies.ToList())
                enemy.Update(gameTime);

            foreach (Tower tower in Tower.towers.ToList())
                tower.Update(gameTime);

            foreach (Bullet bullet in Bullet.bullets)
                bullet.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            player.Draw(spriteBatch);

            foreach (Enemy enemy in Enemy.enemies)
                enemy.Draw(spriteBatch);

            foreach (Tower tower in Tower.towers)
                tower.Draw(spriteBatch);

            foreach (Bullet bullet in Bullet.bullets)
                bullet.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void StartGame()
        {
            player = new Player();

            Enemy enemy = new Enemy(new Vector2(200, 200));
            Enemy.enemies.Add(enemy);

            Enemy enemy2 = new Enemy(new Vector2(290, 0));
            Enemy.enemies.Add(enemy2);
        }
    }
}