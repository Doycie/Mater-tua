﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

internal class PlayingHud : HUD
{
    public bool MousePosInButton = false;
    private Minimap _minimap;
    protected List<BuildingAndUnit> hudUnits;
    private Level _level;
    private Texture2D _minimapBorder;
    protected List<BuildingAndUnit> entityList;
    private string _buttonDescriprion;
    private SpriteFont font;
    private Vector2 ButtonMousePos, ToolTipPos;



    private PlayingState _playingState;

    public PlayingHud(Level level, List<BuildingAndUnit> list, PlayingState playingState)
    {
        _playingState = playingState;
        entityList = list;
        _level = level;
        _minimap = new Minimap(256,level);
        _buttons = new List<Button>();
        _playingButtons = new List<PlayingButton>();
        _resources = new List<Resources>();
        ToolTipPos = new Vector2(975, 490);
        _minimapBorder = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/Border");
        font = GameEnvironment.getAssetManager().getFont("Warcraft Font");

        /* De volgorde is zo gefuckt omdat ik van links naar rechts tel en daarna naar de volgende rij van 4 buttons ga. Deal with it */
        /* 0 move button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Move"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/MovePressed"), false, entityList, false));
        /* 1 build farm button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Farm"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/FarmPressed"), false, entityList, false));
        /* 2 produce worker unit*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1000, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Peasant"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/PeasantPressed"), false, entityList, false));
        /* 3 stop move button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/StopMove"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/StopMovePressed"), false, entityList, false));
        /* 4 build barracks*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Barracks"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/BarracksPressed"), false, entityList, false));
        /* 5 produce melee unit*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1090, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Footman"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/FootmanPressed"), false, entityList, false));
        /* 6 attack button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Attack"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/AttackPressed"), false, entityList, false));
        /* 7 chop wood button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/wood"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/woodPressed"), false, entityList, false));
        /* 8 produce ranged unit*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1180, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Archer"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ArcherPressed"), false, entityList, false));
        /* 9 patrol button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1270, 245, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));
        /* 10 build barracks button*/
        _playingButtons.Add(new PlayingButton(new Rectangle(1270, 165, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Barracks"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/BarracksPressed"), false, entityList, false));
        /* 11 */
        _playingButtons.Add(new PlayingButton(new Rectangle(1270, 85, 70, 70), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/Button"), GameEnvironment.getAssetManager().GetSprite("Sprites/Buttons/ButtonPressed"), false, entityList, false));

        _resources.Add(new Resources(1, _level));
        _resources.Add(new Resources(2, _level));
        _resources.Add(new Resources(3, _level));
    }


    public override void draw(SpriteBatch s)
    {
        base.draw(s);
     

        for (int i = 0; i < _playingButtons.Count - 1; i++)
        {
            if (_playingButtons[i]._drawTooltip == true)
            {
                switch (i)
                {
                    default:
                        break;
                    case 0:
                        s.DrawString(font, "Move units", ToolTipPos, Color.DarkOrange);
                        break;
                    case 1:
                        Farm e = new Farm(null, new Vector2(0, 0), BuildingAndUnit.faction.Human);
                        { s.DrawString(font, "Produce Farm, Gold:" + e.GoldCost + "+ Lumber:" + e.LumberCost, ToolTipPos, Color.DarkOrange); }
                        break;
                    case 2:
                        WorkerUnit w = new WorkerUnit(null);
                        { s.DrawString(font, "Produce Worker, Gold:" + w.GoldCost + "+ Food:" + w._foodCost, ToolTipPos, Color.DarkOrange); }
                        break;
                    case 3:
                        s.DrawString(font, "Stop selected units", ToolTipPos, Color.DarkOrange);
                        break;
                    case 4:
                        Barracks B = new Barracks(null, new Vector2(0, 0), BuildingAndUnit.faction.Human);
                        s.DrawString(font, "Barracks, Gold:" + B.GoldCost + "Lumber:" + B.LumberCost, ToolTipPos, Color.DarkOrange);
                        break;
                    case 5:
                        BasicMeleeUnit b = new Footman(null, new Vector2(0, 0));
                        s.DrawString(font, "Footman, Gold:" +b.GoldCost +"Lumber:"+ b.LumberCost + "Food:"+ b.FoodCost,ToolTipPos, Color.DarkOrange);
                        break;
                    case 6:
                        s.DrawString(font, "Attack", ToolTipPos, Color.DarkOrange);
                        break;
                    case 7:
                        s.DrawString(font, "Chop trees", ToolTipPos, Color.DarkOrange);
                        break;
                    case 8:
                        Archer a = new Archer(null, new Vector2(0, 0));
                        s.DrawString(font, "Archer, Gold:"+ a.GoldCost + "Lumber:" + a.LumberCost + "Food:" + a.FoodCost, ToolTipPos, Color.DarkOrange);
                        break;
                    case 9:
                        s.DrawString(font, " - ", ToolTipPos, Color.Black);
                        break;
                    case 10:
                        //Barracks B = new Barracks(null, new Vector2(0, 0), BuildingAndUnit.faction.Human);
                        //s.DrawString(font, "Barracks, Gold:"+ B.GoldCost + "Lumber:" + B.LumberCost , ToolTipPos, Color.DarkOrange);
                        break;
                    case 11:
                        s.DrawString(font, "- ", ToolTipPos, Color.Black);
                        break;
                    case 12:
                        s.DrawString(font, " - ", ToolTipPos, Color.Black);
                        break;
                }

            }
        }

        _minimap.draw(s);
        s.Draw(_minimapBorder, new Vector2(0, GameEnvironment.getCamera().getScreenSize().Y - 300), Color.White);
        //foreach (BasicMeleeUnit q in hudUnits.OfType<BasicMeleeUnit>())

        if (hudUnits != null)
        {
            int i = 0;
            foreach (BuildingAndUnit e in hudUnits.OfType<BuildingAndUnit>())
            {
                if(e is ProductionBuilding)
                {
                    if((e as ProductionBuilding)._producingUnit)
                    {
                        DrawingHelper.DrawRectangle(new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2 - 350 + i * 64, (int) GameEnvironment.getCamera().getScreenSize().Y - 60, 400,20),s,Color.SaddleBrown,2);
                        s.Draw(GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/Healthbar"), new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2 - 350 + i * 64, (int)GameEnvironment.getCamera().getScreenSize().Y - 60, (int)(400 * (float)((float)(e as ProductionBuilding)._unitProductionTimer / (float)(e as ProductionBuilding)._unitProductionTime)), 20), Color.White);
                        //DrawingHelper.DrawRectangle(new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X / 2 - 350 + i * 64, (int)GameEnvironment.getCamera().getScreenSize().Y - 60, (int)(400*(float)((float)(e as ProductionBuilding)._unitProductionTimer / (float)(e as ProductionBuilding)._unitProductionTime)), 20), s, Color.Green, 2);
                    }
                }
              
                e.Healthbar(s, new Vector2((int)GameEnvironment.getCamera().getScreenSize().X / 2 - 350 + i * 64, (int)GameEnvironment.getCamera().getScreenSize().Y - 120), 1);
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

        ButtonMousePos.X = inputHelper.realMousePosition.X - 50;
        ButtonMousePos.Y = inputHelper.realMousePosition.Y - 30;
        _minimap.update(level);
        hudUnits = selectedEntities;

        /* Ik ben niet trots op hoe ik het hierop volgende stuk code heb opgelost, voel je vrij om het mooi en efficienter te maken. Ik ben er klaar mee */
        for (int i = 0; i < _playingButtons.Count - 1; i++)
          _playingButtons[i]._visible = false;

            foreach (WorkerUnit w in selectedEntities.OfType<WorkerUnit>())
                {
                    _playingButtons[0]._visible = true;
                    _playingButtons[1]._visible = true;
                    _playingButtons[3]._visible = true;
                    _playingButtons[4]._visible = true;
                    //_playingButtons[7]._visible = true;
                    //_playingButtons[10]._visible = true;
                }
            foreach (CombatUnit c in selectedEntities.OfType<CombatUnit>())
                {
                _playingButtons[0]._visible = true;
                _playingButtons[3]._visible = true;
                _playingButtons[6]._visible = true;
                //_playingButtons[9]._visible = true;
                }
            foreach (Barracks b in selectedEntities.OfType<Barracks>())
                {
                _playingButtons[0]._visible = false;
                _playingButtons[3]._visible = false;
                _playingButtons[5]._visible = true;
                _playingButtons[6]._visible = false;
                _playingButtons[8]._visible = true;
                //_playingButtons[9]._visible = false;
                }
            foreach (Townhall t in selectedEntities.OfType<Townhall>())
                {
                _playingButtons[0]._visible = false;
                _playingButtons[3]._visible = false;
                _playingButtons[2]._visible = true;
                }



            switch (j)
            {

                /* Case number bij een knop is i+1 van de playingbuttons lijst. Om het lekker simpel te houden */
                default:
                    Console.WriteLine("Default");
                    break;
                case 0: //leeg laten! Deze doet niks
                    break;
                case 1:
                    _level.moveUnits();
                    Console.WriteLine("case 1, order move");
                    
                    break;
                case 2:
                    _buttonDescriprion = "Farm: Gold: 400, Lumber:400, produces food";
                    Console.WriteLine("case 2");
                    level.dragBuilding(1);
                    break;
                case 3:
                    _buttonDescriprion = "Worker: Gold: 100";
                    foreach (Townhall t in selectedEntities)
                        if (t.Faction == BuildingAndUnit.faction.Human)
                            t.produceUnit(new Peasant(_level, new Vector2(t.Position.X + 3 * data.tSize(), t.Position.Y + 2 * data.tSize())));

                    Console.WriteLine("case 3, produce worker unit");
                    break;
                case 4:
                    foreach (Unit u in selectedEntities)
                    if(u.Path.Count > 1)
                        u.Path.RemoveRange(0, u .Path.Count - 1);
                _playingState.Mine = false;
                _playingState.Chop = false;
                Console.WriteLine("case 4, order stop move.");
                    break;
                case 5:
                level.dragBuilding(2);
                Console.WriteLine("case 5");
                _playingState.Mine = true;
                    break;
                case 6:
                    _buttonDescriprion = "Footman: Gold: 400, Lumber:100";
                    if (selectedEntities.Count == 1)
                    {
                        foreach (Barracks e in selectedEntities)
                            if (e.Faction == BuildingAndUnit.faction.Human)
                                e.produceUnit(new Footman(_level, new Vector2(e.Position.X + 2 * data.tSize(), e.Position.Y + 1 * data.tSize())));
                    }
                    Console.WriteLine("case 6, produce footman");
                    break;
                case 7:
                    _level.attackMoveUnits();
                    Console.WriteLine("case 7");
                    break;
                case 8:
                    Console.WriteLine("case 8");
                _playingState.Chop = true;
                    break;
                case 9:
                    _buttonDescriprion = "Archer: Gold: 400, Lumber:150";
                    if (selectedEntities.Count == 1)
                    {
                        foreach (Barracks e in selectedEntities)
                            if (e.Faction == BuildingAndUnit.faction.Human)
                                e.produceUnit(new Archer(_level, new Vector2(e.Position.X + 2 * data.tSize(), e.Position.Y + 1 * data.tSize())));
                    }
                    Console.WriteLine("case 9, produce ranged unit");
                    break;
                case 10:
                    Console.WriteLine("case 10");
                    break;
                case 11:
                    level.dragBuilding(2);
                    Console.WriteLine("case 11");
                    break;
                case 12:
                    Console.WriteLine("case 12");
                    break;


            }
            
        }

    }
