using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
internal class StaticBuilding : BuildingAndUnit
{
    protected float _buildTime;
    protected bool _ableToProduce;
    protected bool _Friendcanwalktrough;
    protected bool _EnemycanWalktrough;


    public StaticBuilding(Level level) : base(level)
    {
        _entityType = entityType.Building;
        _visionRange = 6;
    }

    public bool AbleToProduce
    {
        get { return _ableToProduce; }
    }

    public float BuildTime
    {
        get { return _buildTime; }
        set { _buildTime = value; }
    }

    public void setPos(Vector2 pos)
    {
        int x =  (int)pos.X / 64;
        int y = (int)pos.Y / 64;
        _position = new Vector2(x * 64, y * 64);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        //Healthbar(spriteBatch);
    }
}