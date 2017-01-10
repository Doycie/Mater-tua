
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
    private bool _relative;
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
    public Button(Rectangle position, Texture2D tex, Texture2D texPressed, bool relative)
    {
        _texPressed = texPressed;
        _tex = tex;
        _position = position;
        _relative = relative;
    }
    

    public bool update(InputHelper inputHelper)
    {

        Rectangle r = realButtonPos();
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
    protected Rectangle realButtonPos()
    {
        if(_relative)
        return new Rectangle((int) GameEnvironment.getCamera().getScreenSize().X/ 2 - _position.X, (int)GameEnvironment.getCamera().getScreenSize().Y / 2 - _position.Y, _position.Width, _position.Height);
        else
        return new Rectangle(_position.X, (int)GameEnvironment.getCamera().getScreenSize().Y - _position.Y, _position.Width, _position.Height);
    }
    public void draw(SpriteBatch s)
    {
        Rectangle r = realButtonPos();
        if (_pressed)
            s.Draw(_texPressed, r, Color.White);
        else
            s.Draw(_tex, r, Color.White);
    }

}