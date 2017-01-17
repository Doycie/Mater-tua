using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



internal class ProductionBuilding : StaticBuilding
{
    public ProductionBuilding(Level level, string assetName, int layer = 0) : base(level)
    {
        base._buildTime = 1000;
        base._faction = BuildingAndUnit.faction.Human;
        base._goldCost = 500;
        base._lumberCost = 500;
        base._hp = 1000;
    }
    public void ProduceUnit(Type unitType, Level level, Vector2 position)
    {
        Type type = typeof(BuildingAndUnit).MakeGenericType(unitType);
        object newUnit = Activator.CreateInstance(type, level, position);
    }
}