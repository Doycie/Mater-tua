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
        level.Player.AddGold(-400);
        level.Player.AddFood(-1);
        if (level.Player.Gold >= 400 && level.Player.Food >= 0)
        {
            int unitCreationTimer = 6000;
            while (unitCreationTimer > 0)
            {
                unitCreationTimer -= 1;
            }
            if (unitCreationTimer == 0)
            {
                Footman e = new Footman(level, new Vector2(position.X + 2 * data.tSize(), position.Y + data.tSize()));
                level.entities.Add(e);
                unitCreationTimer = 600;
            }
        }
        else
        {
            level.Player.AddGold(400);
            level.Player.AddFood(1);
        }

    }

    public void produceRangedUnit(Level level, Vector2 position)
    {
        RangedUnit e = new RangedUnit(level, new Vector2(position.X + 2 * data.tSize(), position.Y + data.tSize()), faction.Human);
        level.entities.Add(e);
    }
}