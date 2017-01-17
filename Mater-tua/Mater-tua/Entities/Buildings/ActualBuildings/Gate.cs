using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Gate : StaticBuilding
{
    public Gate(Level level, Vector2 position, faction faction) : base(level)
    {
        _entityType = entityType.Building;
        _EnemycanWalktrough = false;
        _Friendcanwalktrough = true;
        _size = 2;
        _position = position;
        _faction = faction;
        _maxhp = 2500;
        _lumberCost = 200;
        _goldCost = 0;
        _buildTime = 500;
        _armor = 10;
        _ableToProduce = true;
        this.Reset();

        if (_faction == faction.Human)
        {
            _description = "This is a Gate.";
            _sprite = GameEnvironment.getAssetManager().GetSprite("");
        }

        if (_faction == faction.Orc)
        {
            _description = "Gate this is";
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
    }
}