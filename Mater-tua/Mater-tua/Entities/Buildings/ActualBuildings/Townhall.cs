using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Townhall : StaticBuilding
{
    public Townhall(Level level, Vector2 position, faction faction)
        : base(level)
    {
        _size = 3;
        _position = position;
        _faction = faction;
        _maxhp = 25000;
        _lumberCost = 400;
        _goldCost = 400;
        _buildTime = 1000;
        _armor = 0;
        _ableToProduce = true;
        this.Reset();
        _description = "This the main base of operation";
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/HumanTownHallConstruction");
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

    private void ProduceWorkerUnit(Vector2 TownhallPosition)
    {
        if (_faction == faction.Orc)
        {
            Peon peon = new Peon(_level, new Vector2(TownhallPosition.X - 64, TownhallPosition.Y));
            _level.entities.Add(peon);
        }
        if (_faction == faction.Human)
        {
            Peasant peasant = new Peasant(_level, new Vector2(TownhallPosition.X - 64, TownhallPosition.Y));
            _level.entities.Add(peasant);
           
        }
    }
}