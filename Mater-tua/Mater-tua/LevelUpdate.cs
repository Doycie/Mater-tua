using System.Linq;

partial class Level
{
    public void update()
    {
        //Update all the entities in the level list
        foreach (Unit e in entities.OfType<Unit>())
        {
            e.Update();
        }
    }

}