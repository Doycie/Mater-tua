using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class ProductionBuilding : StaticBuilding
{
    int footmanCreationTimer = 600;
    bool creatingFootman = false;

    public ProductionBuilding(Level level) : base(level)
    {
    }

    public void produceFootman(Level level, Vector2 position)
    {

        if (level.Player.Gold >= 400 && level.Player.Food >= 0)
        {
            level.Player.AddGold(-400);
            level.Player.AddFood(-1);
            creatingFootman = true;

            /* INSERT WORKING DELAY THING HERE */
            
            if (footmanCreationTimer <= 0)
            {
                Footman e = new Footman(level, new Vector2(position.X + 2 * data.tSize(), position.Y + data.tSize()));
                level.entities.Add(e);
                footmanCreationTimer = 600;
                creatingFootman = false;
            }
        }
    }

    public void produceRangedUnit(Level level, Vector2 position)
    {
        RangedUnit e = new RangedUnit(level, new Vector2(position.X + 2 * data.tSize(), position.Y + data.tSize()), faction.Human);
        level.entities.Add(e);
    }

    public override void Update()
    {
        base.Update();
        if (creatingFootman)
        {
            footmanCreationTimer--;
            Console.WriteLine(footmanCreationTimer);
        }
    }
}  