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
    MenuHUD _menuHUD;
    
    private bool playing = false;

    public bool playingState()
    {
        return playing;
    }

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
        _menuHUD.draw(spriteBatch);
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

        _menuHUD.updateHandleInput(inputHelper);

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
            playing = true;
        }

    }

}
