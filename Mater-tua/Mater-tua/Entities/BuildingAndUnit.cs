using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BuildingAndUnit : AnimatedEntity
{
    protected int _maxhp;
    protected int _hp;
    protected int _armor;
    protected int _damage;
    protected int _lumberCost;
    protected int _goldCost;
    protected int _range;
    protected string _description;
    protected BuildingAndUnit _target;
    protected Texture2D _healthbar;

    public enum armorType { Light, Heavy, Fortified }
    protected armorType _armorType;

    public enum faction { Orc, Human, Neutral }
    protected faction _faction;

    public enum damageType { Normal, Piercing, Siege } // normal > light, Piercing > Heavy, Siege > Fortified (buildings)
    protected damageType _damageType;

    public BuildingAndUnit()
        : base()
    {
       _healthbar =  GameEnvironment.getAssetManager().GetSprite("healthbar");
    }

    public int Damage
    {
        get { return _damage; }
    }

    public int Range
    {
        get { return _range; }
    }



    public void hurt(int a)
    {
        _hp -= a;
        Console.WriteLine(_hp);
        Console.WriteLine(_maxhp);
    }

    public string Description
    {
        get { return _description; }
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

    public armorType ArmorType
    {
        get { return _armorType; }
    }

    public faction Faction
    {
        get { return _faction; }
    }

    public damageType DamageType
    {
        get { return _damageType; }
    }

    public BuildingAndUnit Target
    {
        get { return _target; }
    }

    public void removeTarget()
    {
        _target = null;
    }

    public void Healthbar(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_healthbar, new Rectangle((int)_position.X, (int)_position.Y - 20, (int)((float)(_size * data.tSize()) * ((float)_hp / (float)_maxhp)) , data.tSize() / 10), Color.White);
    }

    public override void Draw( SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, _size * data.tSize(), _size * data.tSize()), Color.White);
        Healthbar(spriteBatch);
    }
}

