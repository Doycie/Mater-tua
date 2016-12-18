using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


class BasicMeleeUnit : CombatUnit
{//de basis voor de Footman & Grunt

    public BasicMeleeUnit()
        : base()
    {
        _maxhp = 60;
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
        _hp = _maxhp;
    }

}

