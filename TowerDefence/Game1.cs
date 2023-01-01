﻿using Microsoft.Xna.Framework;
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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureManager.LoadContent(Content);

            SpawnObjects();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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

            foreach (Enemy enemy in Enemy.enemies)
                enemy.Draw(spriteBatch);

            foreach (Tower tower in Tower.towers)
                tower.Draw(spriteBatch);

            foreach (Bullet bullet in Bullet.bullets)
                bullet.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SpawnObjects()
        {
            Tower tower = new Tower();
            Tower.towers.Add(tower);

            Enemy enemy = new Enemy(new Vector2(200, 200));
            Enemy.enemies.Add(enemy);

            Enemy enemy2 = new Enemy(new Vector2(290, 0));
            Enemy.enemies.Add(enemy2);
        }
    }
}