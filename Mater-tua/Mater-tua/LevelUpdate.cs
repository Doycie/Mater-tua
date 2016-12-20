using System.Linq;

partial class Level
{
    public void update()
    {
        //Update all the entities in the level list
        foreach (BuildingAndUnit e in entities.OfType<BuildingAndUnit>())
        {
            e.Update();
        }
    }

}