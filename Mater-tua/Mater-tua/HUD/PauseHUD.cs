using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class PauseHud : HUD
{

    public PauseHud()
    {
        _buttons = new List<Button>();
        /* 1 */
        _buttons.Add(new Button(new Rectangle(500, 600, 368, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed")));

    }

    public new bool update(InputHelper inputHelper)
    {
        int j = base.update(inputHelper);

        switch (j)
        {
            case 0:
                break;
            case 1:
                break;
        }
        return false;

    }
}