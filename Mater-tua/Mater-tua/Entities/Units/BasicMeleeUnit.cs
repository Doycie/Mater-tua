using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


class BasicMeleeUnit : CombatUnit
{
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
        this.Reset();
    }

    public override void Reset()
    {
        _hp = 60;
    }

}

