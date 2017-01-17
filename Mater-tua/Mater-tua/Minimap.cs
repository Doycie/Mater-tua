using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

internal class Minimap
{
    private Texture2D _minimap;
    // private Texture2D _mapborder; ??

    private int _size;

    public Minimap(int size)
    {
        _size = size;
        _minimap = new Texture2D(GameEnvironment.graphics.GraphicsDevice, size, size);
        Color[] data = new Color[_size * _size];

        for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;

        //  _mapborder = GameEnvironment.getAssetManager().GetSprite("Sprites/HUD/placeholderborder"); ?????
        _minimap.SetData(data);
    }

    public void draw(SpriteBatch s)
    {
        s.Draw(_minimap, new Rectangle(0, (int)GameEnvironment.getCamera().getScreenSize().Y - _size, _size, _size), Color.White);
        // s.Draw(_mapborder, new Rectangle((int)GameEnvironment.getCamera().getScreenSize().X - _mapborder.Width, (int)GameEnvironment.getCamera().getScreenSize().Y - _mapborder.Height, 256, 256)); ??
    }

    public void update(Level level)
    {
        Color[] data = new Color[_size * _size];

        for (int i = 0; i < data.Length; ++i) data[i] = Color.Peru;

        foreach (BuildingAndUnit e in level.entities)
        {
            Color c = Color.White;
            if (e.Faction == BuildingAndUnit.faction.Human &&(e.EntityType == BuildingAndUnit.entityType.Combat))
            {
                c = Color.Blue;
            }
            else if (e.Faction == BuildingAndUnit.faction.Human && (e.EntityType == BuildingAndUnit.entityType.Building))
            {
                c = Color.LightGray;
            }
            else if (e.Faction == BuildingAndUnit.faction.Human && (e.EntityType == BuildingAndUnit.entityType.Worker))
            {
                c = Color.CadetBlue;
            }
            else if (e.Faction == BuildingAndUnit.faction.Orc &&(e.EntityType == BuildingAndUnit.entityType.Combat))
            {
                c = Color.Red;
            }
            else if (e.Faction == BuildingAndUnit.faction.Orc && (e.EntityType == BuildingAndUnit.entityType.Building))
            {
                c = Color.Black;
            }
            else if (e.Faction == BuildingAndUnit.faction.Orc && (e.EntityType == BuildingAndUnit.entityType.Worker))
            {
                c = Color.MediumVioletRed;
            }
            else if(e.ResourceType == BuildingAndUnit.resourceType.Gold)
            {
                c = Color.Gold;
            }
            else if (e.ResourceType == BuildingAndUnit.resourceType.Wood)
            {
                c = Color.ForestGreen;
            }
            else
            {
                c = Color.SandyBrown;
            }
            int a = (int)(e.Position.X / 64) * 4 + (((int)e.Position.Y / 64) * 64 * 4) * 4;

            for (int i = 0; i < 4; i++)
            {
                int b = a;
                b += i % 2;
                b += i / 2 * 256;

                if (!(b < 0 || b > 256 * 256 - 1))

                    data[b] = c;
            }
        }

        _minimap.SetData(data);
    }
}