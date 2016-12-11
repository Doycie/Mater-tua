using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

class PlayingState : GameState
{

    private Vector2 _camSpeed = new Vector2(4.0f,4.0f);
    private int _previousScrollValue;
    private MouseState _mouseState;
    private Level level;
    CustomCursor _customCursor;

    public PlayingState()
    {
        _customCursor = new CustomCursor();
        _mouseState = Mouse.GetState();
        level = new Level();
        level.init("lvl.txt");
        
    }

    public void update(GameTime gameTime)
    {
       
       // Console.WriteLine(mousePos);
    }

    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        level.draw(spriteBatch);
        _customCursor.draw(spriteBatch);
    }

    public void handleInput( InputHelper inputHelper)
    {
        _customCursor.updateCursorPosition(inputHelper);
        
        _mouseState = Mouse.GetState();


        int x = 0;
        int y = 0;

        if (inputHelper.IsKeyDown(Keys.D))
        {
            x++;
        }
         if (inputHelper.IsKeyDown(Keys.A))
        {
            x--;

        }
         if (inputHelper.IsKeyDown(Keys.W))
        {
            y--;
        }
         if (inputHelper.IsKeyDown(Keys.S))
        {
            y++;
        }

        Vector2 mov = new Vector2(x, y);
        if(mov!= Vector2.Zero)
        {
            mov.Normalize();
            mov *= _camSpeed;
            GameEnvironment.getCamera().move(Vector2.Normalize(mov) * _camSpeed);
        }


        if (_mouseState.ScrollWheelValue < _previousScrollValue)
        {
            GameEnvironment.getCamera().zoom(-.04f);
        }
        else if (_mouseState.ScrollWheelValue > _previousScrollValue)
        {
            GameEnvironment.getCamera().zoom(0.04f);
        }
        _previousScrollValue = _mouseState.ScrollWheelValue;
    }

    
}