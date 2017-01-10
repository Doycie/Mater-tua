﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Mine : StaticBuilding
{
    public Mine(Level level, Vector2 position, faction faction)
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
        _ableToProduce = false;
        this.Reset();
        _description = "This is where gold can be mined. Gold is nessecary for the production of units and buildings.";
        _sprite = GameEnvironment.getAssetManager().GetSprite("Mine");
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }


}

