using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class StaticBuilding : SpriteEntity
{
    protected int _maxhp;
    protected int _hp;
    protected int _armor;
    protected int _damage;
    protected float _buildTime;
    protected int _lumberCost;
    protected int _goldCost;
    protected bool _ableToProduce;
    protected Unit.armorType _armorType = Unit.armorType.Fortified;
    protected Unit.faction _faction;
    protected CombatUnit.damageType _damageType;
    protected string _description;


    protected Texture2D _tex;

    public StaticBuilding() : base("", 0)
    {
    }

    public string Description
    {
        get { return _description; }
    }

    public bool AbleToProduce
    {
        get { return _ableToProduce; }
    }

    public int LumberCost
    {
        get { return _lumberCost; }
    }

    public int GoldCost
    {
        get { return _goldCost; }
    }

    public int MaxHitPoints
    {
        get { return _maxhp; }
    }
    public int HitPoints
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public int Armor
    {
        get { return _armor; }
    }

    public Unit.faction Faction
    {
        get { return _faction; }
    }

    public Unit.armorType ArmorType
    {
        get { return _armorType; }
    }

    public CombatUnit.damageType DamageType
    {
        get { return _damageType; }
    }

    public float BuildTime
    {
        get { return _buildTime; }
        set { _buildTime = value; }
    }

}

