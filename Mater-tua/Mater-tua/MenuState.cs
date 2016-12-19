using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;

class MenuState : GameState
{
    CustomCursor _customCursor;
    private MouseState _mouseState;
    Vector2 _lastMousePos;
    Vector2 _currentMousePos;
    bool _mouseReleased;
    public bool menuState, playingState;
    MenuHUD _menuHUD;

    public MenuState()
    {
        _customCursor = new CustomCursor();
        _mouseState = Mouse.GetState();
        _menuHUD = new MenuHUD();
    }

    public void update(GameTime gameTime)
    {

    }

    public void drawHUD(SpriteBatch spriteBatch)
    {
        _customCursor.draw(spriteBatch);
    }

    public void draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }

    public void handleInput(InputHelper inputHelper)
    {
        _customCursor.updateCursorPosition(inputHelper);
        _mouseState = Mouse.GetState();

        _currentMousePos = _customCursor.getMousePos();

        if (inputHelper.MouseLeftButtonDown())
        {
            if (_mouseReleased == false)
            {
                _mouseReleased = true;
                _lastMousePos = _customCursor.getMousePos();
            }
        }

        if (inputHelper.KeyPressed(Keys.Enter))
        {
            playingState = true && (menuState = false);
        }

    }

}
