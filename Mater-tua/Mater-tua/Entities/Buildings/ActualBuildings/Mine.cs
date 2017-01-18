using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Mine : StaticBuilding
{
    private int _MineAmount;

    public Mine(Level level, Vector2 position, faction faction)
        : base(level)
    {
        _resourceType = resourceType.Gold;
        _EnemycanWalktrough = false;
        _Friendcanwalktrough = true;
        _size = 2;
        _position = position;
        _faction = faction;
        _maxhp = 2;
        _lumberCost = 400;
        _goldCost = 400;
        _buildTime = 1000;
        _armor = 0;
        _ableToProduce = false;
        this.Reset();
        _description = "This is where gold can be mined. Gold is nessecary for the production of units and buildings.";
        _sprite = GameEnvironment.getAssetManager().GetSprite("Sprites/Buildings/Mine");
        _MineAmount = 200;
    }

    public override void Reset()
    {
        _hp = _maxhp;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

    public int MineAmount
    {
        get { return _MineAmount; }
    }

    public void MineUseage()
    {
        _MineAmount -= 1;
    }
}