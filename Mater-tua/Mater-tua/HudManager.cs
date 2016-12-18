using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

class Button
{
    private Rectangle _position;
    private Texture2D _tex;
    private Texture2D _texPressed;
    private bool _pressed;

    public Rectangle getPosition()
    {
        return _position;
    }
    public Button(Rectangle position, Texture2D tex, Texture2D texPressed)
    {
        _texPressed = texPressed;
        _position = position;
        _tex = tex;
    }
    
    public bool update(InputHelper inputHelper)
    {
        _position.Y = (int) GameEnvironment.getCamera().getScreenSize().Y - 128;
        bool ret = false;
        if (_position.Contains(inputHelper.realMousePosition))
        {
            if (!inputHelper.MouseLeftButtonDown() && _pressed)
            {
                ret = true;
            }

            if (inputHelper.MouseLeftButtonDown())
            {
                _pressed = true;
            }else
            {
                _pressed = false;
            }
        }
        else
        {
            _pressed = false;
        }
        return ret;
    }
    public void draw(SpriteBatch s)
    {
        if(_pressed)
            s.Draw(_texPressed, _position, Color.White);
        else
            s.Draw(_tex, _position, Color.White);
    }
}
class HUD
{
    protected List<Button> _buttons;
    public HUD()
    {

    }
    public void draw(SpriteBatch s)
    {
        foreach (Button b in _buttons)
        {
            b.draw(s);
        }
    }

    public int update(InputHelper inputHelper)
    {
        int i = 0;
        foreach(Button b in _buttons)
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

class HudUnit : HUD
{
    public HudUnit()
    {
        _buttons = new List<Button>();
        _buttons.Add(new Button(new Rectangle(32, (int)GameEnvironment.getCamera().getScreenSize().Y - 128, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));
        _buttons.Add(new Button(new Rectangle(168, (int)GameEnvironment.getCamera().getScreenSize().Y - 128, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));
        _buttons.Add(new Button(new Rectangle(296, (int)GameEnvironment.getCamera().getScreenSize().Y - 128, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));
        //_buttons.Add(new Button(new Rectangle(0,0, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));
    }

}
class HudManager
{


    //Holds the texture for the HUD background, which is always the same while playing the game.
    private Texture2D _tex;
    private HUD _hud = new HudUnit();
    private Rectangle _hudSize;

    public HudManager()
    {
     
        _tex = GameEnvironment.getAssetManager().GetSprite("WoodTextureTest");
        _hudSize = new Rectangle(0, (int)GameEnvironment.getCamera().getScreenSize().Y - _tex.Height, 328 + 100, _tex.Height);
    }

    public void draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i + _tex.Width <= GameEnvironment.getCamera().getScreenSize().X; i += _tex.Width) // repeats the HUD texture till edge of screen
            spriteBatch.Draw(_tex, new Rectangle(i, (int)GameEnvironment.getCamera().getScreenSize().Y - _tex.Height, _tex.Width, _tex.Height), Color.White);

        // spriteBatch.Draw(_tex, new Vector2(0, 450), Color.White);

        _hud.draw(spriteBatch);
    }

    public void updateHandleInput(InputHelper inputHelper, List<Entity> selectedEntities)
    {
        int j = _hud.update(inputHelper);

        foreach (BasicMeleeUnit i in selectedEntities)
        {
            
            if (j > 0)
            {
                
                if (j == 1)
                {
                   
                    i.setFaction(Unit.faction.Human);
                }
                if (j == 2)
                {
                   
                    i.setFaction(Unit.faction.Orc);
                }
                if (j == 3)
                    i.setFaction(Unit.faction.Neutral);
                
            }
        }
    }

    public  Rectangle HUDSize()
    {
        return _hudSize;
    }

}
