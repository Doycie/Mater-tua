﻿internal class BasicMeleeUnit : CombatUnit
{//de basis voor de Footman & Grunt
    public BasicMeleeUnit(Level level)
        : base(level)
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
        _attackButton = true;

        this.Reset();
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public void setFaction(faction e)
    {
        if (_faction != e)
        {
            _faction = e;
            if (_faction == faction.Human)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Human");
            }
            if (_faction == faction.Orc)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Units/Orc");
            }
        }
    }
}