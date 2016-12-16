

partial class Level
{
    public void update()
    {
        //Update all the entities in the level list
        foreach (EntityTemp e in entities)
        {
            e.update();
        }
    }

}