using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ProductionBuilding : StaticBuilding
{
    public ProductionBuilding(string assetName, int layer = 0) : base(assetName, layer)
    {
        base._BuildTime = 1000;
        base._faction = faction.Human;
        base._goldCost = 500;
        base._lumberCost = 500;
        base._hp = 1000;
    }
}

