using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class Barracks : StaticBuilding
{
    private int _unitLevel;

    public Barracks(Level level, Vector2 position, faction faction)
        : base(level)
    {
        _size = 2;
        _position = position;
        _faction = faction;
        _maxhp = 2500;
        _lumberCost = 400;
        _goldCost = 400;
        _buildTime = 1000;
        _armor = 0;
        _ableToProduce = true;
        this.Reset();

        if (_faction == faction.Human)
        {
            _description = "This is where units that can fight be produced.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("");
        }

        if (_faction == faction.Orc)
        {
            _description = "Here is where the units are produced to fight";
            _sprite = GameEnvironment.getAssetManager().GetSprite("");
        }
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

    public override void Update()
    {
        base.Update();
    }

    private void ProduceUnit()
    {
        if (_unitLevel == 0)
        {
            if (_faction == faction.Orc)
            {
                Grunt grunt = new Grunt(_level, new Vector2(_position.X - 64, _position.Y));
                _level.entities.Add(grunt);
            }
            if (_faction == faction.Human)
            {
                Footman footman = new Footman(_level, new Vector2(_position.X - 64, _position.Y));
                _level.entities.Add(footman);
            }
        }
    }


}
    
