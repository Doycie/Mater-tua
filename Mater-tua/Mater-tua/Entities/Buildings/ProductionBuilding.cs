using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



internal class ProductionBuilding : StaticBuilding
{
    public ProductionBuilding(Level level) : base(level)
    {
    }

    public void ProduceUnit(Level level, Vector2 position)
    {
        Footman e = new Footman(level, new Vector2(position.X, position.Y));
        level.entities.Add(e);
    }
}