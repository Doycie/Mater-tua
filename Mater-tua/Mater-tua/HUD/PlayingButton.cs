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

    public override bool update(InputHelper inputHelper)
    {
        if (_visible)
            return base.update(inputHelper);
        else return false;
    }

    public override void draw(SpriteBatch s)
    {
        if (_visible)
        {
            base.draw(s);
        }
            //base.draw(s);
    }
}

