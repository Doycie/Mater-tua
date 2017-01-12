using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Stone : BuildingAndUnit
{
    //Henk de steen
    public Stone(Level level, Vector2 Position)
        : base(level)
    {
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/Boulder");
        _position = Position;
        _maxhp = 45000;
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

