# Responsive_Screen
Proof of concept of [13th Haunted Street](https://github.com/AlecInfo/13th_Haunted_Street), which aims to experience **Screen responsive**. This concept was made in C# for [Monogame](https://www.monogame.net/). For this project we used `renderTarged2D` which is already implemented in Monogame.

## How to use

- Implement the class `RenderTarget2D` like this.
```cs
private RenderTarget2D _renderTarget2D;
```

- In the `LoadContent()` methode, load the render target.
```cs
// from 1920 by 1080
_renderTarget2D = new RenderTarget2D(GraphicsDevice, 1920, 1080);
```

- Now you create float varriable `scale` and in the `Draw()` methode changes the size according to the screen.
```cs
this.scale = 1f / ((float)this._renderTarget2D.Height / GraphicsDevice.Viewport.Height);
```

- Your method should look like this.
> The first `_spriteBatch.Begin();` is for the images. And the second one is only for the render target.

```cs
        protected override void Draw(GameTime gameTime)
        {
            this.scale = 1f / ((float)this._renderTarget2D.Height / GraphicsDevice.Viewport.Height);
            
            
            // First 
            GraphicsDevice.SetRenderTarget(this._renderTarget2D);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Draw your images 
            // ...
            
            _spriteBatch.End();


            // Second
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(this._renderTarget2D, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, this.scale, SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
```
