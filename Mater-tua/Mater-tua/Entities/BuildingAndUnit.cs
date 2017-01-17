using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public partial class BuildingAndUnit : AnimatedEntity
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
    protected Level _level;

    public enum armorType { Light, Heavy, Fortified }

    protected armorType _armorType;

    public enum faction { Orc, Human, Neutral }

    protected faction _faction;

    public enum damageType { Normal, Piercing, Siege } // normal > light, Piercing > Heavy, Siege > Fortified (buildings)

    protected damageType _damageType;

    public enum entityType { Combat, Worker, Building }

    protected entityType _entityType;

    public enum resourceType { Gold, Wood }

    protected resourceType _resourceType;

    public BuildingAndUnit(Level level)
        : base()
    {
        _level = level;
        //_healthbar = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/healthbar");
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

    public entityType EntityType
    {
        get { return _entityType; }
    }

    public resourceType ResourceType
    {
        get { return _resourceType; }
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
        if (_hp < _maxhp)
        {
            int y = (int)_position.Y;
            if (y - 8 < 0)
            {
                y = 8;
            }
            if (((float)_hp / (float)_maxhp) < (2.0f / 3.0f))
            {
                if (((float)_hp / (float)_maxhp) > (1.0f / 3.0f))
                {
                    _healthbar = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/healthbar66");
                }
                else
                {
                    _healthbar = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/healthbar33");
                }
            }
            else
            {
                _healthbar = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/healthbar");
            }
            DrawingHelper.DrawRectangle(new Rectangle((int)_position.X - 1, y - 8, (int)_size * data.tSize() + 1, (int)data.tSize() / 10 + 1), spriteBatch, Color.White, 1);
            spriteBatch.Draw(_healthbar, new Rectangle((int)_position.X, y - 7, (int)((float)(_size * data.tSize()) * ((float)_hp / (float)_maxhp)), data.tSize() / 10), Color.White);
        }
    }

    public void Healthbar(SpriteBatch spriteBatch, Vector2 pos)
    {

        if (((float)_hp / (float)_maxhp) < (2.0f / 3.0f))
        {
            if (((float)_hp / (float)_maxhp) > (1.0f / 3.0f))
            {
                _healthbar = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/healthbar66");
            }
            else
            {
                _healthbar = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/healthbar33");
            }
        }
        else
        {
            _healthbar = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/healthbar");
        }
        DrawingHelper.DrawRectangle(new Rectangle((int)pos.X - 1, (int)pos.Y - 8, (int)_size * data.tSize() + 1, (int)data.tSize() / 10 + 1), spriteBatch, Color.White, 1);
        spriteBatch.Draw(_healthbar, new Rectangle((int)pos.X, (int)pos.Y - 7, (int)((float)(_size * data.tSize()) * ((float)_hp / (float)_maxhp)), data.tSize() / 10), Color.White);

    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, _size * data.tSize(), _size * data.tSize()), Color.White);
        Healthbar(spriteBatch);
    }
}