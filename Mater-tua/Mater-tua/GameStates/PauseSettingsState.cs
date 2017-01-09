using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PauseSettingsState : GameState
{
    CustomCursor _customCursor;
    private MouseState _mouseState;
    Vector2 _lastMousePos;
    Vector2 _currentMousePos;
    bool _mouseReleased;
    HUD _hud;

    public PauseSettingsState()
    {
        _customCursor = new CustomCursor();
        _mouseState = Mouse.GetState();
        _hud = new PauseSettingsHud();
    }

    public void update(GameTime gameTime)
    {

    }

    public void drawHUD(SpriteBatch spriteBatch)
    {
        _hud.draw(spriteBatch);
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

        if ((_hud as PauseSettingsHud).update(inputHelper))
            GameEnvironment.gameStateManager.State = GameStateManager.state.Playing;

        if (inputHelper.MouseLeftButtonDown())
        {
            if (_mouseReleased == false)
            {
                _mouseReleased = true;
                _lastMousePos = _customCursor.getMousePos();
            }
        }

        if (inputHelper.KeyPressed(Keys.Back))
        {
            GameEnvironment.gameStateManager.State = GameStateManager.state.Pause;
        }

    }
}
