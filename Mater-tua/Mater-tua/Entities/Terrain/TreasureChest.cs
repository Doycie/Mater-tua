using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

partial class TreasureChest : BuildingAndUnit
{
    public TreasureChest(Level level, Vector2 Position)
        : base(level)
    {
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/TreasureChest");
        _position = Position;
        _maxhp = 100;
        this.Reset();
        _faction = BuildingAndUnit.faction.Neutral;
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}

