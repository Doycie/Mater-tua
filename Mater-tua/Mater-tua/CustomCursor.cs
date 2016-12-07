using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

class CustomCursor
{
    private Texture2D _tex;
    private Vector2 mousePos;
    private InputHelper inputHelper;

    public CustomCursor()
    {
        inputHelper = new InputHelper();
        _tex = GameEnvironment.getAssetManager().GetSprite("CursorTest");
    }

    public void Update(GameTime gameTime)
    {
        mousePos = new Vector2(inputHelper.MousePosition.X, inputHelper.MousePosition.Y);
        Console.WriteLine(inputHelper.MousePosition);
    }

    public void draw(SpriteBatch s)
    {
        s.Draw(_tex, new Vector2(0,0), Color.White);
    }
}

