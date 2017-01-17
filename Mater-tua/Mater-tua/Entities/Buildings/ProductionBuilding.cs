using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



internal class ProductionBuilding : StaticBuilding
{
    public ProductionBuilding(Level level) : base(level)
    {
    }

    public void ProduceUnit(Type unitType, Level level, Vector2 position)
    {
        Type type = typeof(BuildingAndUnit).MakeGenericType(unitType);
        object newUnit = Activator.CreateInstance(type, level, position);
    }
}