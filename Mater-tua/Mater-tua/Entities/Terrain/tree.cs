using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Tree : BuildingAndUnit
{

    private int _TreeAmount;

    public Tree(Level level,Vector2 Position)
        : base(level)
    {
        _resourceType = resourceType.Wood;
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/tree");
        _position = Position;
        _maxhp = 10;
        this.Reset();
        _faction = BuildingAndUnit.faction.Neutral;
        _TreeAmount = _maxhp;
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, _size * data.tSize(), _size * data.tSize()), Color.White);
    }

    public int TreeAmount
    {

        get { return _TreeAmount; }
    }

    public void TreeUseage()
    {
        _TreeAmount -= 1;
        _hp -= 1;
    }
}