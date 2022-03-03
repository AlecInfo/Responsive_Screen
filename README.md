# Responsive_Screen

Proof of concept of [13th Haunted Street](https://github.com/AlecInfo/13th_Haunted_Street), which aims to experience **responsive screen**. This concept was made in C# for [Monogame](https://www.monogame.net/). For this project we used ***renderTarged2D*** which is already implemented in Monogame.

## How to use render target

1. Implement the class ***RenderTarget2D*** like this.
```cs
private RenderTarget2D _renderTarget2D;
```

2. In the ***LoadContent()*** methode, load the render target.
```cs
protected override void LoadContent()
{
    _spriteBatch = new SpriteBatch(GraphicsDevice);

    // from 1920 by 1080
    _renderTarget2D = new RenderTarget2D(GraphicsDevice, 1920, 1080);
}
```

3. Now you create float variable `scale` and in the ***Draw()*** methode changes the size according to the screen.
```cs
this.scale = 1f / ((float)this._renderTarget2D.Height / GraphicsDevice.Viewport.Height);
```

4. Your method should look like this.
> The first `_spriteBatch.Begin();` is for the images. And the second one is only for the render target.

```cs
        protected override void Draw(GameTime gameTime)
        {
            scale = 1f / ((float)_renderTarget2D.Height / GraphicsDevice.Viewport.Height);
            
            
            // First 
            GraphicsDevice.SetRenderTarget(_renderTarget2D);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Draw your images 
            // ...
            
            _spriteBatch.End();


            // Second
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_renderTarget2D, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
```

## Program controls

In the program there is a character who can be move using the keys
- W, A, S, D

And you have commands that allow you to enlarge or shrink the size of the window
- arrow ⬆️ and arrow ⬇️
