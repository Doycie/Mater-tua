using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    static private int _Wood;
    static private int _Gold;
    static private int _Food;
    static private int _AmountFarms;
    static private int _TempFarms;

    private Level _level;

    public Player(Level level)
    {
        _level = level;

        foreach (Farm e in _level.entities.OfType<Farm>())
        {
            if (e.Faction == BuildingAndUnit.faction.Human)
            {
                _AmountFarms += 1;
            }
        }


    }

    public void Update()
    {
        FoodUpdate();
        _Food = _AmountFarms * 6 + 10;
    }

    static public int Wood
    {
        get { return _Wood; }
    }

    static public int Gold
    {
        get { return _Gold; }
    }

    static public int Food
    {
        get { return _Food; }
    }

    public void AddWood(int Amount)
    {
        _Wood = _Wood + Amount;
    }

    public void AddGold(int Amount)
    {
        _Gold = _Gold + Amount;
    }

    public void AddFood(int Amount)
    {
        _Food = _Food + Amount;
    }

    public void SubtractWood(int Amount)
    {
        _Wood = _Wood - Amount;
    }

    public void SubtractGold(int Amount)
    {
        _Gold = _Gold - Amount;
    }

    public void SubtractFood(int Amount)
    {
        _Food = _Food - Amount;
    }

    private void FoodUpdate()
    {
        foreach (Farm e in _level.entities.OfType<Farm>())
        {
            if (e.Faction == BuildingAndUnit.faction.Human)
            {
                _TempFarms += 1;
            }
        }

        if (_TempFarms < _AmountFarms)
        {
            while (_TempFarms < _AmountFarms)
            {
                _AmountFarms -= 1;
            }

        }
        else if (_TempFarms > _AmountFarms)
        {
            while (_TempFarms > _AmountFarms)
            {
                _AmountFarms += 1;
            }
        }
        _TempFarms = 0;
    }
}