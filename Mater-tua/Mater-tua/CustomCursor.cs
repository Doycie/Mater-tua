using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Input;

class CustomCursor
{
    //Holds the position and the current texture
    private Texture2D _tex;
    private Vector2 _mousePosWorld;
    private Vector2 _mousePosScreen;

    //Load the standard mouse texture
    public CustomCursor()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("CursorTest");
    }

    //Gets the mouse position in the game world from the camera
    public void updateCursorPosition(InputHelper input)
    {
        
        _mousePosScreen = new Vector2(input.realMousePosition.X , input.realMousePosition.Y );
        //Old mousepos from camera
        _mousePosWorld = new Vector2(input.realMousePosition.X / GameEnvironment.getCamera().getZoom() + GameEnvironment.getCamera().getView().X, input.realMousePosition.Y / GameEnvironment.getCamera().getZoom() + GameEnvironment.getCamera().getView().Y);

    }

    //Draw the cursor
    public void draw(SpriteBatch s)
    {
        s.Draw(_tex, _mousePosScreen, new Rectangle(0, 0, _tex.Width, _tex.Height), Color.White, 0.0f, new Vector2(_tex.Width / 5, _tex.Height / 5), 1 / GameEnvironment.getCamera().getZoom(), SpriteEffects.None, 0.0f);
    }

    //Get the mouseposition in the game world
    public Vector2 getMousePos()
    {
        return _mousePosWorld;
    }
}

