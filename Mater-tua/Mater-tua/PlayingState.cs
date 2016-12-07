using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class PlayingState : GameState
{

    private float _camSpeed = 4.0f;
    private int _previousScrollValue;
    private MouseState _mouseState;
    private Level level;

    public PlayingState()
    {
       
        _mouseState = Mouse.GetState();
        level = new Level();
        level.init(128,128);

    }
    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        level.draw(spriteBatch);
        

    }

    public void handleInput(InputHelper inputHelper)
    {
        _mouseState = Mouse.GetState();
        if (inputHelper.IsKeyDown(Keys.D))
        {
            GameEnvironment.getCamera().move(new Vector2(-_camSpeed, 0.0f));
        }
        else if (inputHelper.IsKeyDown(Keys.A))
        {
            GameEnvironment.getCamera().move(new Vector2(_camSpeed, 0.0f));

        }
        else if (inputHelper.IsKeyDown(Keys.W))
        {
            GameEnvironment.getCamera().move(new Vector2(0.0f, _camSpeed));
        }
        else if (inputHelper.IsKeyDown(Keys.S))
        {
            GameEnvironment.getCamera().move(new Vector2(0.0f, -_camSpeed));
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

    public void update(GameTime gameTime)
    {

    }
}