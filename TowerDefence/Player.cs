using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    internal class Player : Actor
    {
        int health;
        int wealth;

        static MouseState mouseState, previousMouseState;
        static KeyboardState keyboardState, previousKeyboardState;

        public Player()
        {
            this.texture = TextureManager.heartTexture;
            this.color = Color.Red;
            this.health = 1;
            this.position = new Vector2((Game1.windowSize.X - texture.Width) / 2, (Game1.windowSize.Y - texture.Height) / 2);
            this.hitbox = new Rectangle((int)position.X, (int)position.Y, 54, 48);
        }

        public override void Update(GameTime gameTime)
        {
            GetInputState();

            if (CanCreate())
                CreateTower();
        }

        public bool CanCreate()
        {
            if (!InputPressed(Keys.N))
                return false;

            foreach (Tower tower in Tower.towers)
                if (Tower.GetPreview(tower))
                    return false;

            return true;
        }

        public void CreateTower()
        {
            Tower tower = new Tower();
            Tower.towers.Add(tower);
            Debug.WriteLine("Tower Created.");
        }

        public void GetInputState()
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
        }

        public static bool InputPressed(Keys key)
        {
            if(keyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key))
                return true;

            return false;
        }
        
        public static bool InputPressed(int mouseButton)
        {
            switch (mouseButton)
            {
                case 1: 
                    if(mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                        return true;
                    break;
                case 2:
                    if (mouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
                        return true;
                    break;
                default:
                    Debug.WriteLine("Invalid Mouse Button Requested.");
                    break;
            }

            return false;
        }

        public static Vector2 GetMousePosition()
        {
            return new Vector2(mouseState.Position.X, mouseState.Position.Y);
        }
    }
}
