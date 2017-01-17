using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

class PlayingButton : Button
{
    protected List<BuildingAndUnit> entityList;
    public bool _visible = false;

    public PlayingButton(Rectangle position, Texture2D tex, Texture2D texPressed, bool relative, List<BuildingAndUnit> list, bool visible)
        : base (position,tex,texPressed,relative)
    {
        entityList = list;
        _visible = visible;
    }

    //public override bool update(InputHelper inputHelper)
    //{
    //    Rectangle r = realButtonPos();
    //    bool ret = false;
    //    if (_visible)
    //    {
    //        if (r.Contains(inputHelper.realMousePosition))
    //        {
    //            if (!inputHelper.MouseLeftButtonDown() && _pressed)
    //            {
    //                GameEnvironment.getAssetManager().PlaySoundEffect("Sounds/Soundeffects/ButtonTap");
    //                ret = true;
    //            }

    //            if (inputHelper.MouseLeftButtonDown())
    //            {
    //                _pressed = true;
    //            }
    //            else
    //            {
    //                _pressed = false;
    //            }
    //        }
    //        else
    //        {
    //            _pressed = false;
    //        }
    //    }
        
    //    return ret;
    //}

    public override void draw(SpriteBatch s)
    {
        if (_visible)
        {
            base.draw(s);
        }
            //base.draw(s);
    }
}

