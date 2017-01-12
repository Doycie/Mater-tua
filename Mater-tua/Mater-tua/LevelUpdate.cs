using System.Linq;

partial class Level
{
    public void update()
    {
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
                    if (typeof(BuildingAndUnit).IsAssignableFrom(entities[i].GetType()))
                    {
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

        Player.Update();
    }
}