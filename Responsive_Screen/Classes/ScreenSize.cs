using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Responsive_Screen
{
    class ScreenSize
    {
        // Attributs
        static ScreenSize instance;

        private Vector2 _size;
        public Vector2 Size 
        { 
            get => _size;
        }

        // Ctor
        protected ScreenSize(Vector2 size)
        {
            this._size = size;
        }

        public static ScreenSize Instance(float x = 854, float y = 480)
        {
            // Create a Singleton to avoid duplicates
            if (instance == null)
            {
                instance = new ScreenSize(new Vector2(x, y));
            }
            return instance;
        }

        // Methode
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            // If arrow Up or Down is press
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                // Set the windows smaller
                graphics.PreferredBackBufferWidth = (int)Size.X;
                graphics.PreferredBackBufferHeight = (int)Size.Y;
                graphics.ApplyChanges();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                // Set Windows to screen size
                graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                graphics.ApplyChanges();
            }
        }
    }
}
