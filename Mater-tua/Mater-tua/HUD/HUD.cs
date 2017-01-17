using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

internal class HUD
{
    protected List<Button> _buttons;
    protected List<PlayingButton> _playingButtons;
    protected List<Resources> _resources;
    private Texture2D _tex;
    private Rectangle _hudSize;

    public HUD()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/WoodTextureTest");
        resizeHUD();
    }

    public void resizeHUD()
    {
        _hudSize = new Rectangle(0, (int)GameEnvironment.getCamera().getScreenSize().Y - _tex.Height, (int)GameEnvironment.getCamera().getScreenSize().X, _tex.Height);
    }

    public Rectangle HUDSize()
    {
        return new Rectangle(0, (int)GameEnvironment.getCamera().getScreenSize().Y - _tex.Height, (int)GameEnvironment.getCamera().getScreenSize().X, _tex.Height);
    }

    public virtual void draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i + _tex.Width <= GameEnvironment.getCamera().getScreenSize().X + _tex.Width; i += _tex.Width) // repeats the HUD texture till edge of screen
            spriteBatch.Draw(_tex, new Rectangle(i, (int)GameEnvironment.getCamera().getScreenSize().Y - _tex.Height, _tex.Width, _tex.Height), Color.White);
        for (int i = (int)GameEnvironment.getCamera().getScreenSize().X - 3 * _tex.Width; i + _tex.Width <= GameEnvironment.getCamera().getScreenSize().X + _tex.Width; i += _tex.Width)
            spriteBatch.Draw(_tex, new Rectangle(i, (int)GameEnvironment.getCamera().getScreenSize().Y - 2 * _tex.Height, _tex.Width, _tex.Height), Color.White);
        for (int i = (int)GameEnvironment.getCamera().getScreenSize().X - 3 * _tex.Width - 45; i + _tex.Width <= GameEnvironment.getCamera().getScreenSize().X + _tex.Width; i += _tex.Width)
            spriteBatch.Draw(_tex, new Rectangle(i, -80, _tex.Width, _tex.Height), Color.White);

        foreach (Button b in _buttons)
        {
            b.draw(spriteBatch);
        }

        foreach (PlayingButton p in _playingButtons)
        {
            p.draw(spriteBatch);
        }

        foreach (Resources r in _resources)
        {
            r.draw(spriteBatch);
        }
    }

    protected int update(InputHelper inputHelper)
    {
        if (GameEnvironment.gameStateManager.State != GameStateManager.state.Playing)
        {
            int i = 0;
            foreach (Button b in _buttons)
            {
                i++;
                if (b.update(inputHelper))
                {
                    return i;
                }
            }
        }

        if (GameEnvironment.gameStateManager.State == GameStateManager.state.Playing)
        {
            int j = 0;
            foreach (PlayingButton p in _playingButtons)
            {
                j++;
                if (p.update(inputHelper))
                {
                    return j;
                }
            }
        }
        



        return 0;
    }
}