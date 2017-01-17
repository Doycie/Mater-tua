using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

partial class TreasureChest : BuildingAndUnit
{
    private int _TreasureAmount;

    public TreasureChest(Level level, Vector2 Position)
        : base(level)
    {
        _resourceType = resourceType.Gold;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/Chest");
        _position = Position;
        _maxhp = 1;
        this.Reset();
        _faction = BuildingAndUnit.faction.Neutral;
        _TreasureAmount = 1;
    }

    public int TreasureAmount
    {

        get { return _TreasureAmount; }
    }

    public void TreasureUseage()
    {
        _TreasureAmount -= 1;
        _hp -= 1;
    }
    public override void Reset()
    {
        _hp = 1;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}

