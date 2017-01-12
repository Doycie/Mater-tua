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
    private int _FarmCount;
    private Level _level;

    public Player(Level level)
    {
        _level = level;
        foreach (Farm e in _level.entities.OfType<Farm>())
        {
            _FarmCount++;
        }

        
    }

    public void Update()
    {
        FoodUpdate();
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

    private void FoodUpdate()
    {
        int i = 0;
        foreach (Farm e in _level.entities.OfType<Farm>())
        {
            i++;
        }

        if (i < _FarmCount)
        {
            while (i < _FarmCount)
            {
                _FarmCount++;
            }
        }
        else if (i > _FarmCount)
        {
            while (i > _FarmCount)
            {
                _FarmCount--;
            }
        }
        _Food = _FarmCount * 10;
    }
}