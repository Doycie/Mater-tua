using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

class PlayingButton : Button
{
    protected List<Entity> entityList;

    public PlayingButton(Rectangle position, Texture2D tex, Texture2D texPressed, bool relative, List<Entity> list)
        : base (position,tex,texPressed,relative)
    {
        entityList = list;
    }
}

