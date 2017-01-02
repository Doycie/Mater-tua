﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SettingsState : GameState
{
    CustomCursor _customCursor;
    private MouseState _mouseState;
    private Texture2D _BGTex;
    Vector2 _lastMousePos;
    Vector2 _currentMousePos;
    bool _mouseReleased;
    HUD _hud;

    public SettingsState()
    {
        _BGTex = GameEnvironment.getAssetManager().GetSprite("MenuBG");
        _customCursor = new CustomCursor();
        _mouseState = Mouse.GetState();
        _hud = new SettingsHud();
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
        spriteBatch.Draw(_BGTex, new Rectangle(0, 0, (int)GameEnvironment.getCamera().getScreenSize().X, (int)GameEnvironment.getCamera().getScreenSize().Y), Color.White);
    }

    public void handleInput(InputHelper inputHelper)
    {
        _customCursor.updateCursorPosition(inputHelper);
        _mouseState = Mouse.GetState();

        _currentMousePos = _customCursor.getMousePos();

        if ((_hud as SettingsHud).update(inputHelper))
            GameEnvironment.gameStateManager.State = GameStateManager.state.Playing;

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
            GameEnvironment.gameStateManager.State = GameStateManager.state.Playing;
        }

    }
}
