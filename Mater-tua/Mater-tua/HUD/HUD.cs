using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

internal class HUD
{
    protected List<Button> _buttons;
    protected List<PlayingButton> _playingButtons;
    protected List<Resources> _resources;
    private Texture2D _tex, _texHudDown, _texHudUp;
    private Rectangle _hudSize;

    public HUD()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/WoodTextureTest");
        _texHudDown = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/hudWoodDown");
        _texHudUp = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/hudWoodUp");
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
        spriteBatch.Draw(_texHudDown, new Rectangle(0, (int)GameEnvironment.getCamera().getScreenSize().Y - _texHudDown.Height, _texHudDown.Width - 150, _texHudDown.Height), Color.White);
        spriteBatch.Draw(_texHudUp, new Rectangle(_texHudDown.Width - _texHudUp.Width, (int)GameEnvironment.getCamera().getScreenSize().Y - _texHudDown.Height - _texHudUp.Height, _texHudUp.Width, _texHudUp.Height), Color.White);
        
        for (int i = (int)GameEnvironment.getCamera().getScreenSize().X - 4 * _tex.Width + 35; i + _texHudUp.Width <= GameEnvironment.getCamera().getScreenSize().X + _texHudUp.Width; i += _texHudUp.Width)
            spriteBatch.Draw(_texHudUp, new Rectangle(i, -80, _texHudUp.Width, _tex.Height), Color.White);

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
                if (p.update(inputHelper) && p._visible)
                {
                    return j;
                }
            }
        }
        



        return 0;
    }
}