/********************************
 * Projet : Shadow Casting
 * Description : Proof of concept of 13th Haunted Street 
 *  to experiment penumbra https://github.com/AlecInfo/13th_Haunted_Street
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
    class Player
    {
        // Attributs
        private Vector2 _position;
        private Texture2D _texture;

        private SpriteEffects _spriteEffect;

        private float speed = 0.25f;


        // Ctor
        public Player(Vector2 position, Texture2D texture)
        {
            this._texture= texture;
            this._position = position;
        }


        // Methods
        public void Update(GameTime gameTime)
        {
            KeyboardState kbdState = Keyboard.GetState();

            // Mouvements
            if (kbdState.IsKeyDown(Keys.W))
            {
                this._position.Y -= this.speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (kbdState.IsKeyDown(Keys.A))
            {
                this._position.X -= this.speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                this._spriteEffect = SpriteEffects.FlipHorizontally;
            }

            if (kbdState.IsKeyDown(Keys.S))
            {
                this._position.Y += this.speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (kbdState.IsKeyDown(Keys.D))
            {
                this._position.X += this.speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                this._spriteEffect = SpriteEffects.None;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw player
            spriteBatch.Draw(this._texture, this._position, null, Color.White, 0f, new Vector2(0.5f, 0.5f), 0.15f, this._spriteEffect, 0f);
        }
    }
}