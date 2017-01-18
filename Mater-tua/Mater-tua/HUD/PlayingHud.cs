using Microsoft.Xna.Framework;
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


        /* De volgorde is zo gefuckt omdat ik van links naar rechts tel en daarna naar de volgende rij van 4 buttons ga. Deal with it */
        /* 0 move button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 1 build building button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 2 produce worker unit*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 3 stop move button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 4 mine gold button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 5 produce melee unit*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 6 attack button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 7 chop wood button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 8 produce ranged unit*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 9 patrol button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1270, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 10 */
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
               
                e.Healthbar(s, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X / 2 - 350 + i * 64, (int)GameEnvironment.getCamera().getScreenSize().Y - 120));
                s.Draw(e.Sprite, new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2 - 350 + i*64, (int)GameEnvironment.getCamera().getScreenSize().Y - 120, 64, 64), Color.White);
                i++;
                if (i > 9)
                    break;
            }
        }

    }

    public void update(InputHelper inputHelper, List<BuildingAndUnit> selectedEntities, Level level)
    {
        int j = base.update(inputHelper);

        _minimap.update(level);
        hudUnits = selectedEntities;

        /* Ik ben niet trots op hoe ik het hierop volgende stuk code heb opgelost, voel je vrij om het mooi en efficienter te maken. Ik ben er klaar mee */
        for (int i = 0; i <= _playingButtons.Count - 1; i++)
            _playingButtons[i]._visible = false;

            foreach (WorkerUnit w in selectedEntities.OfType<WorkerUnit>())
            {
                _playingButtons[0]._visible = true;
                _playingButtons[1]._visible = true;
                _playingButtons[3]._visible = true;
                _playingButtons[4]._visible = true;
                _playingButtons[7]._visible = true;
            }
            foreach (CombatUnit c in selectedEntities.OfType<CombatUnit>())
            {
                _playingButtons[0]._visible = true;
                _playingButtons[3]._visible = true;
                _playingButtons[6]._visible = true;
                _playingButtons[9]._visible = true;
            }
            foreach (Barracks b in selectedEntities.OfType<Barracks>())
            {
                _playingButtons[5]._visible = true;
                _playingButtons[8]._visible = true;
            }
            foreach (Townhall t in selectedEntities.OfType<Townhall>())
            {
                _playingButtons[2]._visible = true;
            }
        



        switch (j)
        {
            /* Case number bij een knop is i+1 van de playingbuttons lijst. Om het lekker simpel te houden */
            default:
                Console.WriteLine("Default");
                break;
            case 0:
                break;
            case 1:
                Console.WriteLine("case 1");
                break;
            case 2:
                Console.WriteLine("case 2");
                break;
            case 3:
                Console.WriteLine("case 3");
                break;
            case 4:
                Console.WriteLine("case 4");
                break;
            case 5:
                Console.WriteLine("case 5");
                break;
            case 6:
                Console.WriteLine("case 6");
                break;
            case 7:
                Console.WriteLine("case 7");
                break;
            case 8:
                Console.WriteLine("case 8");
                break;
            case 9:
                foreach (Barracks i in selectedEntities)
                    i.ProduceUnit(level, i.Position);
                Console.WriteLine("case 9");
                break;
            case 10:
                Console.WriteLine("case 10");
                break;
            case 11:
                Console.WriteLine("case 11");
                break;
            case 12:
                Console.WriteLine("case 12");
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