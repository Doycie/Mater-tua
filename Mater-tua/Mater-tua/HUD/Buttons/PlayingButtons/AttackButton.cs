using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

class AttackButton : PlayingButton
{
    public AttackButton(Rectangle position, Texture2D tex, Texture2D texPressed, bool relative, List<Entity> list)
        : base(position, tex, texPressed, relative, list)
    {

    }

    public bool update(InputHelper inputHelper)
    {
        if (entityList[0] != null)
        {
            _visible = entityList[0]._AttackButton;
        }
        base.update(inputHelper);
    }
}

