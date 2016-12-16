

partial class Level
{
    public void update()
    {

        foreach (EntityTemp e in entities)
        {
            e.update();
        }
    }

}