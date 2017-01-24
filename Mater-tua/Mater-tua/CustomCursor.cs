using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class CustomCursor
{
    //Holds the position and the current texture
    private Texture2D _tex;
    private Texture2D _moveTex;
    private Texture2D _attackTex;

    private Vector2 _mousePosWorld;
    private Vector2 _mousePosScreen;

    private Level _level;

    //Load the standard mouse texture
    public CustomCursor(Level level)
    {
        _level = level;
        _tex = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/CursorTest");
        _moveTex = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/moveCursor");
        _attackTex = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/attackCursor");
    }

    public CustomCursor()
    {
       
        _tex = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/CursorTest");
        _moveTex = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/moveCursor");
    }

    //Gets the mouse position in the game world from the camera
    public void updateCursorPosition(InputHelper input)
    {
       
        _mousePosScreen = new Vector2(input.realMousePosition.X, input.realMousePosition.Y);
        //Old mousepos from camera
        _mousePosWorld = new Vector2(input.realMousePosition.X / GameEnvironment.getCamera().getZoom() + GameEnvironment.getCamera().getView().X, input.realMousePosition.Y / GameEnvironment.getCamera().getZoom() + GameEnvironment.getCamera().getView().Y);
    }

    //Draw the cursor
    public void draw(SpriteBatch s)
    {
        if (_level != null && _moveTex != null && _level.movingUnits && !_level._attackMoveUnits)
        {
            s.Draw(_moveTex, new Vector2(_mousePosScreen.X + _moveTex.Width / 2, _mousePosScreen.Y + _moveTex.Height / 2), new Rectangle(0, 0, _moveTex.Width / 2, _moveTex.Height / 2), Color.White, 0.0f, new Vector2(_moveTex.Width, _moveTex.Height), 1 / GameEnvironment.getCamera().getZoom(), SpriteEffects.None, 0.0f);

        }
        else if(_level != null && _moveTex != null && !_level.movingUnits && _level._attackMoveUnits)
        {
            s.Draw(_attackTex, new Vector2(_mousePosScreen.X + _moveTex.Width / 2, _mousePosScreen.Y + _attackTex.Height / 2), new Rectangle(0, 0, _attackTex.Width, _attackTex.Height), Color.White, 0.0f, new Vector2(_attackTex.Width, _attackTex.Height), 1 / GameEnvironment.getCamera().getZoom(), SpriteEffects.None, 0.0f);
        } else
        {
            s.Draw(_tex, _mousePosScreen, new Rectangle(0, 0, _tex.Width, _tex.Height), Color.White, 0.0f, new Vector2(_tex.Width / 5, _tex.Height / 5), 1 / GameEnvironment.getCamera().getZoom(), SpriteEffects.None, 0.0f);

        }

    }

    //Get the mouseposition in the game world
    public Vector2 getMousePos()
    {
        return _mousePosWorld;
    }
}