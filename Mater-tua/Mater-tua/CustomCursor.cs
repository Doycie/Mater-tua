using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Input;

class CustomCursor
{
    private Texture2D _tex;
    private Vector2 _mousePos;

    public CustomCursor()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("CursorTest");
        
    }

    public void updateCursorPosition(InputHelper input)
    {

        _mousePos = new Vector2(input.realMousePosition.X / GameEnvironment.getCamera().getZoom() + GameEnvironment.getCamera().getView().X, input.realMousePosition.Y / GameEnvironment.getCamera().getZoom() + GameEnvironment.getCamera().getView().Y);

       

    }

    public void draw(SpriteBatch s)
    {
        s.Draw(_tex, _mousePos, new Rectangle(0, 0, _tex.Width, _tex.Height), Color.White, 0.0f, new Vector2(_tex.Width / 2, _tex.Height / 2), 1 / GameEnvironment.getCamera().getZoom(), SpriteEffects.None, 0.0f);
    }

    public Vector2 getMousePos()
    {
        return _mousePos;
    }
}

