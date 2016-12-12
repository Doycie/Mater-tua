using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

class PlayingState : GameState
{ 
    private Vector2 _camSpeed = new Vector2(4.0f,4.0f);
    private int _previousScrollValue;
    private MouseState _mouseState;
    private Level level;
    private List<Entity> _selectedEntities = new List<Entity>();
    CustomCursor _customCursor;
    Vector2 _lastMousePos;
    Vector2 _currentMousePos;
    bool _mouseReleased;
    Texture2D _selectTex;

    public PlayingState()
    {
        _customCursor = new CustomCursor();
        _mouseState = Mouse.GetState();
        level = new Level();
        level.init("lvl.txt");
        _selectTex = GameEnvironment.getAssetManager().GetSprite("selectbox");


    }

    public void update(GameTime gameTime)
    {
       
       // Console.WriteLine(mousePos);
    }

    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        level.draw(spriteBatch);
        _customCursor.draw(spriteBatch);
        if(_mouseReleased)
        spriteBatch.Draw(_selectTex, new Rectangle((int)_lastMousePos.X, (int)_lastMousePos.Y, (int)(_currentMousePos.X - _lastMousePos.X), (int)(_currentMousePos.Y - _lastMousePos.Y)), Color.White);
        if (_selectedEntities.Count > 0)
            foreach (Entity e in _selectedEntities)
            {
                spriteBatch.Draw(_selectTex, new Rectangle((int)e.getPosition().X, (int)e.getPosition().Y, 64, 64), Color.White);
            }
        }


    public void handleInput( InputHelper inputHelper)
    {
        _customCursor.updateCursorPosition(inputHelper);
        _mouseState = Mouse.GetState();

        _currentMousePos = _customCursor.getMousePos();
        if (!inputHelper.MouseLeftButtonDown())
        {
            if (_mouseReleased)
            {
                Rectangle r = new Rectangle((int)_lastMousePos.X, (int)_lastMousePos.Y, (int)(_currentMousePos.X - _lastMousePos.X), (int)(_currentMousePos.Y - _lastMousePos.Y));
                foreach (Entity e in level.entities)
                    if ((r.Contains(e.getPosition())))
                    {
                        _selectedEntities.Add(e);
                    }
            }
            _mouseReleased = false;
        }
        if (inputHelper.MouseLeftButtonDown() )
        {
            if(_mouseReleased == false)
            {
                _mouseReleased = true;
                _lastMousePos = _customCursor.getMousePos();
            }

            
        }
        if (inputHelper.MouseLeftButtonPressed())
        {
            
            Vector2 pos = _customCursor.getMousePos();

            bool clickedOnEntity = false;
            foreach (Entity e in level.entities)
            {
                if ((new Rectangle((int)e.getPosition().X, (int)e.getPosition().Y, 64, 64).Contains(pos)))
                {
                    clickedOnEntity = true;
                    if (inputHelper.IsKeyDown(Keys.LeftControl))
                    {
                        if (!_selectedEntities.Contains(e))
                        {
                            _selectedEntities.Add(e);
                        }
                    }
                    else
                    {
                        _selectedEntities.Clear();
                        _selectedEntities.Add(e);
                    }
                }
            }
            if (!clickedOnEntity)
            {
                _selectedEntities.Clear();
            }
        }

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