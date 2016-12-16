using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


class CombatUnit : Unit
{
    protected int _damage;
    public enum damageType { Normal, Piercing, Siege } // normal > light, Piercing > Heavy, Siege > Fortified (buildings)
    protected damageType _damageType;
    protected int _range;

    public CombatUnit()
        : base()
    {

    }

    public int Damage
    {
        get { return _damage; }
    }

    public damageType DamageType
    {
        get { return _damageType; }
    }

    public int Range
    {
        get { return _range; }
    }
}

