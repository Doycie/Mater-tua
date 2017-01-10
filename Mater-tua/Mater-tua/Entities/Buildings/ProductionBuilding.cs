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
}