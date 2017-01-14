using Microsoft.Xna.Framework.Graphics;

internal class StaticBuilding : BuildingAndUnit
{
    protected float _buildTime;

    protected bool _ableToProduce;
    protected bool _Friendcanwalktrough;
    protected bool _EnemycanWalktrough;


    public StaticBuilding(Level level) : base(level)
    {
      
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

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        Healthbar(spriteBatch);
    }
}