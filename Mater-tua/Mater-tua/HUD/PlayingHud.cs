﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

internal class PlayingHud : HUD
{
    private Minimap _minimap;
    protected List<BuildingAndUnit> hudUnits;
    private Level _level;
    private Texture2D _minimapBorder;
    protected List<BuildingAndUnit> entityList;
    

    public PlayingHud(Level level, List<BuildingAndUnit> list)
    {
        entityList = list;
        _level = level;
        _minimap = new Minimap(256);
        _buttons = new List<Button>();
        _playingButtons = new List<PlayingButton>();
        _resources = new List<Resources>();

        _minimapBorder = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/Border");

        /* 0 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 4 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 8 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 1 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 5 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 9 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 2 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 6 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 10 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 3 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1270, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 7 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1270, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 11 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1270, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));

        _resources.Add(new Resources(1, _level));
        _resources.Add(new Resources(2, _level));
        _resources.Add(new Resources(3, _level));
    }

    public override void draw(SpriteBatch s)
    {
        base.draw(s);


        _minimap.draw(s);
        s.Draw(_minimapBorder, new Vector2(0, GameEnvironment.getCamera().getScreenSize().Y - 300), Color.White);
        //foreach (BasicMeleeUnit q in hudUnits.OfType<BasicMeleeUnit>())

        if (hudUnits != null)
        {
            int i = 0;
            foreach (BuildingAndUnit e in hudUnits.OfType<BuildingAndUnit>())
            {
               
                e.Healthbar(s, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X / 2 - 300 + i * 64, (int)GameEnvironment.getCamera().getScreenSize().Y - 120));
                s.Draw(e.Sprite, new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2 - 300 + i*64, (int)GameEnvironment.getCamera().getScreenSize().Y - 120, 64, 64), Color.White);
                i++;
                if (i > 8)
                    break;
            }
        }

    }

    public void update(InputHelper inputHelper, List<BuildingAndUnit> selectedEntities, Level level)
    {
        int j = base.update(inputHelper);

        _minimap.update(level);
        hudUnits = selectedEntities;

        foreach (WorkerUnit q in hudUnits.OfType<WorkerUnit>())
        {
            _playingButtons[1]._visible = true;
        }



        switch (j)
        {
            default:
                
                break;
        }

        //switch (j)
        //{
        //    case 0:
        //        break;

        //    case 1:
        //        foreach (BasicMeleeUnit i in selectedEntities)
        //            i.setFaction(Unit.faction.Human);
        //        break;

        //    case 2:
        //        foreach (BasicMeleeUnit i in selectedEntities)
        //            i.setFaction(Unit.faction.Orc);
        //        break;

        //    case 3:
        //        foreach (BasicMeleeUnit i in selectedEntities)
        //            i.setFaction(Unit.faction.Neutral);
        //        break;

        //    case 4:
        //        MediaPlayer.Volume -= (float)0.1;
        //        try
        //        {
        //            SoundEffect.MasterVolume -= (float)0.1;
        //        }
        //        catch
        //        {
        //            SoundEffect.MasterVolume = 0;
        //        }
        //        Console.WriteLine(SoundEffect.MasterVolume);
        //        break;

        //    case 5:
        //        MediaPlayer.Volume += (float)0.1;
        //        try
        //        {
        //            SoundEffect.MasterVolume += (float)0.1;
        //        }
        //        catch
        //        {
        //            SoundEffect.MasterVolume = 1;
        //        }
        //        Console.WriteLine(SoundEffect.MasterVolume);
        //        break;
        //}
    }
}