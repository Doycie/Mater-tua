using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class Player
{
    private int _Wood;
    private int _Gold;

    public Player()
    { 
            
    }

    public int Wood
    {
        get { return _Wood; }
    }

    public int Gold
    {
        get { return _Gold; }
    }

    public void AddWood(int Amount)
    {
        _Wood = _Wood + Amount;
    }

    public void AddGold(int Amount)
    {
        _Gold = _Gold + Amount;
    }



}

