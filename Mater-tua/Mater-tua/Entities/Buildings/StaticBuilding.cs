﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class StaticBuilding : BuildingAndUnit
{

    protected float _buildTime;

    protected bool _ableToProduce;

    protected Level _level;

    public StaticBuilding(Level level) : base()
    {
        _level = level;
    }


    public bool AbleToProduce
    {
        get { return _ableToProduce; }
    }

    public float BuildTime
    {
        get { return _buildTime; }
        set { _buildTime = value; }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        Healthbar(spriteBatch);
    }

}

