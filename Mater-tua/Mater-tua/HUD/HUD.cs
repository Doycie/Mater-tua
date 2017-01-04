using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

class HUD
{
    protected List<Button> _buttons;
    private Texture2D _tex;
    private Rectangle _hudSize;

    public HUD()
    {
        _tex = GameEnvironment.getAssetManager().GetSprite("WoodTextureTest");
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

        foreach (Button b in _buttons)
        {
            b.draw(spriteBatch);
        }
    }

    protected int update(InputHelper inputHelper)
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
        return 0;
    }
}
