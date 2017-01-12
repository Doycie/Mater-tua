using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Tree : BuildingAndUnit
{
    public Tree(Level level, Vector2 Position)
        : base(level)
    {
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/tree");
        _position = Position;
        _maxhp = 25000;
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