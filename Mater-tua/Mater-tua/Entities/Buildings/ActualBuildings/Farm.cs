using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


class Farm : StaticBuilding
{// de basis voor de orc/human farms
    public Farm(Vector2 position, Unit.faction faction)
        : base()
    {
        _size = 2;
        _position = position;
        _faction = faction;
        _maxhp = 2500;
        _lumberCost = 400;
        _goldCost = 400;
        _buildTime = 1000;
        _armor = 0;
        this.Reset();

        if (_faction == Unit.faction.Human)
        {
            _description = "This is where food for the army is produced. You must produce enough food for all Units otherwise they will die off.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("HumanFarm");
        }

        if (_faction == Unit.faction.Orc)
        {
            _description = "Farms produce the grain and animals needed to keep the army well fed. You must produce enough food to supply all Orcs you control.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("OrcFarm");
        }
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }
}

