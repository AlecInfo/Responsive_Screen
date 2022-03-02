/********************************
 * Projet : Responsive screen
 * Description : Proof of concept of 13th Haunted Street 
 *  to experiment screen responsive https://github.com/AlecInfo/13th_Haunted_Street
 * 
 * Date : 28/02/2022
 * Version : 1.0
 * Auteur : Rodrigues Marques Marco, Piette Alec, Arcidiacono Jérémie, Viera Luis David
*******************************/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Responsive_Screen
{
    public class Game1 : Game
    {
        // Attributs
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _character;
        private Texture2D _background;

        private RenderTarget2D _renderTarget2D;
        public float scale = 0.44444f;

        private ScreenSize _screenSize = ScreenSize.Instance();

        private Player _player;


        // Ctor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            // Change windows size
            Window.IsBorderless = true;
            _graphics.PreferredBackBufferWidth = (int)_screenSize.Size.X;
            _graphics.PreferredBackBufferHeight = (int)_screenSize.Size.Y;
            _graphics.ApplyChanges();
        }

        // Methodes
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Images
            _character = Content.Load<Texture2D>("cyan");
            _background = Content.Load<Texture2D>("background");

            // Load render target from 1920 by 1080
            _renderTarget2D = new RenderTarget2D(GraphicsDevice, 1920, 1080);

            // Load player
            _player = new Player(_renderTarget2D.Bounds.Center.ToVector2(), _character);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update Windows position and Update the size
            Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (_graphics.PreferredBackBufferWidth / 2), (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (_graphics.PreferredBackBufferHeight / 2));
            _screenSize.Update(gameTime, _graphics);

            // Update the player
            _player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Get the scale of the screen
            scale = 1f / ((float)_renderTarget2D.Height / GraphicsDevice.Viewport.Height);

            // For draw the images 
            GraphicsDevice.SetRenderTarget(_renderTarget2D);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Background
            _spriteBatch.Draw(_background, _renderTarget2D.Bounds.Center.ToVector2(), null, Color.White, 0f, _background.Bounds.Center.ToVector2(), 1f, SpriteEffects.None, 0f);
            // Player
            _player.Draw(_spriteBatch);
            
            _spriteBatch.End();

            // For draw the render target
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_renderTarget2D, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
