﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Townhall : StaticBuilding
{
    public Townhall(Level level, Vector2 position, faction faction)
        : base(level)
    {
        _size = 2;
        _position = position;
        _faction = faction;
        _maxhp = 25000;
        _lumberCost = 400;
        _goldCost = 400;
        _buildTime = 1000;
        _armor = 0;
        _ableToProduce = true;
        this.Reset();
        _description = "This the main base of operation";
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/birb2");
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

    private void ProduceWorkerUnit(Vector2 TownhallPosition)
    {
        WorkerUnit Worker = new WorkerUnit(_level, new Vector2(TownhallPosition.X - 64, TownhallPosition.Y), _faction);
        _level.entities.Add(Worker);
    }
}

