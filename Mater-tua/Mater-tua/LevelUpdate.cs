using System.Linq;

partial class Level
{
    int count = 0;

    public void update()
    {
        count++;

        if(count%30 == 0)
        { 
            foreach (CombatUnit e in entities.OfType<CombatUnit>())
             {
                if (e.Faction == CombatUnit.faction.Human)
                {
                    foreach (CombatUnit g in entities.OfType<CombatUnit>())
                    {
                        if (g.Faction == CombatUnit.faction.Orc)
                        {
                            (e as CombatUnit).Defend(g);
                            (g as CombatUnit).Defend(e);

                        }
                    }
                }
            }
        }
     
        //Update all the entities in the level list
        for (int i = entities.Count() - 1; i >= 0; i--)
        {
            if (typeof(BuildingAndUnit).IsAssignableFrom(entities[i].GetType()))
            {
                entities[i].Update();
                if (typeof(Unit).IsAssignableFrom(entities[i].GetType()) && entities[i].HitPoints < 1)
                {
                    GameEnvironment.getAssetManager().PlaySoundEffect("Sounds/Soundeffects/DieSound");
                }
                if (typeof(StaticBuilding).IsAssignableFrom(entities[i].GetType()) && entities[i].HitPoints < 1)
                {
                    GameEnvironment.getAssetManager().PlaySoundEffect("Sounds/Soundeffects/BuildingDemolitionSound");
                }
                if ((entities[i] as BuildingAndUnit).HitPoints < 1)
                {
                    if (typeof(Tree).IsAssignableFrom(entities[i].GetType()) || typeof(TreasureChest).IsAssignableFrom(entities[i].GetType()))
                    {
                        specialFX.Add(new Explosion("Sprites/Misc/sparkle", entities[i].Position, entities[i].Size));
                        entities.RemoveAt(i);
                    }
                    else if (typeof(BuildingAndUnit).IsAssignableFrom(entities[i].GetType()))
                    {
                        specialFX.Add(new Explosion("Sprites/Misc/explosionSpriteSheet", entities[i].Position, entities[i].Size));
                        entities.RemoveAt(i);
                    }

                } 
            }
        }

        for (int i = specialFX.Count() - 1; i >= 0; i--)
        {
            specialFX[i].Update();
            if (specialFX[i] is Explosion)
            {
                if ((specialFX[i] as Explosion).remove())
                {
                    {
                        specialFX.RemoveAt(i);
                    }
                }
            }
        }
        for (int i = Projectiles.Count() - 1; i >= 0; i--)
        {
            Projectiles[i].Update();
        }

        Player.Update();
    }
}