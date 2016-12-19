using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ProductionBuilding : StaticBuilding
{
    public ProductionBuilding(string assetName, int layer = 0) : base()
    {
        base._buildTime = 1000;
        base._faction = BuildingAndUnit.faction.Human;
        base._goldCost = 500;
        base._lumberCost = 500;
        base._hp = 1000;
    }
}

