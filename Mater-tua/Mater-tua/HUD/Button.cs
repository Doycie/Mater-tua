
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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


    public void setPosition(Rectangle position)
    {
        _position = position;
    }
    //A BUTTON DEFINED BY A POSITION RECTANCLE AND TEXTURES
    //THE Y COORDINATE IS THE OFFSET TO THE BOTTOM OF THE SCREEN
    public Button(Rectangle position, Texture2D tex, Texture2D texPressed)
    {
        _texPressed = texPressed;
        _tex = tex;
        _position = position;
    }
    

    public bool update(InputHelper inputHelper)
    {

        Rectangle r = new Rectangle(_position.X, (int)GameEnvironment.getCamera().getScreenSize().Y - _position.Y, _position.Width, _position.Height);
        bool ret = false;
        if (r.Contains(inputHelper.realMousePosition))
        {
            if (!inputHelper.MouseLeftButtonDown() && _pressed)
            {
                ret = true;
            }

            if (inputHelper.MouseLeftButtonDown())
            {
                _pressed = true;
                GameEnvironment.getAssetManager().PlayButtonSound();
            }
            else
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
        Rectangle r = new Rectangle( _position.X, (int)GameEnvironment.getCamera().getScreenSize().Y - _position.Y, _position.Width, _position.Height);
        if (_pressed)
            s.Draw(_texPressed, r, Color.White);
        else
            s.Draw(_tex, r, Color.White);
    }

}