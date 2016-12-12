

partial class Level
{
    public void update()
    {

        foreach (Entity e in entities)
        {
            e.update();
        }
    }
}