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

            int h, k;

            k = GameEnvironment.getCamera().getView().Y / 16;
            int o = GameEnvironment.getCamera().getView().X / 16;
            for ( h = 0 ; h < GameEnvironment.getCamera().getScreenSize().X / 16 ; h++)
            {
                int l = o + h + k * 256;
                if (!(l > 256 * 256 - 1 || l < 0))
                    data[l] = Color.Red;
            }

             k = GameEnvironment.getCamera().getView().Height / 16;
            for (h = 0; h < GameEnvironment.getCamera().getScreenSize().X / 16; h++)
            {
                int l = o + h + k * 256;
                if (!(l > 256 * 256 - 1 || l < 0))
                    data[l] = Color.Red;
            }

            k = GameEnvironment.getCamera().getView().X / 16;
            int p = GameEnvironment.getCamera().getView().Y / 16;
            for (h = 0; h < GameEnvironment.getCamera().getScreenSize().Y / 16; h++)
            {
                int l = p * 256 + k + h * 256;
                if (!(l > 256 * 256 - 1 || l < 0))
                    data[l] = Color.Red;
            }

            k = GameEnvironment.getCamera().getView().Width / 16;
            for (h = 0; h < GameEnvironment.getCamera().getScreenSize().Y / 16; h++)
            {
                int l = p * 256+ k + h * 256;
                if (!(l > 256 * 256 - 1 || l < 0))
                    data[l] = Color.Red;
            }

            int a = (int)(e.Position.X / 64) * 4 + (((int)e.Position.Y / 64) * 64 * 4) * 4;

            int d = 4;
            int f = 2;
            if(e is StaticBuilding)
            {
                d = 16;
                f = 4;
            }
            for (int i = 0; i < d; i++)
            {
                int b = a;
                b += i % f;
                b += i / f * 256;

                if (!(b < 0 || b > 256 * 256 - 1))

                    data[b] = c;
            }
        }

        _minimap.SetData(data);
    }
}