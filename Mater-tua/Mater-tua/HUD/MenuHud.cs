using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class MenuHud : HUD
{

    public MenuHud()
    {
        _buttons = new List<Button>();
        /* 1 */
        _buttons.Add(new Button(new Rectangle(32, 114, 368, 100), GameEnvironment.getAssetManager().GetSprite("playButton"), GameEnvironment.getAssetManager().GetSprite("playButtonPressed")));
        /* 2 */
        _buttons.Add(new Button(new Rectangle(432, 114, 40, 40), GameEnvironment.getAssetManager().GetSprite("VolumeDown"), GameEnvironment.getAssetManager().GetSprite("VolumeDownPressed")));
        /* 3 */
        _buttons.Add(new Button(new Rectangle(432, 57, 40, 40), GameEnvironment.getAssetManager().GetSprite("VolumeUp"), GameEnvironment.getAssetManager().GetSprite("VolumeUpPressed")));

    }

    public new bool update(InputHelper inputHelper)
    {
        int j = base.update(inputHelper);

        switch (j)
        {
            case 0:
                break;
            case 1:
                return true;
            case 2:
                MediaPlayer.Volume -= (float)0.01;
                break;
            case 3:
                MediaPlayer.Volume += (float)0.01;
                break;
        }
        return false;

    }
}