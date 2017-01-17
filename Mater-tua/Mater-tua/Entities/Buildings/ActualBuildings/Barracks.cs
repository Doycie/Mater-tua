using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Barracks : StaticBuilding
{
    private int _unitLevel;


    public Barracks(Level level, Vector2 position, faction faction)
        : base(level)
    {
        _EnemycanWalktrough = false;
        _Friendcanwalktrough = false;
        _size = 2;
        _position = position;
        _faction = faction;
        _maxhp = 2500;
        _lumberCost = 400;
        _goldCost = 400;
        _buildTime = 1000;
        _armor = 0;
        _ableToProduce = true;
        this.Reset();

        if (_faction == faction.Human)
        {
            _description = "This is where units that can fight be produced.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/HumanBarracks");
        }

        if (_faction == faction.Orc)
        {
            _description = "This is where the units are produced to fight";
            _sprite = GameEnvironment.getAssetManager().GetSprite("");
        }
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        //Healthbar(spriteBatch);
    }
    public override void Update()
    {
        base.Update();
       
        if ((float)_hp / (float)_maxhp < 1.0f / 3.0f)
        {

            if (_faction == faction.Human)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/HumanBarracksConstruction");
            }

            if (_faction == faction.Orc)
            {
                _sprite = GameEnvironment.getAssetManager().GetSprite("");
            }
        }
    }
}