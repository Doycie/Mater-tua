using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class StaticBuilding : SpriteEntity
{
    protected int _hp;
    protected float _BuildTime;
    protected int _lumberCost;
    protected int _goldCost;
    protected int[] _buildingSize;
    protected bool _ableToFire;
    protected bool _ableToProduce;

    public enum faction { Orc, Human, Neutral }
    protected faction _faction;

    protected Texture2D _tex;

    public StaticBuilding(string assetName, int layer = 0) : base(assetName, layer)
    {
    }

    public bool AbleToProduce
    {
        get { return _ableToProduce; }
    }

    public bool AbleToFire
    {
        get { return _ableToFire; }
    }

    public int[] BuildingSize
    {
        get { return _buildingSize; }
    }

    public int LumberCost
    {
        get { return _lumberCost; }
    }

    public int GoldCost
    {
        get { return _goldCost; }
    }

    public int HitPoints
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public faction Faction
    {
        get { return _faction; }
    }

    public float BuildTime
    {
        get { return _BuildTime; }
        set { _BuildTime = value; }
    }

    
}

