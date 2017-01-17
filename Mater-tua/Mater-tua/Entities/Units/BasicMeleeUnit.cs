using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
internal class BasicMeleeUnit : CombatUnit
{//de basis voor de Footman & Grunt
    public BasicMeleeUnit(Level level)
        : base(level)
    {
        _maxhp = 60;
        _armor = 2;
        _armorType = armorType.Light;
        _entityType = entityType.Combat;
        _goldCost = 400;
        _lumberCost = 0;
        _damage = 10;
        _damageType = damageType.Piercing;
        _productionTime = 600;
        _range = 1; //melee range
        _attackButton = true;
        _moveButton = true;
        _stopButton = true;
        _patrolButton = true;
        _holdPositionButton = true;

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

    public override void Draw(SpriteBatch s)
    {
        base.Draw(s);
        s.Draw(_sprite, new Rectangle((int)_position.X + data.tSize() / 2, (int)_position.Y + data.tSize() / 2, data.tSize() / 2, data.tSize() / 2), null, new Color(1.0f, 1.0f, 1.0f, 0.1f), (float)isAttacking, Vector2.Zero, SpriteEffects.None, 0.0f);
    }
}