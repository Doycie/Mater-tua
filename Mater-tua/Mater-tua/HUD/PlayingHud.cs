using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;


class PlayingHUD : HUD
{
    public PlayingHUD()
    {
        _buttons = new List<Button>();
        /* 1 */
        _buttons.Add(new Button(new Rectangle(32, 114, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed"),false));
        /* 2 */
        _buttons.Add(new Button(new Rectangle(168, 114, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed"),false));
        /* 3 */
        _buttons.Add(new Button(new Rectangle(296, 114, 100, 100), GameEnvironment.getAssetManager().GetSprite("Button"), GameEnvironment.getAssetManager().GetSprite("ButtonPressed"),false));
        /* 4 */
        _buttons.Add(new Button(new Rectangle(432, 114, 40, 40), GameEnvironment.getAssetManager().GetSprite("VolumeDown"), GameEnvironment.getAssetManager().GetSprite("VolumeDownPressed"),false));
        /* 5 */
        _buttons.Add(new Button(new Rectangle(432, 57, 40, 40), GameEnvironment.getAssetManager().GetSprite("VolumeUp"), GameEnvironment.getAssetManager().GetSprite("VolumeUpPressed"),false));

    }

    public void update(InputHelper inputHelper, List<Entity> selectedEntities)
    {
        int j = base.update(inputHelper);

        switch (j)
        {
            case 0:
                break;
            case 1:
                foreach (BasicMeleeUnit i in selectedEntities)
                    i.setFaction(Unit.faction.Human);
                break;
            case 2:
                foreach (BasicMeleeUnit i in selectedEntities)
                    i.setFaction(Unit.faction.Orc);
                break;
            case 3:
                foreach (BasicMeleeUnit i in selectedEntities)
                    i.setFaction(Unit.faction.Neutral);
                break;
            case 4:
                MediaPlayer.Volume -= (float)0.1;
                break;
            case 5:
                MediaPlayer.Volume += (float)0.1;
                break;
        }

    }

}
