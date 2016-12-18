using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


class BasicMeleeUnit : CombatUnit
{//de basis voor de Footman & Grunt

    public BasicMeleeUnit()
        : base()
    {
        _armor = 2;
        _armorType = armorType.Light;
        _goldCost = 400;
        _lumberCost = 0;
        _damage = 10;
        _damageType = damageType.Piercing;
        _productionTime = 600;
        _range = 1; //melee range
        this.Reset();
    }

    public override void Reset()
    {
        _hp = 60;
    }

    public void setFaction(faction e)
    {

        
        if(_faction != e)
        {
           
            _faction = e;
            if (_faction == faction.Human)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("birb2");
            }
            if (_faction == faction.Orc)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("birb");
            }

           
        }

        
    }

}

