using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerDefence
{
    public enum GameStates { Menu, Play, End }

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static Point windowSize { get; private set; }
        public static Random random = new();

        Player player;

        public static GameStates gameState;

        static Rectangle enemyPathX;
        static Rectangle enemyPathY;
        public static Rectangle EnemyPathX { get { return enemyPathX; } }
        public static Rectangle EnemyPathY { get { return enemyPathY; } }

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

            enemyPathX = new Rectangle(0, (windowSize.Y - 100) / 2, windowSize.X, 100);
            enemyPathY = new Rectangle((windowSize.X - 100) / 2, 0, 100, windowSize.Y);

            gameState = GameStates.Play;

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

            switch (gameState)
            {
                case GameStates.Menu:
                    break;
                case GameStates.Play:
                    player.Update(gameTime);

                    // ToList() iterates over a copy of the enemies list so as to not cause error when modifying the original list. Bad for large collections => performance hit.
                    foreach (Enemy enemy in Enemy.enemies.ToList())
                        enemy.Update(gameTime);

                    foreach (Tower tower in Tower.towers.ToList())
                        tower.Update(gameTime);

                    foreach (Bullet bullet in Bullet.bullets.ToList())
                        bullet.Update(gameTime);
                    break;
                case GameStates.End:
                    break;
                default:
                    break;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(TextureManager.backgroundTexture, Vector2.Zero, Color.White);

            player.Draw(spriteBatch);

            //DrawHitboxes();

            foreach (Enemy enemy in Enemy.enemies)
                enemy.Draw(spriteBatch);

            foreach (Tower tower in Tower.towers)
                tower.Draw(spriteBatch);

            foreach (Bullet bullet in Bullet.bullets)
                bullet.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawHitboxes()
        {
            spriteBatch.Draw(TextureManager.hitboxTexture, enemyPathX, Color.Green * 0.5f);
            spriteBatch.Draw(TextureManager.hitboxTexture, enemyPathY, Color.Green * 0.5f);
        }

        public void StartGame()
        {
            player = new Player();
        }
    }
}