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
                if ((entities[i] as BuildingAndUnit).HitPoints < 1)
                {
                    GameEnvironment.getAssetManager().PlaySoundEffect("Sounds/Soundeffects/DieSound");
                    specialFX.Add(new Explosion("Sprites/Misc/explosionSpriteSheet", entities[i].Position, entities[i].Size));
                    entities.RemoveAt(i);
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
    }
}