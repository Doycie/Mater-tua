using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



internal class ProductionBuilding : StaticBuilding
{
    public ProductionBuilding(Level level) : base(level)
    {
    }

    public void produceFootman(Level level, Vector2 position)
    {
        Footman e = new Footman(level, new Vector2(position.X + 2 * data.tSize(), position.Y + data.tSize()));
        level.entities.Add(e);
    }

    public void produceRangedUnit(Level level, Vector2 position)
    {
        RangedUnit e = new RangedUnit(level, new Vector2(position.X + 2 * data.tSize(), position.Y + data.tSize()), faction.Human);
        level.entities.Add(e);
    }
}